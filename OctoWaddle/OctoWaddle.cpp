#include <stdio.h>
#include <stdint.h>
#include <stdlib.h>
#include <string.h>

//http://devernay.free.fr/hacks/chip8/C8TECH10.HTM
//http://johnearnest.github.io/Octo/index.html?gist=8e3190a0524169febfbc2c895c736726
//http://www.chip8.com/

typedef uint8_t u8;
typedef uint16_t u16;

u8 ram[0x1000];
struct {
	u8 V[16];
	u16 I;
	u16 PC;
	u8 SP;
	u16 stack[16];
	u8 DT, ST;
	u16 keys;
} regs;

struct Timing
{
	int frames, cycles;
} timing;


int cyclesPerFrame = 20;

u8 screen[64*32];

static const u8 bios[] = {
  0xF0, 0x90, 0x90, 0x90, 0xF0, // 0
  0x20, 0x60, 0x20, 0x20, 0x70, // 1
  0xF0, 0x10, 0xF0, 0x80, 0xF0, // 2
  0xF0, 0x10, 0xF0, 0x10, 0xF0, // 3
  0x90, 0x90, 0xF0, 0x10, 0x10, // 4
  0xF0, 0x80, 0xF0, 0x10, 0xF0, // 5
  0xF0, 0x80, 0xF0, 0x90, 0xF0, // 6
  0xF0, 0x10, 0x20, 0x40, 0x40, // 7
  0xF0, 0x90, 0xF0, 0x90, 0xF0, // 8
  0xF0, 0x90, 0xF0, 0x10, 0xF0, // 9
  0xF0, 0x90, 0xF0, 0x90, 0x90, // A
  0xE0, 0x90, 0xE0, 0x90, 0xE0, // B
  0xF0, 0x80, 0x80, 0x80, 0xF0, // C
  0xE0, 0x90, 0x90, 0x90, 0xE0, // D
  0xF0, 0x80, 0xF0, 0x80, 0xF0, // E
  0xF0, 0x80, 0xF0, 0x80, 0x80  // F
};

