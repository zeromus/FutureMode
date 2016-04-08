namespace FutureFront
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnStepInstr = new System.Windows.Forms.Button();
			this.txtFrameCycles = new System.Windows.Forms.TextBox();
			this.btnStepFrame = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCycleNum = new System.Windows.Forms.TextBox();
			this.txtFrameNum = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btnRunToggle = new System.Windows.Forms.CheckBox();
			this.cbKeypad1 = new System.Windows.Forms.CheckBox();
			this.cbKeypad2 = new System.Windows.Forms.CheckBox();
			this.cbKeypad3 = new System.Windows.Forms.CheckBox();
			this.cbKeypadC = new System.Windows.Forms.CheckBox();
			this.cbKeypadD = new System.Windows.Forms.CheckBox();
			this.cbKeypad6 = new System.Windows.Forms.CheckBox();
			this.cbKeypad5 = new System.Windows.Forms.CheckBox();
			this.cbKeypad4 = new System.Windows.Forms.CheckBox();
			this.cbKeypadE = new System.Windows.Forms.CheckBox();
			this.cbKeypad9 = new System.Windows.Forms.CheckBox();
			this.cbKeypad8 = new System.Windows.Forms.CheckBox();
			this.cbKeypad7 = new System.Windows.Forms.CheckBox();
			this.cbKeypadF = new System.Windows.Forms.CheckBox();
			this.cbKeypadB = new System.Windows.Forms.CheckBox();
			this.cbKeypad0 = new System.Windows.Forms.CheckBox();
			this.cbKeypadA = new System.Windows.Forms.CheckBox();
			this.pictureBox1 = new BizHawk.Client.EmuHawk.RetainedViewportPanel();
			this.SuspendLayout();
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(12, 12);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(75, 23);
			this.btnLoad.TabIndex = 0;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnStepInstr
			// 
			this.btnStepInstr.Location = new System.Drawing.Point(12, 61);
			this.btnStepInstr.Name = "btnStepInstr";
			this.btnStepInstr.Size = new System.Drawing.Size(75, 23);
			this.btnStepInstr.TabIndex = 1;
			this.btnStepInstr.Text = "Step Instr.";
			this.btnStepInstr.UseVisualStyleBackColor = true;
			this.btnStepInstr.Click += new System.EventHandler(this.btnStepInstr_Click);
			// 
			// txtFrameCycles
			// 
			this.txtFrameCycles.Location = new System.Drawing.Point(167, 25);
			this.txtFrameCycles.Name = "txtFrameCycles";
			this.txtFrameCycles.Size = new System.Drawing.Size(75, 20);
			this.txtFrameCycles.TabIndex = 3;
			this.txtFrameCycles.Text = "20";
			// 
			// btnStepFrame
			// 
			this.btnStepFrame.Location = new System.Drawing.Point(12, 111);
			this.btnStepFrame.Name = "btnStepFrame";
			this.btnStepFrame.Size = new System.Drawing.Size(75, 23);
			this.btnStepFrame.TabIndex = 4;
			this.btnStepFrame.Text = "Step Frame";
			this.btnStepFrame.UseVisualStyleBackColor = true;
			this.btnStepFrame.Click += new System.EventHandler(this.btnStepFrame_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(164, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Clocks Per Frame";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 207);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Cycle#";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(19, 233);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Frame#";
			// 
			// txtCycleNum
			// 
			this.txtCycleNum.Location = new System.Drawing.Point(65, 204);
			this.txtCycleNum.Name = "txtCycleNum";
			this.txtCycleNum.ReadOnly = true;
			this.txtCycleNum.Size = new System.Drawing.Size(75, 20);
			this.txtCycleNum.TabIndex = 8;
			// 
			// txtFrameNum
			// 
			this.txtFrameNum.Location = new System.Drawing.Point(65, 230);
			this.txtFrameNum.Name = "txtFrameNum";
			this.txtFrameNum.ReadOnly = true;
			this.txtFrameNum.Size = new System.Drawing.Size(75, 20);
			this.txtFrameNum.TabIndex = 9;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 16;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btnRunToggle
			// 
			this.btnRunToggle.Appearance = System.Windows.Forms.Appearance.Button;
			this.btnRunToggle.Checked = true;
			this.btnRunToggle.CheckState = System.Windows.Forms.CheckState.Checked;
			this.btnRunToggle.Location = new System.Drawing.Point(12, 157);
			this.btnRunToggle.Name = "btnRunToggle";
			this.btnRunToggle.Size = new System.Drawing.Size(75, 24);
			this.btnRunToggle.TabIndex = 11;
			this.btnRunToggle.Text = "Run";
			this.btnRunToggle.UseVisualStyleBackColor = true;
			this.btnRunToggle.CheckedChanged += new System.EventHandler(this.btnRunToggle_CheckedChanged);
			// 
			// cbKeypad1
			// 
			this.cbKeypad1.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypad1.AutoSize = true;
			this.cbKeypad1.Location = new System.Drawing.Point(308, 197);
			this.cbKeypad1.Name = "cbKeypad1";
			this.cbKeypad1.Size = new System.Drawing.Size(23, 23);
			this.cbKeypad1.TabIndex = 12;
			this.cbKeypad1.Text = "1";
			this.cbKeypad1.UseVisualStyleBackColor = true;
			// 
			// cbKeypad2
			// 
			this.cbKeypad2.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypad2.AutoSize = true;
			this.cbKeypad2.Location = new System.Drawing.Point(334, 197);
			this.cbKeypad2.Name = "cbKeypad2";
			this.cbKeypad2.Size = new System.Drawing.Size(23, 23);
			this.cbKeypad2.TabIndex = 13;
			this.cbKeypad2.Text = "2";
			this.cbKeypad2.UseVisualStyleBackColor = true;
			// 
			// cbKeypad3
			// 
			this.cbKeypad3.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypad3.AutoSize = true;
			this.cbKeypad3.Location = new System.Drawing.Point(360, 197);
			this.cbKeypad3.Name = "cbKeypad3";
			this.cbKeypad3.Size = new System.Drawing.Size(23, 23);
			this.cbKeypad3.TabIndex = 14;
			this.cbKeypad3.Text = "3";
			this.cbKeypad3.UseVisualStyleBackColor = true;
			// 
			// cbKeypadC
			// 
			this.cbKeypadC.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypadC.AutoSize = true;
			this.cbKeypadC.Location = new System.Drawing.Point(386, 197);
			this.cbKeypadC.Name = "cbKeypadC";
			this.cbKeypadC.Size = new System.Drawing.Size(24, 23);
			this.cbKeypadC.TabIndex = 15;
			this.cbKeypadC.Text = "C";
			this.cbKeypadC.UseVisualStyleBackColor = true;
			// 
			// cbKeypadD
			// 
			this.cbKeypadD.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypadD.AutoSize = true;
			this.cbKeypadD.Location = new System.Drawing.Point(386, 223);
			this.cbKeypadD.Name = "cbKeypadD";
			this.cbKeypadD.Size = new System.Drawing.Size(25, 23);
			this.cbKeypadD.TabIndex = 19;
			this.cbKeypadD.Text = "D";
			this.cbKeypadD.UseVisualStyleBackColor = true;
			// 
			// cbKeypad6
			// 
			this.cbKeypad6.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypad6.AutoSize = true;
			this.cbKeypad6.Location = new System.Drawing.Point(360, 223);
			this.cbKeypad6.Name = "cbKeypad6";
			this.cbKeypad6.Size = new System.Drawing.Size(23, 23);
			this.cbKeypad6.TabIndex = 18;
			this.cbKeypad6.Text = "6";
			this.cbKeypad6.UseVisualStyleBackColor = true;
			// 
			// cbKeypad5
			// 
			this.cbKeypad5.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypad5.AutoSize = true;
			this.cbKeypad5.Location = new System.Drawing.Point(334, 223);
			this.cbKeypad5.Name = "cbKeypad5";
			this.cbKeypad5.Size = new System.Drawing.Size(23, 23);
			this.cbKeypad5.TabIndex = 17;
			this.cbKeypad5.Text = "5";
			this.cbKeypad5.UseVisualStyleBackColor = true;
			// 
			// cbKeypad4
			// 
			this.cbKeypad4.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypad4.AutoSize = true;
			this.cbKeypad4.Location = new System.Drawing.Point(308, 223);
			this.cbKeypad4.Name = "cbKeypad4";
			this.cbKeypad4.Size = new System.Drawing.Size(23, 23);
			this.cbKeypad4.TabIndex = 16;
			this.cbKeypad4.Text = "4";
			this.cbKeypad4.UseVisualStyleBackColor = true;
			// 
			// cbKeypadE
			// 
			this.cbKeypadE.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypadE.AutoSize = true;
			this.cbKeypadE.Location = new System.Drawing.Point(386, 249);
			this.cbKeypadE.Name = "cbKeypadE";
			this.cbKeypadE.Size = new System.Drawing.Size(24, 23);
			this.cbKeypadE.TabIndex = 23;
			this.cbKeypadE.Text = "E";
			this.cbKeypadE.UseVisualStyleBackColor = true;
			// 
			// cbKeypad9
			// 
			this.cbKeypad9.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypad9.AutoSize = true;
			this.cbKeypad9.Location = new System.Drawing.Point(360, 249);
			this.cbKeypad9.Name = "cbKeypad9";
			this.cbKeypad9.Size = new System.Drawing.Size(23, 23);
			this.cbKeypad9.TabIndex = 22;
			this.cbKeypad9.Text = "9";
			this.cbKeypad9.UseVisualStyleBackColor = true;
			// 
			// cbKeypad8
			// 
			this.cbKeypad8.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypad8.AutoSize = true;
			this.cbKeypad8.Location = new System.Drawing.Point(334, 249);
			this.cbKeypad8.Name = "cbKeypad8";
			this.cbKeypad8.Size = new System.Drawing.Size(23, 23);
			this.cbKeypad8.TabIndex = 21;
			this.cbKeypad8.Text = "8";
			this.cbKeypad8.UseVisualStyleBackColor = true;
			// 
			// cbKeypad7
			// 
			this.cbKeypad7.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypad7.AutoSize = true;
			this.cbKeypad7.Location = new System.Drawing.Point(308, 249);
			this.cbKeypad7.Name = "cbKeypad7";
			this.cbKeypad7.Size = new System.Drawing.Size(23, 23);
			this.cbKeypad7.TabIndex = 20;
			this.cbKeypad7.Text = "7";
			this.cbKeypad7.UseVisualStyleBackColor = true;
			// 
			// cbKeypadF
			// 
			this.cbKeypadF.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypadF.AutoSize = true;
			this.cbKeypadF.Location = new System.Drawing.Point(386, 275);
			this.cbKeypadF.Name = "cbKeypadF";
			this.cbKeypadF.Size = new System.Drawing.Size(23, 23);
			this.cbKeypadF.TabIndex = 27;
			this.cbKeypadF.Text = "F";
			this.cbKeypadF.UseVisualStyleBackColor = true;
			// 
			// cbKeypadB
			// 
			this.cbKeypadB.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypadB.AutoSize = true;
			this.cbKeypadB.Location = new System.Drawing.Point(360, 275);
			this.cbKeypadB.Name = "cbKeypadB";
			this.cbKeypadB.Size = new System.Drawing.Size(24, 23);
			this.cbKeypadB.TabIndex = 26;
			this.cbKeypadB.Text = "B";
			this.cbKeypadB.UseVisualStyleBackColor = true;
			// 
			// cbKeypad0
			// 
			this.cbKeypad0.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypad0.AutoSize = true;
			this.cbKeypad0.Location = new System.Drawing.Point(334, 275);
			this.cbKeypad0.Name = "cbKeypad0";
			this.cbKeypad0.Size = new System.Drawing.Size(23, 23);
			this.cbKeypad0.TabIndex = 25;
			this.cbKeypad0.Text = "0";
			this.cbKeypad0.UseVisualStyleBackColor = true;
			// 
			// cbKeypadA
			// 
			this.cbKeypadA.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbKeypadA.AutoSize = true;
			this.cbKeypadA.Location = new System.Drawing.Point(308, 275);
			this.cbKeypadA.Name = "cbKeypadA";
			this.cbKeypadA.Size = new System.Drawing.Size(24, 23);
			this.cbKeypadA.TabIndex = 24;
			this.cbKeypadA.Text = "A";
			this.cbKeypadA.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(155, 61);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(256, 128);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.Text = "linkLabel1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(429, 316);
			this.Controls.Add(this.cbKeypadF);
			this.Controls.Add(this.cbKeypadB);
			this.Controls.Add(this.cbKeypad0);
			this.Controls.Add(this.cbKeypadA);
			this.Controls.Add(this.cbKeypadE);
			this.Controls.Add(this.cbKeypad9);
			this.Controls.Add(this.cbKeypad8);
			this.Controls.Add(this.cbKeypad7);
			this.Controls.Add(this.cbKeypadD);
			this.Controls.Add(this.cbKeypad6);
			this.Controls.Add(this.cbKeypad5);
			this.Controls.Add(this.cbKeypad4);
			this.Controls.Add(this.cbKeypadC);
			this.Controls.Add(this.cbKeypad3);
			this.Controls.Add(this.cbKeypad2);
			this.Controls.Add(this.cbKeypad1);
			this.Controls.Add(this.btnRunToggle);
			this.Controls.Add(this.txtFrameNum);
			this.Controls.Add(this.txtCycleNum);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnStepFrame);
			this.Controls.Add(this.txtFrameCycles);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnStepInstr);
			this.Controls.Add(this.btnLoad);
			this.Name = "MainForm";
			this.Text = "1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnStepInstr;
		private BizHawk.Client.EmuHawk.RetainedViewportPanel pictureBox1;
		private System.Windows.Forms.TextBox txtFrameCycles;
		private System.Windows.Forms.Button btnStepFrame;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtCycleNum;
		private System.Windows.Forms.TextBox txtFrameNum;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.CheckBox btnRunToggle;
		private System.Windows.Forms.CheckBox cbKeypad1;
		private System.Windows.Forms.CheckBox cbKeypad2;
		private System.Windows.Forms.CheckBox cbKeypad3;
		private System.Windows.Forms.CheckBox cbKeypadC;
		private System.Windows.Forms.CheckBox cbKeypadD;
		private System.Windows.Forms.CheckBox cbKeypad6;
		private System.Windows.Forms.CheckBox cbKeypad5;
		private System.Windows.Forms.CheckBox cbKeypad4;
		private System.Windows.Forms.CheckBox cbKeypadE;
		private System.Windows.Forms.CheckBox cbKeypad9;
		private System.Windows.Forms.CheckBox cbKeypad8;
		private System.Windows.Forms.CheckBox cbKeypad7;
		private System.Windows.Forms.CheckBox cbKeypadF;
		private System.Windows.Forms.CheckBox cbKeypadB;
		private System.Windows.Forms.CheckBox cbKeypad0;
		private System.Windows.Forms.CheckBox cbKeypadA;
	}
}

