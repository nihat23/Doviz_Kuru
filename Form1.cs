using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;

namespace Döviz_Kuru
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosyam = new XmlDocument();
            xmldosyam.Load(bugun);

            DateTime tarih = Convert.ToDateTime(xmldosyam.SelectSingleNode("Tarih_Date").Attributes["Tarih"].Value);
            label9Tarih.Text = tarih.ToLongDateString() + "   Saat 15:30 güncel ";

            string D_Alis = xmldosyam.SelectSingleNode("Tarih_Date /Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            label5DAlis.Text = D_Alis;

            string D_Satis = xmldosyam.SelectSingleNode("Tarih_Date /Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            label6DSatis.Text = D_Satis;

            string EURO_Alis = xmldosyam.SelectSingleNode("Tarih_Date /Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            label7EAlis.Text = EURO_Alis;

            string EURO_Satis = xmldosyam.SelectSingleNode("Tarih_Date /Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            label8ESatis.Text = EURO_Satis;

        }

        double kur, miktar, tutar, kalan;

        private void label6DSatis_Click(object sender, EventArgs e)
        {
            textBox1Kur.Text = label6DSatis.Text;
        }

        private void label7EAlis_Click(object sender, EventArgs e)
        {
            textBox1Kur.Text = label7EAlis.Text;
        }

        private void textBox2Miktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 126 || e.KeyChar < 58)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/n.beyi");
        }

        private void label9Tarih_Click(object sender, EventArgs e)
        {

        }

        private void label8ESatis_Click(object sender, EventArgs e)
        {
            textBox1Kur.Text = label8ESatis.Text;
        }

        private void label5DAlis_Click(object sender, EventArgs e)
        {
            textBox1Kur.Text = label5DAlis.Text;
        }

        private void button1Hesapla_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1Kur.Text != "" && textBox2Miktar.Text != "")
                {
                    kur = Convert.ToDouble(textBox1Kur.Text);
                    miktar = Convert.ToDouble(textBox2Miktar.Text);
                    tutar = kur * miktar;
                    textBox3Tutar.Text = tutar.ToString("N");
                }
                else
                {
                    MessageBox.Show("Lüffen Deger Giriniz..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Uygun Deger Giriniz..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            
            
        }
    }
}
