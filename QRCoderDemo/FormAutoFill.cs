using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QRCoder;
using System.Drawing.Imaging;
using System.IO;

namespace QRCoderDemo
{
    public partial class FormAutoFill : Form
    {
        public FormAutoFill()
        {
            InitializeComponent();

            this.ResultText = string.Empty;
            this.comboBoxType.Text = "WPA";
        }


        public string ResultText { get; set; }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            PayloadGenerator.WiFi.Authentication auth;
            if( !Enum.TryParse<PayloadGenerator.WiFi.Authentication>(this.comboBoxType.Text, true, out auth))
            {
                auth = PayloadGenerator.WiFi.Authentication.nopass;
            }

            PayloadGenerator.WiFi pg = new PayloadGenerator.WiFi("wifiname", "Password", auth);
            ResultText = pg.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void buttonUseOTP_Click(object sender, EventArgs e)
        {
            PayloadGenerator.OneTimePassword pg = new PayloadGenerator.OneTimePassword
            {
                Secret = "pwq6 5q55",
                Issuer = "Google",
                Label = "test@google.com",
            };
            ResultText = pg.ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}