extern "C"
{
	__declspec(dllexport) void Load(const char* fname)
	{
		memset(ram,0,sizeof(ram));
		memset(&regs,0,sizeof(regs));
		memset(screen,0,sizeof(screen));
		memset(&timing,0,sizeof(timing));

		FILE* inf = fopen(fname,"rb");
		fseek(inf,0,SEEK_END);
		long len = ftell(inf);
		fseek(inf,0,SEEK_SET);
		fread(ram+512,1,len,inf);
		fclose(inf);

		//boot
		regs.PC = 512;
		memcpy(ram,bios,sizeof(bios));
		srand(2);
	}

	void StepOneInstruction()
	{
 		u16 opcode = ram[regs.PC]<<8;
		regs.PC = (regs.PC + 1)&0xFFF;
		opcode |= ram[regs.PC];
		regs.PC = (regs.PC + 1)&0xFFF;

		switch(opcode>>12)
		{
		case 0x00:
			switch(opcode&0xFF)
			{
			case 0xE0: //CLS
				memset(screen,0,sizeof(screen));
				break;

			case 0xEE: //RET
				regs.SP = (regs.SP-1)&0xF;
				regs.PC = regs.stack[regs.SP];
				break;
			}
			break;

		case 0x01:  //JP addr
			regs.PC = opcode&0xFFF;
			break;

		case 0x02: //CALL addr
			regs.stack[regs.SP] = regs.PC;
			regs.SP = (regs.SP+1)&0xF;
			regs.PC = opcode&0xFFF;
			break;

		case 0x03: //SE Vx, byte
			if(regs.V[(opcode>>8)&0xF] == (opcode&0xFF))
				regs.PC = (regs.PC + 2)&0xFFF;
			break;
		case 0x04: //SNE Vx, byte
			if(regs.V[(opcode>>8)&0xF] != (opcode&0xFF))
				regs.PC = (regs.PC + 2)&0xFFF;
			break;

		case 0x05: //SE Vx, Vy
			if(regs.V[(opcode>>8)&0xF] == regs.V[(opcode>>4)&0xF])
				regs.PC = (regs.PC + 2)&0xFFF;
			break;

		case 0x06: //LD Vx, byte
			regs.V[(opcode>>8)&0xF] = opcode&0xFF;
			break;

		case 0x07: //ADD Vx, byte
			regs.V[(opcode>>8)&0xF] += opcode&0xFF;
			break;

		case 0x08:
			switch(opcode&0x0F)
			{
			case 0x00: //LD Vx, Vy
				regs.V[(opcode>>8)&0xF] = regs.V[(opcode>>4)&0xF];
				break;
			case 0x01: //OR Vx, Vy
				regs.V[(opcode>>8)&0xF] |= regs.V[(opcode>>4)&0xF];
				break;
			case 0x02: //AND Vx, Vy
				regs.V[(opcode>>8)&0xF] &= regs.V[(opcode>>4)&0xF];
				break;
			case 0x03: //XOR Vx, Vy
				regs.V[(opcode>>8)&0xF] ^= regs.V[(opcode>>4)&0xF];
				break;
			case 0x04: //ADD Vx, Vy (set CF)
				{
					u8 &VX = regs.V[(opcode>>8)&0xF];
					u8 &VY = regs.V[(opcode>>4)&0xF];
					regs.V[15] = (VX+VY)>256;
					VX += VY;
					break;
				}
			case 0x05: //SUB Vx, Vy (VF = NOT borrow)
				{
					u8 &VX = regs.V[(opcode>>8)&0xF];
					u8 &VY = regs.V[(opcode>>4)&0xF];
					regs.V[15] = VX>VY;
					VX -= VY;
					break;
				}
			case 0x06: //SHR VX {, VY} //uhh how is VY involved?
				{
					u8 &VX = regs.V[(opcode>>8)&0xF];
					regs.V[15] = VX&1;
					VX >>= 1;
					break;
				}

			case 0x07: //SUBN Vx, VY
				{
					u8 &VX = regs.V[(opcode>>8)&0xF];
					u8 &VY = regs.V[(opcode>>4)&0xF];
					regs.V[15] = (VY>VX)?1:0;
					VX = VY-VX;
					break;
				}
			case 0x0E: //SHL Vx {, Vy}
				{
					u8 &VX = regs.V[(opcode>>8)&0xF];
					u8 &VY = regs.V[(opcode>>4)&0xF];
					regs.V[15] = (VY>=128)?1:0;
					VX<<=1;
					break;
				}
			}
			break; //case 8xxx ALU instructions

		case 0x09: //SNE Vx, VY
			if(regs.V[(opcode>>8)&0xF] != regs.V[(opcode>>4)&0xF])
				regs.PC = (regs.PC + 2)&0xFFF;
			break;

		case 0x0A: //LD I, addr
			regs.I = opcode&0xFFF;
			break;

		case 0x0B: //JP V0, addr
			regs.PC = ((opcode&0xFFF)+regs.V[0])&0xFFF;
			break;

		case 0x0C: //RND Vx, byte
			regs.V[(opcode>>8)&0xF] = rand()&(opcode&0xFF);
			break;

		case 0x0D: //DRW Vx, Vy, nibble
			//Display n-byte sprite starting at memory location I at (Vx, Vy), set VF = collision.
			{
				regs.V[15] = 0;

				int n = opcode&0xF;
				if(n==0) n=16;
				int px = regs.V[(opcode>>8)&0xF];
				int py = regs.V[(opcode>>4)&0xF];
				for(int y=0;y<n;y++)
				{
					u8 line = ram[(regs.I+y)&0xFFF];
					for(int x=0;x<8;x++)
					{
						int tx = (x+px)%64;
						int ty = (y+py)%64;
						if(line&128)
						{
							if(screen[ty*64+tx])
							{
								regs.V[15] = 1;
								screen[ty*64+tx] = 0;
							} else screen[ty*64+tx] = 1;
						}
						line <<= 1;
					}
				}

			}
			break;
		
		case 0x0E:
			switch(opcode&0xFF)
			{
			case 0x9E: //SKP VX
				//Skip next instruction if key with the value of Vx is pressed.
				//Checks the keyboard, and if the key corresponding to the value of Vx is currently in the down position, PC is increased by 2.
				if((regs.keys>>regs.V[(opcode>>8)&0xF])&1)
					regs.PC = (regs.PC + 2)&0xFFF;
				break;
			case 0xA1: //SKNP VX
				//Skip next instruction if key with the value of Vx is not pressed.
				//Checks the keyboard, and if the key corresponding to the value of Vx is currently in the up position, PC is increased by 2.
				if(!((regs.keys>>regs.V[(opcode>>8)&0xF])&1))
					regs.PC = (regs.PC + 2)&0xFFF;
				break;
			}
			break;

		case 0x0F:
			switch(opcode&0xFF)
			{
			case 0x07: //LD VX, DT
				regs.V[(opcode>>8)&0xF] = regs.DT;
				break;
			case 0x0A: //LD VX, K
				//TODO
				//Wait for a key press, store the value of the key in Vx.
				//All execution stops until a key is pressed, then the value of that key is stored in Vx.
				break;
			case 0x15: //LD DT, VX
				regs.DT = regs.V[(opcode>>8)&0xF];
				break;
			case 0x18: //LD DT, VX
				regs.ST = regs.V[(opcode>>8)&0xF];
				break;
			case 0x1E: //ADD I, Vx
				regs.I += regs.V[(opcode>>8)&0xF];
				break;
			case 0x29: //LD F, Vx
				//this enables the program to fetch the address of the built-in character set, 
				//which can be anywhere in the 'rom' (under 512 bytes) -- but we'll put it at 0
				regs.I = 5*(regs.V[(opcode>>8)&0xF]&0xF);
				break;
			case 0x33: //LD B, Vx
				{
					//untested - cracks the register value into 3 BCD values
					int v = regs.V[(opcode>>8)&0xF];
					ram[(regs.I+0)&0xFFF] = v/100;
					ram[(regs.I+1)&0xFFF] = v/10%10;
					ram[(regs.I+2)&0xFFF] = v%10;
					break;
				}
				break;
			case 0x55: //LD [I], Vx
				{
					int X = (opcode>>8)&0xF;
					u16 target = regs.I;
					for(int i=0;i<=X;i++)
					{
						ram[target] = regs.V[i];
						target = (target+1)&0xFFF;
					}
				}
				break;
			case 0x65: //LD Vx, [I]
				{
					int X = (opcode>>8)&0xF;
					u16 target = regs.I;
					for(int i=0;i<=X;i++)
					{
						regs.V[i] = ram[target];
						target = (target+1)&0xFFF;
					}
				}
				break;
			}
			break;

		} //main opcode switch

		timing.cycles++;
		if(timing.cycles >= cyclesPerFrame)
		{
			timing.cycles=0;
			timing.frames++;
			if(regs.DT>0) regs.DT--;
			if(regs.ST>0) regs.ST--;
		}
	}

	__declspec(dllexport) void SetCyclesPerFrame(int val)
	{
		cyclesPerFrame = val;
	}

	__declspec(dllexport) void* FetchFB()
	{
		return screen;
	}

	__declspec(dllexport) void StepInstruction()
	{
		StepOneInstruction();
	}

	__declspec(dllexport) void StepFrame()
	{
		int frameNum = timing.frames;
		while(timing.frames <= frameNum)
			StepOneInstruction();
	}

	__declspec(dllexport) Timing GetTiming()
	{
		return timing;
	}

	__declspec(dllexport) void SetKeys(int keys)
	{
		regs.keys = (u16)keys;
	}
}