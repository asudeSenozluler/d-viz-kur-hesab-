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

namespace döviz_kur_hesabı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://tcmb.gov.tr/kurlar//today.xml";
            var xmldosya=new XmlDocument();
            xmldosya.Load(bugun);
            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lbldolaral.Text = dolaralis;
            string dolarsatıs = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lbldolarsat.Text = dolarsatıs;
            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lbleuroal.Text = euroalis;
            string eurosatıs = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lbleurosat.Text = eurosatıs;

        }

        private void btndolaral_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbldolaral.Text;
        }

        private void btndolarsat_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbldolarsat.Text;
        }

        private void btneuroal_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbleuroal.Text;
        }

        private void btneurosat_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbleurosat.Text;
        }

        private void txtkur_TextChanged(object sender, EventArgs e)
        {
            txtkur.Text = txtkur.Text.Replace(".", ",");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(txtkur.Text);
            miktar = Convert.ToDouble(textBox4.Text);
            tutar = kur * miktar;
            txttutar.Text = tutar.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(txtkur.Text);
            int miktar = Convert.ToInt32(textBox4.Text);
            int tutar = Convert.ToInt32(miktar/kur);
            txttutar.Text = tutar.ToString();
            double kalan;
            kalan = miktar % kur;
            textBox3.Text = kalan.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtkalan.Text = "";
            txtkur.Text = "";
            txtmiktar.Text="";
            textBox3.Text = "";
            textBox4.Text = "";
            txttutar.Text = "";
            
        }
    }
}
