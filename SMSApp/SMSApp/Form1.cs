using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    if (textUserName.Text != string.Empty && textPassword.Text != string.Empty)
                    {
                        if (txtPhoneNumber.Text != string.Empty && txtPhoneNumber.TextLength != 10)
                        {
                            string url = "http://smsc.vianett.no/v3/send.ashx?" + "src=" + txtPhoneNumber.Text + "&" + "dst=" + txtPhoneNumber.Text + "&" +
                            "msg=" + System.Web.HttpUtility.UrlEncode(textMessage.Text, System.Text.Encoding.GetEncoding("ISO-8859-1")) + "&" +
                             "username=" + System.Web.HttpUtility.UrlEncode(textUserName.Text) + "&" +
                             "password=" + System.Web.HttpUtility.UrlEncode(textPassword.Text);

                            string result = client.DownloadString(url);
                            if (result.Contains("OK"))
                            {
                                MessageBox.Show("Your Message is Sent Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Sending Failes", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        if (txtPhoneNumber.Text != string.Empty && txtPhoneNumber.TextLength != 10)
                        {
                            string url = "http://smsc.vianett.no/v3/send.ashx?" + "src=" + txtPhoneNumber.Text + "&" + "dst=" + txtPhoneNumber.Text + "&" +
                           "msg=" + System.Web.HttpUtility.UrlEncode(textMessage.Text, System.Text.Encoding.GetEncoding("ISO-8859-1")) + "&" +
                            "username=" + System.Web.HttpUtility.UrlEncode("chandsmohan14@gmail.com") + "&" +
                            "password=" + System.Web.HttpUtility.UrlEncode("SoniaMyJaan");

                            string result = client.DownloadString(url);
                            if (result.Contains("OK"))
                            {
                                MessageBox.Show("Your Message is Sent Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Sending Failes", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
