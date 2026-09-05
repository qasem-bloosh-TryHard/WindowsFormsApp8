using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public static string GlobalToken = "";
        public static bool IsAdmin = false; // هذا المتغير الجديد
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // ملاحظة: تأكد إنك سميت مربعات النص في شاشة التصميم بهذا الاسم، 
            // أو غير الاسمين هون لـ textBox1 و textBox2 إذا ما كنت مسميهم
            string username = txtUsername.Text;
            // إذا كان اسم المستخدم بيحتوي على كلمة admin، اعتبره مدير
            if (username.ToLower() == "qasem" || username.ToLower().Contains("admin"))
            {
                IsAdmin = true;
            }
            else
            {
                IsAdmin = false;
            }
            string password = txtPassword.Text;

            var requestData = new FormUrlEncodedContent(new[]
            {
        new KeyValuePair<string, string>("username", username),
        new KeyValuePair<string, string>("password", password)
    });

            try
            {
                HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:8000/login/", requestData);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    using (JsonDocument doc = JsonDocument.Parse(responseBody))
                    {
                        GlobalToken = doc.RootElement.GetProperty("access_token").GetString();
                        // افتح الشاشة الثانية
                        Form2 dashboard = new Form2();
                        dashboard.Show();

                        // اخفي شاشة تسجيل الدخول الحالية
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة!", "خطأ بالدخول");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("تأكد إن سيرفر البايثون شغال! \nتفاصيل الخطأ: " + ex.Message, "مشكلة بالاتصال");
            }
        }
    }
}
