using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FutureFront
{
	public unsafe partial class MainForm : Form
	{
		public MainForm(string[] args)
		{
			InitializeComponent();

			if (args.Length > 0)
			{
				LoadFile(args[0]);
				SyncTiming();
				RefreshFB();
			}
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			var ofd = new OpenFileDialog();
			ofd.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\..\\..";
			ofd.FileName = "Tank.ch8";
			if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				return;
			LoadFile(ofd.FileName);
		}

		void LoadFile(string path)
		{
			OctoWaddle.Load(path);
			SyncTiming();
			RefreshFB();
		}

		void RefreshFB()
		{
			void* ptr = OctoWaddle.FetchFB();
			var bmp = new System.Drawing.Bitmap(64, 32);
			for(int y=0;y<32;y++)
				for (int x = 0; x < 64; x++)
				{
					bmp.SetPixel(x, y, ((byte*)ptr)[y * 64 + x] == 0 ? Color.Black : Color.White);
				}

			pictureBox1.SetBitmap(bmp);
		}

		private void btnStepFrame_Click(object sender, EventArgs e)
		{
			DoStepFrame();
		}

		private void btnStepInstr_Click(object sender, EventArgs e)
		{
			OctoWaddle.StepInstruction();
			PostRun();
		}

		void SyncTiming()
		{
			var timing = OctoWaddle.GetTiming();
			txtCycleNum.Text = timing.cycles.ToString();
			txtFrameNum.Text = timing.frames.ToString();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (btnRunToggle.Checked)
				DoStepFrame();
		}

		void DoStepFrame()
		{
			PreRun();
			OctoWaddle.SetCyclesPerFrame(int.Parse(txtFrameCycles.Text));
			OctoWaddle.StepFrame();
			PostRun();
		}

		void PreRun()
		{
			OctoWaddle.SetCyclesPerFrame(int.Parse(txtFrameCycles.Text));
			int keys = 0;
			if (cbKeypad0.Checked) keys |= 1;
			if (cbKeypad1.Checked) keys |= 2;
			if (cbKeypad2.Checked) keys |= 4;
			if (cbKeypad3.Checked) keys |= 8;
			if (cbKeypad4.Checked) keys |= 16;
			if (cbKeypad5.Checked) keys |= 32;
			if (cbKeypad6.Checked) keys |= 64;
			if (cbKeypad7.Checked) keys |= 128;
			if (cbKeypad8.Checked) keys |= 256;
			if (cbKeypad9.Checked) keys |= 512;
			if (cbKeypadA.Checked) keys |= 1024;
			if (cbKeypadB.Checked) keys |= 2048;
			if (cbKeypadC.Checked) keys |= 4096;
			if (cbKeypadD.Checked) keys |= 8192;
			if (cbKeypadE.Checked) keys |= 16384;
			if (cbKeypadF.Checked) keys |= 32768;
			OctoWaddle.SetKeys(keys);
		}

		void PostRun()
		{
			SyncTiming();
			RefreshFB();
		}

		private void btnRun_Click(object sender, EventArgs e)
		{

		}

		private void btnRunToggle_CheckedChanged(object sender, EventArgs e)
		{
			btnStepInstr.Enabled = !btnRunToggle.Checked;
			btnStepFrame.Enabled = !btnRunToggle.Checked;
		}

	}

	static unsafe class OctoWaddle
	{
		public struct Timing
		{
			public int frames, cycles;
		}

		[DllImport("OctoWaddle.dll", EntryPoint = "Load", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Load(string fname);

		[DllImport("OctoWaddle.dll", EntryPoint = "StepInstruction", CallingConvention = CallingConvention.Cdecl)]
		public static extern void StepInstruction();

		[DllImport("OctoWaddle.dll", EntryPoint = "StepFrame", CallingConvention = CallingConvention.Cdecl)]
		public static extern void StepFrame();

		[DllImport("OctoWaddle.dll", EntryPoint = "SetCyclesPerFrame", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetCyclesPerFrame(int val);

		[DllImport("OctoWaddle.dll", EntryPoint = "GetTiming", CallingConvention = CallingConvention.Cdecl)]
		public static extern Timing GetTiming();

		[DllImport("OctoWaddle.dll", EntryPoint = "FetchFB", CallingConvention = CallingConvention.Cdecl)]
		public static extern void* FetchFB();

		[DllImport("OctoWaddle.dll", EntryPoint = "SetKeys", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SetKeys(int keys);
	}
}
