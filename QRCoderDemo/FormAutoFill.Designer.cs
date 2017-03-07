namespace QRCoderDemo
{
    partial class FormAutoFill
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutoFill));
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonUseOtp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "WPA",
            "WEP",
            "None"});
            this.comboBoxType.Location = new System.Drawing.Point(87, 19);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(125, 21);
            this.comboBoxType.TabIndex = 3;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(24, 22);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(31, 13);
            this.labelType.TabIndex = 4;
            this.labelType.Text = "Type";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(447, 528);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Use";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonUseOtp
            // 
            this.buttonUseOtp.Location = new System.Drawing.Point(447, 499);
            this.buttonUseOtp.Name = "buttonUseOtp";
            this.buttonUseOtp.Size = new System.Drawing.Size(75, 23);
            this.buttonUseOtp.TabIndex = 5;
            this.buttonUseOtp.Text = "Use OTP";
            this.buttonUseOtp.Click += new System.EventHandler(this.buttonUseOTP_Click);
            // 
            // FormAutoFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 563);
            this.Controls.Add(this.buttonUseOtp);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.comboBoxType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(559, 602);
            this.Name = "FormAutoFill";
            this.Text = "QRCoder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonUseOtp;
    }
}

