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
using System.Net.Http.Headers;
using System.Text.Json;



namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnLoadEpisodes_Click(object sender, EventArgs e)
        {
            // نتأكد إنه كتب رقم المسلسل
            if (string.IsNullOrWhiteSpace(txtSeriesIdForEpisodes.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم المسلسل لعرض حلقاته!");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Form1.GlobalToken);

                    // دمجنا رقم المسلسل مع الرابط
                    string url = "http://127.0.0.1:8000/episodes/" + txtSeriesIdForEpisodes.Text;
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        List<Episode> episodes = JsonSerializer.Deserialize<List<Episode>>(responseBody, options);

                        // التأكد إذا في حلقات أو المسلسل فاضي
                        if (episodes.Count == 0)
                        {
                            MessageBox.Show("لا يوجد حلقات مضافة لهذا المسلسل بعد.");
                            dataGridView1.DataSource = null; // تفريغ الجدول
                        }
                        else
                        {
                            dataGridView1.DataSource = episodes;
                        }
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ أثناء جلب الحلقات!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشكلة بالاتصال: " + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // إذا ما كان مدير (يعني يوزر عادي)
            if (Form1.IsAdmin == false)
            {
                // 1. إخفاء قسم إضافة المسلسل
                btnAddSeries.Visible = false;
                txtSeriesTitle.Visible = false;

                // 2. إخفاء قسم التعديل
                btnUpdateSeries.Visible = false;
                txtUpdateSeriesId.Visible = false;
                txtUpdateSeriesTitle.Visible = false;

                // 3. إخفاء قسم الحذف
                btnDeleteSeries.Visible = false;
                txtSeriesId.Visible = false;

                // 4. إخفاء قسم إضافة الحلقات
                btnAddEpisode.Visible = false;
                txtEpisodeTitle.Visible = false;
                txtEpisodeSeriesId.Visible = false;
            }
            // أما إذا كان مدير (Form1.IsAdmin == true)، فالشاشة رح تظل زي ما هي وكل الأزرار ظاهرة.
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async void btnAddSeries_Click(object sender, EventArgs e)
        {
            // التأكد إنه ما ضغط إضافة والمربع فاضي
            if (string.IsNullOrWhiteSpace(txtSeriesTitle.Text))
            {
                MessageBox.Show("الرجاء كتابة اسم المسلسل أولاً!");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // 1. نرفق بطاقة الدخول (Token) تبعتنا
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Form1.GlobalToken);

                    // 2. نجهز البيانات اللي رح نبعثها (نفس شكل القالب اللي بالبايثون)
                    var newSeries = new { title = txtSeriesTitle.Text };

                    // 3. نحولها لـ JSON
                    string jsonString = JsonSerializer.Serialize(newSeries);
                    var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

                    // 4. نبعث الطلب لمسار إضافة المسلسلات (POST)
                    HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:8000/series/", content);

                    // 5. نفحص النتيجة
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("تمت إضافة المسلسل بنجاح!", "عملية ناجحة");
                        txtSeriesTitle.Clear(); // تفريغ المربع بعد الإضافة
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) // Error 403
                    {
                        // هون السحر: السيرفر رح يرفض العملية إذا حسابك مش Admin!
                        MessageBox.Show("عذراً، لا تملك صلاحيات الإدارة لإضافة مسلسلات!", "صلاحيات مرفوضة");
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ أثناء الإضافة.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشكلة بالاتصال: " + ex.Message);
            }
        }

        private async void btnLoadSeries_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Form1.GlobalToken);

                    HttpResponseMessage response = await client.GetAsync("http://127.0.0.1:8000/series/");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                        // تحويل الرد لقائمة مسلسلات وعرضها بالجدول
                        List<SeriesItem> seriesList = JsonSerializer.Deserialize<List<SeriesItem>>(responseBody, options);
                        dataGridView1.DataSource = seriesList;
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ أثناء جلب المسلسلات!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشكلة بالاتصال: " + ex.Message);
            }
        }

        private void txtSeriesId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtSeriesTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnDeleteSeries_Click(object sender, EventArgs e)
        {
            // التأكد إن المستخدم كتب رقم المسلسل
            if (string.IsNullOrWhiteSpace(txtSeriesId.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم المسلسل (ID) المراد حذفه!");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // نرفق بطاقة الدخول (Token)
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Form1.GlobalToken);

                    // دمج رقم المسلسل مع الرابط (مثلاً /series/5)
                    string url = "http://127.0.0.1:8000/series/" + txtSeriesId.Text;

                    // نبعث أمر الحذف (DELETE)
                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("تم الحذف بنجاح! اضغط على (عرض المسلسلات) لتحديث الجدول.", "عملية ناجحة");
                        txtSeriesId.Clear(); // تفريغ المربع بعد الحذف
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) // Error 403
                    {
                        // إذا كان حسابه User عادي مش Admin
                        MessageBox.Show("عذراً، لا تملك صلاحيات الإدارة لحذف المسلسلات!", "صلاحيات مرفوضة");
                    }
                    else
                    {
                        MessageBox.Show("تأكد من أن رقم المسلسل صحيح وموجود.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشكلة بالاتصال: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSeriesIdForEpisodes_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void btnAddEpisode_Click(object sender, EventArgs e)
        {
            // 1. التحقق من المدخلات (نتأكد إنه المربعات مش فاضية)
            if (string.IsNullOrWhiteSpace(txtEpisodeTitle.Text) || string.IsNullOrWhiteSpace(txtEpisodeSeriesId.Text))
            {
                MessageBox.Show("الرجاء كتابة اسم الحلقة ورقم المسلسل التابعة له!");
                return;
            }

            // 2. نتأكد إن رقم المسلسل المكتوب عبارة عن رقم فعلاً مش حروف
            if (!int.TryParse(txtEpisodeSeriesId.Text, out int seriesId))
            {
                MessageBox.Show("رقم المسلسل يجب أن يكون رقماً صحيحاً (مثلاً: 1, 2, 3)!");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // إرفاق بطاقة الدخول (Token) عشان الصلاحيات
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Form1.GlobalToken);

                    // 3. تجهيز بيانات الحلقة الجديدة (اسم الحلقة ورقم المسلسل التابعة له)
                    var newEpisode = new
                    {
                        title = txtEpisodeTitle.Text,
                        series_id = seriesId
                    };

                    string jsonString = JsonSerializer.Serialize(newEpisode);
                    var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

                    // 4. إرسال الطلب لمسار إضافة الحلقات (POST)
                    HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:8000/episodes/", content);

                    // 5. فحص النتيجة
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("تمت إضافة الحلقة بنجاح يا وحش!", "عملية ناجحة");
                        txtEpisodeTitle.Clear();
                        // ما فضينا مربع رقم المسلسل قصداً، عشان لو بدك تضيف كمان حلقة لنفس المسلسل يكون الرقم جاهز ومكتوب!
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) // Error 403
                    {
                        MessageBox.Show("عذراً، لا تملك صلاحيات الإدارة لإضافة حلقات!", "صلاحيات مرفوضة");
                    }
                    else
                    {
                        // إذا كتب رقم مسلسل مش موجود أصلاً في قاعدة البيانات
                        MessageBox.Show("حدث خطأ! تأكد من أن رقم المسلسل موجود فعلياً.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشكلة بالاتصال: " + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnUpdateSeries_Click(object sender, EventArgs e)
        {
            // نتأكد إن المربعات مش فاضية
            if (string.IsNullOrWhiteSpace(txtUpdateSeriesId.Text) || string.IsNullOrWhiteSpace(txtUpdateSeriesTitle.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم المسلسل (ID) والاسم الجديد!");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // نرفق بطاقة الدخول (Token)
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Form1.GlobalToken);

                    // نجهز البيانات الجديدة (الاسم الجديد)
                    var updateData = new { title = txtUpdateSeriesTitle.Text };
                    string jsonString = JsonSerializer.Serialize(updateData);
                    var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

                    // دمج رقم المسلسل مع الرابط
                    string url = "http://127.0.0.1:8000/series/" + txtUpdateSeriesId.Text;

                    // هون بنستخدم PutAsync بدل Post أو Get
                    HttpResponseMessage response = await client.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("تم تعديل اسم المسلسل بنجاح! اضغط (عرض المسلسلات) لتشوف التحديث.", "عملية ناجحة");
                        txtUpdateSeriesId.Clear();
                        txtUpdateSeriesTitle.Clear();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    {
                        MessageBox.Show("عذراً، لا تملك صلاحيات الإدارة لتعديل المسلسلات!", "صلاحيات مرفوضة");
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("رقم المسلسل غير موجود في قاعدة البيانات!");
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ أثناء التعديل.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشكلة بالاتصال: " + ex.Message);
            }
        }
    }

    public class Episode
    {
        public int id { get; set; }
        public string title { get; set; }
        public int series_id { get; set; }
    }

    public class SeriesItem
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}
