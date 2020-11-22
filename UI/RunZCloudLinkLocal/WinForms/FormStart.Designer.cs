namespace RunZCloudLinkLocal.WinForms
{
	partial class FormStart
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ButtonStartStop = new System.Windows.Forms.Button();
			this.TextBoxStatus = new System.Windows.Forms.TextBox();
			this.LabelStatus = new System.Windows.Forms.Label();
			this.TextBoxPort = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.TextBoxIp = new System.Windows.Forms.TextBox();
			this.LabelIp = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ButtonStartStop);
			this.groupBox1.Controls.Add(this.TextBoxStatus);
			this.groupBox1.Controls.Add(this.LabelStatus);
			this.groupBox1.Controls.Add(this.TextBoxPort);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.TextBoxIp);
			this.groupBox1.Controls.Add(this.LabelIp);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(278, 106);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Статус севера";
			// 
			// ButtonStartStop
			// 
			this.ButtonStartStop.Location = new System.Drawing.Point(170, 71);
			this.ButtonStartStop.Name = "ButtonStartStop";
			this.ButtonStartStop.Size = new System.Drawing.Size(102, 20);
			this.ButtonStartStop.TabIndex = 6;
			this.ButtonStartStop.Text = "Start/Stop";
			this.ButtonStartStop.UseVisualStyleBackColor = true;
			this.ButtonStartStop.Click += new System.EventHandler(this.ButtonStartStop_Click);
			// 
			// TextBoxStatus
			// 
			this.TextBoxStatus.Location = new System.Drawing.Point(6, 71);
			this.TextBoxStatus.Name = "TextBoxStatus";
			this.TextBoxStatus.ReadOnly = true;
			this.TextBoxStatus.Size = new System.Drawing.Size(158, 20);
			this.TextBoxStatus.TabIndex = 5;
			// 
			// LabelStatus
			// 
			this.LabelStatus.AutoSize = true;
			this.LabelStatus.Location = new System.Drawing.Point(3, 55);
			this.LabelStatus.Name = "LabelStatus";
			this.LabelStatus.Size = new System.Drawing.Size(44, 13);
			this.LabelStatus.TabIndex = 4;
			this.LabelStatus.Text = "Статус:";
			// 
			// TextBoxPort
			// 
			this.TextBoxPort.Location = new System.Drawing.Point(170, 32);
			this.TextBoxPort.Name = "TextBoxPort";
			this.TextBoxPort.Size = new System.Drawing.Size(102, 20);
			this.TextBoxPort.TabIndex = 3;
			this.TextBoxPort.Text = "50000";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(206, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Port";
			// 
			// TextBoxIp
			// 
			this.TextBoxIp.Location = new System.Drawing.Point(6, 32);
			this.TextBoxIp.Name = "TextBoxIp";
			this.TextBoxIp.Size = new System.Drawing.Size(158, 20);
			this.TextBoxIp.TabIndex = 1;
			this.TextBoxIp.Text = "127.0.0.1";
			// 
			// LabelIp
			// 
			this.LabelIp.AutoSize = true;
			this.LabelIp.Location = new System.Drawing.Point(3, 16);
			this.LabelIp.Name = "LabelIp";
			this.LabelIp.Size = new System.Drawing.Size(17, 13);
			this.LabelIp.TabIndex = 0;
			this.LabelIp.Text = "IP";
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(296, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(384, 317);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Текущие подключения";
			// 
			// FormStartServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(695, 352);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "FormStartServer";
			this.Text = "Запуск сервера";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox TextBoxPort;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TextBoxIp;
		private System.Windows.Forms.Label LabelIp;
		private System.Windows.Forms.TextBox TextBoxStatus;
		private System.Windows.Forms.Label LabelStatus;
		private System.Windows.Forms.Button ButtonStartStop;
		private System.Windows.Forms.GroupBox groupBox2;
	}
}