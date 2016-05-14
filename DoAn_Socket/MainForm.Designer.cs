namespace DoAn_Socket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbIntroduce = new System.Windows.Forms.Label();
            this.sttProgress = new System.Windows.Forms.StatusStrip();
            this.sttlbProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbBlacklist = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.sttProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(55, 38);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(48, 20);
            this.txtPort.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(117, 36);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(40, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(163, 36);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(42, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(14, 41);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(29, 13);
            this.lbPort.TabIndex = 4;
            this.lbPort.Text = "Port:";
            // 
            // lbIntroduce
            // 
            this.lbIntroduce.AutoSize = true;
            this.lbIntroduce.Location = new System.Drawing.Point(12, 9);
            this.lbIntroduce.Name = "lbIntroduce";
            this.lbIntroduce.Size = new System.Drawing.Size(193, 13);
            this.lbIntroduce.TabIndex = 5;
            this.lbIntroduce.Text = "Chương trình tạo Proxy Server đơn giản";
            // 
            // sttProgress
            // 
            this.sttProgress.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sttlbProgress});
            this.sttProgress.Location = new System.Drawing.Point(0, 254);
            this.sttProgress.Name = "sttProgress";
            this.sttProgress.Size = new System.Drawing.Size(226, 22);
            this.sttProgress.TabIndex = 6;
            this.sttProgress.Text = "Sẵn sàng!";
            // 
            // sttlbProgress
            // 
            this.sttlbProgress.Name = "sttlbProgress";
            this.sttlbProgress.Size = new System.Drawing.Size(39, 17);
            this.sttlbProgress.Text = "Ready";
            // 
            // lbBlacklist
            // 
            this.lbBlacklist.FormattingEnabled = true;
            this.lbBlacklist.Location = new System.Drawing.Point(21, 114);
            this.lbBlacklist.Name = "lbBlacklist";
            this.lbBlacklist.Size = new System.Drawing.Size(120, 121);
            this.lbBlacklist.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(147, 86);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(147, 115);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(58, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(21, 88);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(120, 20);
            this.txtAdd.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 276);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbBlacklist);
            this.Controls.Add(this.sttProgress);
            this.Controls.Add(this.lbIntroduce);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Proxy Server";
            this.sttProgress.ResumeLayout(false);
            this.sttProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbIntroduce;
        private System.Windows.Forms.StatusStrip sttProgress;
        private System.Windows.Forms.ToolStripStatusLabel sttlbProgress;
        private System.Windows.Forms.ListBox lbBlacklist;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtAdd;
    }
}

