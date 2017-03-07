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
            PayloadGenerator.WiFi pg = new PayloadGenerator.WiFi("wifiname", "Password", PayloadGenerator.WiFi.Authentication.WPA);
            ResultText = pg.ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}
