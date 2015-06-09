namespace Smart_radio_controller_windows_forms
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.main_title = new System.Windows.Forms.Label();
            this.main_subtitle = new System.Windows.Forms.Label();
            this.main_status = new System.Windows.Forms.Label();
            this.main_mode_line = new System.Windows.Forms.Label();
            this.main_mode_label = new System.Windows.Forms.Label();
            this.main_mode_on = new System.Windows.Forms.Button();
            this.main_mode_off = new System.Windows.Forms.Button();
            this.main_mode_auto = new System.Windows.Forms.Button();
            this.main_starttijd_picker = new System.Windows.Forms.DateTimePicker();
            this.main_eindtijd_picker = new System.Windows.Forms.DateTimePicker();
            this.main_starttijd_label = new System.Windows.Forms.Label();
            this.main_starttijd_line = new System.Windows.Forms.Label();
            this.main_eindtijd_label = new System.Windows.Forms.Label();
            this.main_eindtijd_line = new System.Windows.Forms.Label();
            this.main_starttijd_button = new System.Windows.Forms.Button();
            this.main_eindtijd_button = new System.Windows.Forms.Button();
            this.main_foto1_picture = new System.Windows.Forms.PictureBox();
            this.main_foto1_label = new System.Windows.Forms.Label();
            this.main_foto1_line = new System.Windows.Forms.Label();
            this.main_foto2_label = new System.Windows.Forms.Label();
            this.main_foto2_line = new System.Windows.Forms.Label();
            this.main_foto2_picture = new System.Windows.Forms.PictureBox();
            this.main_laatsterun = new System.Windows.Forms.Label();
            this.main_laatsterun_time = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.main_foto1_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_foto2_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // main_title
            // 
            this.main_title.AutoSize = true;
            this.main_title.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_title.Location = new System.Drawing.Point(20, 20);
            this.main_title.Name = "main_title";
            this.main_title.Size = new System.Drawing.Size(185, 37);
            this.main_title.TabIndex = 0;
            this.main_title.Text = "Home Control";
            // 
            // main_subtitle
            // 
            this.main_subtitle.AutoSize = true;
            this.main_subtitle.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_subtitle.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.main_subtitle.Location = new System.Drawing.Point(20, 69);
            this.main_subtitle.Name = "main_subtitle";
            this.main_subtitle.Size = new System.Drawing.Size(137, 37);
            this.main_subtitle.TabIndex = 1;
            this.main_subtitle.Text = "Baby radio";
            // 
            // main_status
            // 
            this.main_status.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.main_status.Font = new System.Drawing.Font("Segoe UI Semilight", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_status.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.main_status.Location = new System.Drawing.Point(29, 140);
            this.main_status.Name = "main_status";
            this.main_status.Size = new System.Drawing.Size(164, 164);
            this.main_status.TabIndex = 2;
            this.main_status.Text = "Radio\r\nON";
            this.main_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // main_mode_line
            // 
            this.main_mode_line.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.main_mode_line.Location = new System.Drawing.Point(235, 162);
            this.main_mode_line.Name = "main_mode_line";
            this.main_mode_line.Size = new System.Drawing.Size(429, 2);
            this.main_mode_line.TabIndex = 0;
            // 
            // main_mode_label
            // 
            this.main_mode_label.AutoSize = true;
            this.main_mode_label.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_mode_label.Location = new System.Drawing.Point(232, 140);
            this.main_mode_label.Name = "main_mode_label";
            this.main_mode_label.Size = new System.Drawing.Size(38, 13);
            this.main_mode_label.TabIndex = 3;
            this.main_mode_label.Text = "Mode";
            // 
            // main_mode_on
            // 
            this.main_mode_on.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.main_mode_on.Location = new System.Drawing.Point(235, 175);
            this.main_mode_on.Name = "main_mode_on";
            this.main_mode_on.Size = new System.Drawing.Size(129, 129);
            this.main_mode_on.TabIndex = 6;
            this.main_mode_on.Text = "ON";
            this.main_mode_on.UseVisualStyleBackColor = false;
            // 
            // main_mode_off
            // 
            this.main_mode_off.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.main_mode_off.Location = new System.Drawing.Point(385, 175);
            this.main_mode_off.Name = "main_mode_off";
            this.main_mode_off.Size = new System.Drawing.Size(129, 129);
            this.main_mode_off.TabIndex = 7;
            this.main_mode_off.Text = "OFF";
            this.main_mode_off.UseVisualStyleBackColor = false;
            // 
            // main_mode_auto
            // 
            this.main_mode_auto.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.main_mode_auto.Location = new System.Drawing.Point(535, 175);
            this.main_mode_auto.Name = "main_mode_auto";
            this.main_mode_auto.Size = new System.Drawing.Size(129, 129);
            this.main_mode_auto.TabIndex = 8;
            this.main_mode_auto.Text = "AUTO";
            this.main_mode_auto.UseVisualStyleBackColor = false;
            // 
            // main_starttijd_picker
            // 
            this.main_starttijd_picker.Checked = false;
            this.main_starttijd_picker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.main_starttijd_picker.Location = new System.Drawing.Point(235, 357);
            this.main_starttijd_picker.Name = "main_starttijd_picker";
            this.main_starttijd_picker.ShowUpDown = true;
            this.main_starttijd_picker.Size = new System.Drawing.Size(279, 20);
            this.main_starttijd_picker.TabIndex = 9;
            // 
            // main_eindtijd_picker
            // 
            this.main_eindtijd_picker.Checked = false;
            this.main_eindtijd_picker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.main_eindtijd_picker.Location = new System.Drawing.Point(235, 425);
            this.main_eindtijd_picker.Name = "main_eindtijd_picker";
            this.main_eindtijd_picker.ShowUpDown = true;
            this.main_eindtijd_picker.Size = new System.Drawing.Size(279, 20);
            this.main_eindtijd_picker.TabIndex = 10;
            // 
            // main_starttijd_label
            // 
            this.main_starttijd_label.AutoSize = true;
            this.main_starttijd_label.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_starttijd_label.Location = new System.Drawing.Point(232, 329);
            this.main_starttijd_label.Name = "main_starttijd_label";
            this.main_starttijd_label.Size = new System.Drawing.Size(48, 13);
            this.main_starttijd_label.TabIndex = 12;
            this.main_starttijd_label.Text = "Starttijd";
            // 
            // main_starttijd_line
            // 
            this.main_starttijd_line.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.main_starttijd_line.Location = new System.Drawing.Point(235, 348);
            this.main_starttijd_line.Name = "main_starttijd_line";
            this.main_starttijd_line.Size = new System.Drawing.Size(429, 2);
            this.main_starttijd_line.TabIndex = 11;
            // 
            // main_eindtijd_label
            // 
            this.main_eindtijd_label.AutoSize = true;
            this.main_eindtijd_label.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_eindtijd_label.Location = new System.Drawing.Point(232, 398);
            this.main_eindtijd_label.Name = "main_eindtijd_label";
            this.main_eindtijd_label.Size = new System.Drawing.Size(47, 13);
            this.main_eindtijd_label.TabIndex = 14;
            this.main_eindtijd_label.Text = "Eindtijd";
            // 
            // main_eindtijd_line
            // 
            this.main_eindtijd_line.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.main_eindtijd_line.Location = new System.Drawing.Point(235, 416);
            this.main_eindtijd_line.Name = "main_eindtijd_line";
            this.main_eindtijd_line.Size = new System.Drawing.Size(429, 2);
            this.main_eindtijd_line.TabIndex = 13;
            // 
            // main_starttijd_button
            // 
            this.main_starttijd_button.Location = new System.Drawing.Point(535, 359);
            this.main_starttijd_button.Name = "main_starttijd_button";
            this.main_starttijd_button.Size = new System.Drawing.Size(129, 20);
            this.main_starttijd_button.TabIndex = 15;
            this.main_starttijd_button.Text = "Stel in";
            this.main_starttijd_button.UseVisualStyleBackColor = true;
            // 
            // main_eindtijd_button
            // 
            this.main_eindtijd_button.Location = new System.Drawing.Point(535, 425);
            this.main_eindtijd_button.Name = "main_eindtijd_button";
            this.main_eindtijd_button.Size = new System.Drawing.Size(129, 20);
            this.main_eindtijd_button.TabIndex = 16;
            this.main_eindtijd_button.Text = "Stel in";
            this.main_eindtijd_button.UseVisualStyleBackColor = true;
            // 
            // main_foto1_picture
            // 
            this.main_foto1_picture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.main_foto1_picture.Location = new System.Drawing.Point(698, 175);
            this.main_foto1_picture.Name = "main_foto1_picture";
            this.main_foto1_picture.Size = new System.Drawing.Size(129, 129);
            this.main_foto1_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.main_foto1_picture.TabIndex = 17;
            this.main_foto1_picture.TabStop = false;
            // 
            // main_foto1_label
            // 
            this.main_foto1_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.main_foto1_label.AutoSize = true;
            this.main_foto1_label.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_foto1_label.Location = new System.Drawing.Point(695, 140);
            this.main_foto1_label.Name = "main_foto1_label";
            this.main_foto1_label.Size = new System.Drawing.Size(40, 13);
            this.main_foto1_label.TabIndex = 19;
            this.main_foto1_label.Text = "Foto 1";
            // 
            // main_foto1_line
            // 
            this.main_foto1_line.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.main_foto1_line.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.main_foto1_line.Location = new System.Drawing.Point(698, 162);
            this.main_foto1_line.Name = "main_foto1_line";
            this.main_foto1_line.Size = new System.Drawing.Size(129, 2);
            this.main_foto1_line.TabIndex = 18;
            // 
            // main_foto2_label
            // 
            this.main_foto2_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.main_foto2_label.AutoSize = true;
            this.main_foto2_label.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_foto2_label.Location = new System.Drawing.Point(695, 326);
            this.main_foto2_label.Name = "main_foto2_label";
            this.main_foto2_label.Size = new System.Drawing.Size(40, 13);
            this.main_foto2_label.TabIndex = 22;
            this.main_foto2_label.Text = "Foto 2";
            // 
            // main_foto2_line
            // 
            this.main_foto2_line.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.main_foto2_line.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.main_foto2_line.Location = new System.Drawing.Point(698, 347);
            this.main_foto2_line.Name = "main_foto2_line";
            this.main_foto2_line.Size = new System.Drawing.Size(129, 2);
            this.main_foto2_line.TabIndex = 21;
            // 
            // main_foto2_picture
            // 
            this.main_foto2_picture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.main_foto2_picture.Location = new System.Drawing.Point(698, 361);
            this.main_foto2_picture.Name = "main_foto2_picture";
            this.main_foto2_picture.Size = new System.Drawing.Size(129, 129);
            this.main_foto2_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.main_foto2_picture.TabIndex = 20;
            this.main_foto2_picture.TabStop = false;
            // 
            // main_laatsterun
            // 
            this.main_laatsterun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.main_laatsterun.Font = new System.Drawing.Font("Segoe UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_laatsterun.ForeColor = System.Drawing.SystemColors.Control;
            this.main_laatsterun.Location = new System.Drawing.Point(655, 20);
            this.main_laatsterun.Name = "main_laatsterun";
            this.main_laatsterun.Size = new System.Drawing.Size(172, 37);
            this.main_laatsterun.TabIndex = 23;
            this.main_laatsterun.Text = "Laatste run:";
            this.main_laatsterun.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // main_laatsterun_time
            // 
            this.main_laatsterun_time.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_laatsterun_time.Font = new System.Drawing.Font("Segoe UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_laatsterun_time.ForeColor = System.Drawing.SystemColors.Control;
            this.main_laatsterun_time.Location = new System.Drawing.Point(715, 57);
            this.main_laatsterun_time.Name = "main_laatsterun_time";
            this.main_laatsterun_time.Size = new System.Drawing.Size(112, 37);
            this.main_laatsterun_time.TabIndex = 24;
            this.main_laatsterun_time.Text = "nooit";
            this.main_laatsterun_time.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(853, 514);
            this.Controls.Add(this.main_laatsterun_time);
            this.Controls.Add(this.main_laatsterun);
            this.Controls.Add(this.main_foto2_label);
            this.Controls.Add(this.main_foto2_line);
            this.Controls.Add(this.main_foto2_picture);
            this.Controls.Add(this.main_foto1_label);
            this.Controls.Add(this.main_foto1_line);
            this.Controls.Add(this.main_foto1_picture);
            this.Controls.Add(this.main_eindtijd_button);
            this.Controls.Add(this.main_starttijd_button);
            this.Controls.Add(this.main_eindtijd_label);
            this.Controls.Add(this.main_eindtijd_line);
            this.Controls.Add(this.main_starttijd_label);
            this.Controls.Add(this.main_starttijd_line);
            this.Controls.Add(this.main_eindtijd_picker);
            this.Controls.Add(this.main_starttijd_picker);
            this.Controls.Add(this.main_mode_auto);
            this.Controls.Add(this.main_mode_off);
            this.Controls.Add(this.main_mode_on);
            this.Controls.Add(this.main_mode_label);
            this.Controls.Add(this.main_mode_line);
            this.Controls.Add(this.main_status);
            this.Controls.Add(this.main_subtitle);
            this.Controls.Add(this.main_title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Smart baby radio";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.main_foto1_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_foto2_picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label main_title;
        private System.Windows.Forms.Label main_subtitle;
        private System.Windows.Forms.Label main_status;
        private System.Windows.Forms.Label main_mode_line;
        private System.Windows.Forms.Label main_mode_label;
        private System.Windows.Forms.Button main_mode_on;
        private System.Windows.Forms.Button main_mode_off;
        private System.Windows.Forms.Button main_mode_auto;
        private System.Windows.Forms.DateTimePicker main_starttijd_picker;
        private System.Windows.Forms.DateTimePicker main_eindtijd_picker;
        private System.Windows.Forms.Label main_starttijd_label;
        private System.Windows.Forms.Label main_starttijd_line;
        private System.Windows.Forms.Label main_eindtijd_label;
        private System.Windows.Forms.Label main_eindtijd_line;
        private System.Windows.Forms.Button main_starttijd_button;
        private System.Windows.Forms.Button main_eindtijd_button;
        private System.Windows.Forms.PictureBox main_foto1_picture;
        private System.Windows.Forms.Label main_foto1_label;
        private System.Windows.Forms.Label main_foto1_line;
        private System.Windows.Forms.Label main_foto2_label;
        private System.Windows.Forms.Label main_foto2_line;
        private System.Windows.Forms.PictureBox main_foto2_picture;
        private System.Windows.Forms.Label main_laatsterun;
        private System.Windows.Forms.Label main_laatsterun_time;
    }
}

