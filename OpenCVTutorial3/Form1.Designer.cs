namespace OpenCVTutorial3
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonContours = new System.Windows.Forms.RadioButton();
            this.radioButtonPerspective = new System.Windows.Forms.RadioButton();
            this.radioButtonMostOuter = new System.Windows.Forms.RadioButton();
            this.radioButtonOuteBox = new System.Windows.Forms.RadioButton();
            this.radioButtonCanny = new System.Windows.Forms.RadioButton();
            this.radioButtonBin = new System.Windows.Forms.RadioButton();
            this.radioButtonSrc = new System.Windows.Forms.RadioButton();
            this.buttonStart2 = new System.Windows.Forms.Button();
            this.buttonStart3 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "button1";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(113, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 767);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1101, 743);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonContours);
            this.groupBox1.Controls.Add(this.radioButtonPerspective);
            this.groupBox1.Controls.Add(this.radioButtonMostOuter);
            this.groupBox1.Controls.Add(this.radioButtonOuteBox);
            this.groupBox1.Controls.Add(this.radioButtonCanny);
            this.groupBox1.Controls.Add(this.radioButtonBin);
            this.groupBox1.Controls.Add(this.radioButtonSrc);
            this.groupBox1.Location = new System.Drawing.Point(12, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 178);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TYPE";
            // 
            // radioButtonContours
            // 
            this.radioButtonContours.AutoSize = true;
            this.radioButtonContours.Location = new System.Drawing.Point(7, 146);
            this.radioButtonContours.Name = "radioButtonContours";
            this.radioButtonContours.Size = new System.Drawing.Size(72, 16);
            this.radioButtonContours.TabIndex = 0;
            this.radioButtonContours.TabStop = true;
            this.radioButtonContours.Text = "contours";
            this.radioButtonContours.UseVisualStyleBackColor = true;
            this.radioButtonContours.CheckedChanged += new System.EventHandler(this.radioButtonContours_CheckedChanged);
            // 
            // radioButtonPerspective
            // 
            this.radioButtonPerspective.AutoSize = true;
            this.radioButtonPerspective.Location = new System.Drawing.Point(7, 124);
            this.radioButtonPerspective.Name = "radioButtonPerspective";
            this.radioButtonPerspective.Size = new System.Drawing.Size(88, 16);
            this.radioButtonPerspective.TabIndex = 5;
            this.radioButtonPerspective.TabStop = true;
            this.radioButtonPerspective.Text = "perspective";
            this.radioButtonPerspective.UseVisualStyleBackColor = true;
            this.radioButtonPerspective.CheckedChanged += new System.EventHandler(this.radioButtonPerspective_CheckedChanged);
            // 
            // radioButtonMostOuter
            // 
            this.radioButtonMostOuter.AutoSize = true;
            this.radioButtonMostOuter.Location = new System.Drawing.Point(6, 102);
            this.radioButtonMostOuter.Name = "radioButtonMostOuter";
            this.radioButtonMostOuter.Size = new System.Drawing.Size(44, 16);
            this.radioButtonMostOuter.TabIndex = 4;
            this.radioButtonMostOuter.TabStop = true;
            this.radioButtonMostOuter.Text = "box";
            this.radioButtonMostOuter.UseVisualStyleBackColor = true;
            this.radioButtonMostOuter.CheckedChanged += new System.EventHandler(this.radioButtonMostOuter_CheckedChanged);
            // 
            // radioButtonOuteBox
            // 
            this.radioButtonOuteBox.AutoSize = true;
            this.radioButtonOuteBox.Location = new System.Drawing.Point(6, 80);
            this.radioButtonOuteBox.Name = "radioButtonOuteBox";
            this.radioButtonOuteBox.Size = new System.Drawing.Size(72, 16);
            this.radioButtonOuteBox.TabIndex = 3;
            this.radioButtonOuteBox.TabStop = true;
            this.radioButtonOuteBox.Text = "outerbox";
            this.radioButtonOuteBox.UseVisualStyleBackColor = true;
            this.radioButtonOuteBox.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButtonCanny
            // 
            this.radioButtonCanny.AutoSize = true;
            this.radioButtonCanny.Location = new System.Drawing.Point(6, 58);
            this.radioButtonCanny.Name = "radioButtonCanny";
            this.radioButtonCanny.Size = new System.Drawing.Size(58, 16);
            this.radioButtonCanny.TabIndex = 2;
            this.radioButtonCanny.TabStop = true;
            this.radioButtonCanny.Text = "canny";
            this.radioButtonCanny.UseVisualStyleBackColor = true;
            this.radioButtonCanny.CheckedChanged += new System.EventHandler(this.radioButtonCanny_CheckedChanged);
            // 
            // radioButtonBin
            // 
            this.radioButtonBin.AutoSize = true;
            this.radioButtonBin.Location = new System.Drawing.Point(6, 36);
            this.radioButtonBin.Name = "radioButtonBin";
            this.radioButtonBin.Size = new System.Drawing.Size(40, 16);
            this.radioButtonBin.TabIndex = 1;
            this.radioButtonBin.TabStop = true;
            this.radioButtonBin.Text = "bin";
            this.radioButtonBin.UseVisualStyleBackColor = true;
            this.radioButtonBin.CheckedChanged += new System.EventHandler(this.radioButtonBin_CheckedChanged);
            // 
            // radioButtonSrc
            // 
            this.radioButtonSrc.AutoSize = true;
            this.radioButtonSrc.Location = new System.Drawing.Point(7, 14);
            this.radioButtonSrc.Name = "radioButtonSrc";
            this.radioButtonSrc.Size = new System.Drawing.Size(41, 16);
            this.radioButtonSrc.TabIndex = 0;
            this.radioButtonSrc.TabStop = true;
            this.radioButtonSrc.Text = "src";
            this.radioButtonSrc.UseVisualStyleBackColor = true;
            this.radioButtonSrc.CheckedChanged += new System.EventHandler(this.radioButtonSrc_CheckedChanged);
            // 
            // buttonStart2
            // 
            this.buttonStart2.Location = new System.Drawing.Point(12, 41);
            this.buttonStart2.Name = "buttonStart2";
            this.buttonStart2.Size = new System.Drawing.Size(75, 23);
            this.buttonStart2.TabIndex = 3;
            this.buttonStart2.Text = "button2";
            this.buttonStart2.UseVisualStyleBackColor = true;
            this.buttonStart2.Click += new System.EventHandler(this.buttonStart2_Click);
            // 
            // buttonStart3
            // 
            this.buttonStart3.Location = new System.Drawing.Point(12, 70);
            this.buttonStart3.Name = "buttonStart3";
            this.buttonStart3.Size = new System.Drawing.Size(75, 23);
            this.buttonStart3.TabIndex = 4;
            this.buttonStart3.Text = "button3";
            this.buttonStart3.UseVisualStyleBackColor = true;
            this.buttonStart3.Click += new System.EventHandler(this.buttonStart3_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 328);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 791);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.buttonStart3);
            this.Controls.Add(this.buttonStart2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonBin;
        private System.Windows.Forms.RadioButton radioButtonSrc;
        private System.Windows.Forms.RadioButton radioButtonCanny;
        private System.Windows.Forms.RadioButton radioButtonOuteBox;
        private System.Windows.Forms.RadioButton radioButtonMostOuter;
        private System.Windows.Forms.RadioButton radioButtonPerspective;
        private System.Windows.Forms.RadioButton radioButtonContours;
        private System.Windows.Forms.Button buttonStart2;
        private System.Windows.Forms.Button buttonStart3;
        private System.Windows.Forms.Button btnClear;
    }
}

