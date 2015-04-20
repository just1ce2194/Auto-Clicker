namespace AutoClicker_by_just1ce
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.StartRecord_button = new System.Windows.Forms.Button();
            this.label_cur_position = new System.Windows.Forms.Label();
            this.label_pos_info = new System.Windows.Forms.Label();
            this.label_color = new System.Windows.Forms.Label();
            this.visualStyler1 = new SkinSoft.VisualStyler.VisualStyler(this.components);
            this.Play_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.StopRecord_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartRecord_button
            // 
            this.StartRecord_button.Location = new System.Drawing.Point(274, 10);
            this.StartRecord_button.Name = "StartRecord_button";
            this.StartRecord_button.Size = new System.Drawing.Size(75, 23);
            this.StartRecord_button.TabIndex = 2;
            this.StartRecord_button.Text = "Start Record";
            this.StartRecord_button.UseVisualStyleBackColor = true;
            this.StartRecord_button.Click += new System.EventHandler(this.StartRecord_button_Click);
            // 
            // label_cur_position
            // 
            this.label_cur_position.AutoSize = true;
            this.label_cur_position.Location = new System.Drawing.Point(131, 127);
            this.label_cur_position.Name = "label_cur_position";
            this.label_cur_position.Size = new System.Drawing.Size(92, 13);
            this.label_cur_position.TabIndex = 4;
            this.label_cur_position.Text = "label_cur_position";
            // 
            // label_pos_info
            // 
            this.label_pos_info.AutoSize = true;
            this.label_pos_info.Location = new System.Drawing.Point(12, 127);
            this.label_pos_info.Name = "label_pos_info";
            this.label_pos_info.Size = new System.Drawing.Size(113, 13);
            this.label_pos_info.TabIndex = 5;
            this.label_pos_info.Text = "Координаты курсора";
            // 
            // label_color
            // 
            this.label_color.Location = new System.Drawing.Point(229, 115);
            this.label_color.Name = "label_color";
            this.label_color.Size = new System.Drawing.Size(25, 25);
            this.label_color.TabIndex = 6;
            this.label_color.Text = "   ";
            // 
            // visualStyler1
            // 
            this.visualStyler1.HostForm = this;
            this.visualStyler1.License = ((SkinSoft.VisualStyler.Licensing.VisualStylerLicense)(resources.GetObject("visualStyler1.License")));
            this.visualStyler1.LoadVisualStyle(null, "Amakrits.vssf");
            // 
            // Play_button
            // 
            this.Play_button.Location = new System.Drawing.Point(274, 68);
            this.Play_button.Name = "Play_button";
            this.Play_button.Size = new System.Drawing.Size(75, 23);
            this.Play_button.TabIndex = 11;
            this.Play_button.Text = "Play";
            this.Play_button.UseVisualStyleBackColor = true;
            this.Play_button.Click += new System.EventHandler(this.Play_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 15;
            // 
            // StopRecord_btn
            // 
            this.StopRecord_btn.Location = new System.Drawing.Point(274, 39);
            this.StopRecord_btn.Name = "StopRecord_btn";
            this.StopRecord_btn.Size = new System.Drawing.Size(75, 23);
            this.StopRecord_btn.TabIndex = 16;
            this.StopRecord_btn.Text = "Stop Record";
            this.StopRecord_btn.UseVisualStyleBackColor = true;
            this.StopRecord_btn.Click += new System.EventHandler(this.StopRecord_btn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 152);
            this.Controls.Add(this.StopRecord_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Play_button);
            this.Controls.Add(this.label_color);
            this.Controls.Add(this.label_pos_info);
            this.Controls.Add(this.label_cur_position);
            this.Controls.Add(this.StartRecord_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoClicker by just1ce";
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button StartRecord_button;
        private System.Windows.Forms.Label label_cur_position;
        private System.Windows.Forms.Label label_pos_info;
        private System.Windows.Forms.Label label_color;
        private SkinSoft.VisualStyler.VisualStyler visualStyler1;
        private System.Windows.Forms.Button Play_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StopRecord_btn;
    }
}