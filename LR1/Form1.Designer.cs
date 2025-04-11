using System.Windows.Forms;

namespace IoTRobotWorldUDPServer
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RemoteIPTextBox = new System.Windows.Forms.TextBox();
            this.RemotePortTextBox = new System.Windows.Forms.TextBox();
            this.LocalPortTextBox = new System.Windows.Forms.TextBox();
            this.LocalIPTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.UDPMessageTextBox = new System.Windows.Forms.TextBox();
            this.SendUDPMessageButton = new System.Windows.Forms.Button();
            this.ReportListBox = new System.Windows.Forms.ListBox();
            this.StartStopUDPClientButton = new System.Windows.Forms.Button();
            this.UDPRegularSenderTimer = new System.Windows.Forms.Timer(this.components);
            this.RegularUDPSendCheckBox = new System.Windows.Forms.CheckBox();
            this.AppendLFSymbolCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.FrameName = new System.Windows.Forms.Label();
            this.PrewFrame = new System.Windows.Forms.Button();
            this.NextFrame = new System.Windows.Forms.Button();
            this.ClearFrame = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDownClusters = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClusters)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remote IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Remote Port";
            // 
            // RemoteIPTextBox
            // 
            this.RemoteIPTextBox.Location = new System.Drawing.Point(72, 6);
            this.RemoteIPTextBox.Name = "RemoteIPTextBox";
            this.RemoteIPTextBox.Size = new System.Drawing.Size(100, 20);
            this.RemoteIPTextBox.TabIndex = 2;
            this.RemoteIPTextBox.Text = "127.0.0.1";
            // 
            // RemotePortTextBox
            // 
            this.RemotePortTextBox.Location = new System.Drawing.Point(72, 38);
            this.RemotePortTextBox.Name = "RemotePortTextBox";
            this.RemotePortTextBox.Size = new System.Drawing.Size(100, 20);
            this.RemotePortTextBox.TabIndex = 3;
            this.RemotePortTextBox.Text = "8888";
            this.RemotePortTextBox.TextChanged += new System.EventHandler(this.RemotePortTextBox_TextChanged);
            // 
            // LocalPortTextBox
            // 
            this.LocalPortTextBox.Location = new System.Drawing.Point(240, 38);
            this.LocalPortTextBox.Name = "LocalPortTextBox";
            this.LocalPortTextBox.Size = new System.Drawing.Size(100, 20);
            this.LocalPortTextBox.TabIndex = 7;
            this.LocalPortTextBox.Text = "2368";
            // 
            // LocalIPTextBox
            // 
            this.LocalIPTextBox.Location = new System.Drawing.Point(240, 6);
            this.LocalIPTextBox.Name = "LocalIPTextBox";
            this.LocalIPTextBox.Size = new System.Drawing.Size(100, 20);
            this.LocalIPTextBox.TabIndex = 6;
            this.LocalIPTextBox.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Local Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Local IP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Message";
            // 
            // UDPMessageTextBox
            // 
            this.UDPMessageTextBox.Location = new System.Drawing.Point(70, 95);
            this.UDPMessageTextBox.Name = "UDPMessageTextBox";
            this.UDPMessageTextBox.Size = new System.Drawing.Size(249, 20);
            this.UDPMessageTextBox.TabIndex = 9;
            this.UDPMessageTextBox.Text = "{\"N\":1, \"M\":0, \"F\":50, \"B\":10, \"T\":0}";
            // 
            // SendUDPMessageButton
            // 
            this.SendUDPMessageButton.Location = new System.Drawing.Point(70, 117);
            this.SendUDPMessageButton.Name = "SendUDPMessageButton";
            this.SendUDPMessageButton.Size = new System.Drawing.Size(75, 28);
            this.SendUDPMessageButton.TabIndex = 10;
            this.SendUDPMessageButton.Text = "Send";
            this.SendUDPMessageButton.UseVisualStyleBackColor = true;
            this.SendUDPMessageButton.Click += new System.EventHandler(this.SendUDPMessageButton_Click);
            // 
            // ReportListBox
            // 
            this.ReportListBox.FormattingEnabled = true;
            this.ReportListBox.Location = new System.Drawing.Point(16, 151);
            this.ReportListBox.Name = "ReportListBox";
            this.ReportListBox.ScrollAlwaysVisible = true;
            this.ReportListBox.Size = new System.Drawing.Size(377, 121);
            this.ReportListBox.TabIndex = 11;
            // 
            // StartStopUDPClientButton
            // 
            this.StartStopUDPClientButton.Location = new System.Drawing.Point(347, 11);
            this.StartStopUDPClientButton.Name = "StartStopUDPClientButton";
            this.StartStopUDPClientButton.Size = new System.Drawing.Size(54, 42);
            this.StartStopUDPClientButton.TabIndex = 12;
            this.StartStopUDPClientButton.Text = "Start";
            this.StartStopUDPClientButton.UseVisualStyleBackColor = true;
            this.StartStopUDPClientButton.Click += new System.EventHandler(this.StartStopUDPClientButton_Click);
            // 
            // UDPRegularSenderTimer
            // 
            this.UDPRegularSenderTimer.Interval = 1000;
            this.UDPRegularSenderTimer.Tick += new System.EventHandler(this.UDPRegularSenderTimer_Tick);
            // 
            // RegularUDPSendCheckBox
            // 
            this.RegularUDPSendCheckBox.AutoSize = true;
            this.RegularUDPSendCheckBox.Location = new System.Drawing.Point(194, 128);
            this.RegularUDPSendCheckBox.Name = "RegularUDPSendCheckBox";
            this.RegularUDPSendCheckBox.Size = new System.Drawing.Size(134, 17);
            this.RegularUDPSendCheckBox.TabIndex = 13;
            this.RegularUDPSendCheckBox.Text = "Send message regular ";
            this.RegularUDPSendCheckBox.UseVisualStyleBackColor = true;
            this.RegularUDPSendCheckBox.CheckedChanged += new System.EventHandler(this.RegularUDPSendCheckBox_CheckedChanged);
            // 
            // AppendLFSymbolCheckBox
            // 
            this.AppendLFSymbolCheckBox.AutoSize = true;
            this.AppendLFSymbolCheckBox.Checked = true;
            this.AppendLFSymbolCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AppendLFSymbolCheckBox.Location = new System.Drawing.Point(324, 97);
            this.AppendLFSymbolCheckBox.Name = "AppendLFSymbolCheckBox";
            this.AppendLFSymbolCheckBox.Size = new System.Drawing.Size(78, 17);
            this.AppendLFSymbolCheckBox.TabIndex = 14;
            this.AppendLFSymbolCheckBox.Text = "Append LF";
            this.AppendLFSymbolCheckBox.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 20);
            this.textBox1.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Filter Input";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(406, 11);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(114, 264);
            this.listBox1.TabIndex = 18;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(609, 200);
            this.listBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox2.Name = "listBox2";
            this.listBox2.ScrollAlwaysVisible = true;
            this.listBox2.Size = new System.Drawing.Size(169, 404);
            this.listBox2.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(829, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 259);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(523, 10);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(301, 260);
            this.dataGridView1.TabIndex = 20;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(347, 59);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(55, 20);
            this.numericUpDown1.TabIndex = 21;
            this.numericUpDown1.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // FrameName
            // 
            this.FrameName.AutoSize = true;
            this.FrameName.Location = new System.Drawing.Point(1002, 275);
            this.FrameName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FrameName.Name = "FrameName";
            this.FrameName.Size = new System.Drawing.Size(64, 13);
            this.FrameName.TabIndex = 22;
            this.FrameName.Text = "FrameName";
            // 
            // PrewFrame
            // 
            this.PrewFrame.Location = new System.Drawing.Point(829, 272);
            this.PrewFrame.Margin = new System.Windows.Forms.Padding(2);
            this.PrewFrame.Name = "PrewFrame";
            this.PrewFrame.Size = new System.Drawing.Size(50, 18);
            this.PrewFrame.TabIndex = 23;
            this.PrewFrame.Text = "<";
            this.PrewFrame.UseVisualStyleBackColor = true;
            this.PrewFrame.Click += new System.EventHandler(this.PrewFrame_Click);
            // 
            // NextFrame
            // 
            this.NextFrame.Location = new System.Drawing.Point(1179, 274);
            this.NextFrame.Margin = new System.Windows.Forms.Padding(2);
            this.NextFrame.Name = "NextFrame";
            this.NextFrame.Size = new System.Drawing.Size(50, 18);
            this.NextFrame.TabIndex = 24;
            this.NextFrame.Text = ">";
            this.NextFrame.UseVisualStyleBackColor = true;
            this.NextFrame.Click += new System.EventHandler(this.NextFrame_Click);
            // 
            // ClearFrame
            // 
            this.ClearFrame.Location = new System.Drawing.Point(1233, 274);
            this.ClearFrame.Margin = new System.Windows.Forms.Padding(2);
            this.ClearFrame.Name = "ClearFrame";
            this.ClearFrame.Size = new System.Drawing.Size(75, 19);
            this.ClearFrame.TabIndex = 25;
            this.ClearFrame.Text = "ClearFrame";
            this.ClearFrame.UseVisualStyleBackColor = true;
            this.ClearFrame.Click += new System.EventHandler(this.ClearFrame_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(691, 275);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 17);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "LIVE";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numericUpDownClusters
            // 
            this.numericUpDownClusters.Location = new System.Drawing.Point(606, 273);
            this.numericUpDownClusters.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownClusters.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownClusters.Name = "numericUpDownClusters";
            this.numericUpDownClusters.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownClusters.TabIndex = 27;
            this.numericUpDownClusters.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownClusters.ValueChanged += new System.EventHandler(this.numericUpDownClusters_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(474, 274);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "колличество кластеров";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(1233, 11);
            this.listBox3.Margin = new System.Windows.Forms.Padding(2);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(201, 251);
            this.listBox3.TabIndex = 29;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(1438, 11);
            this.listBox4.Margin = new System.Windows.Forms.Padding(2);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(201, 251);
            this.listBox4.TabIndex = 31;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(746, 275);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(47, 17);
            this.checkBox2.TabIndex = 32;
            this.checkBox2.Text = "Wall";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1650, 322);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDownClusters);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ClearFrame);
            this.Controls.Add(this.NextFrame);
            this.Controls.Add(this.PrewFrame);
            this.Controls.Add(this.FrameName);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AppendLFSymbolCheckBox);
            this.Controls.Add(this.RegularUDPSendCheckBox);
            this.Controls.Add(this.StartStopUDPClientButton);
            this.Controls.Add(this.ReportListBox);
            this.Controls.Add(this.SendUDPMessageButton);
            this.Controls.Add(this.UDPMessageTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LocalPortTextBox);
            this.Controls.Add(this.LocalIPTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RemotePortTextBox);
            this.Controls.Add(this.RemoteIPTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Lyachov Alexandr";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClusters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RemoteIPTextBox;
        private System.Windows.Forms.TextBox RemotePortTextBox;
        private System.Windows.Forms.TextBox LocalPortTextBox;
        private System.Windows.Forms.TextBox LocalIPTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox UDPMessageTextBox;
        private System.Windows.Forms.Button SendUDPMessageButton;
        private System.Windows.Forms.ListBox ReportListBox;
        private System.Windows.Forms.Button StartStopUDPClientButton;
        private System.Windows.Forms.Timer UDPRegularSenderTimer;
        private System.Windows.Forms.CheckBox RegularUDPSendCheckBox;
        private System.Windows.Forms.CheckBox AppendLFSymbolCheckBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ListBox listBox1;
        private ListBox listBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label FrameName;
        private System.Windows.Forms.Button PrewFrame;
        private System.Windows.Forms.Button NextFrame;
        private System.Windows.Forms.Button ClearFrame;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownClusters;
        private System.Windows.Forms.Label label7;
        private ListBox listBox3;
        private ListBox listBox4;
        private CheckBox checkBox2;
    }
}

