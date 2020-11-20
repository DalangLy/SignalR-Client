using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalR_Client
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var resources = await GoLogin();
            LoginToken result = JsonConvert.DeserializeObject<LoginToken>(resources);

            if (result.access_token != null)
            {

                Properties.Settings.Default.access_token = result.access_token;
                SignalR_Client.Properties.Settings.Default.Save();

                Form1 form1 = new Form1();
                this.Hide();
                form1.Show();
            }
        }

        static readonly HttpClient client = new HttpClient();
        async Task<string> GoLogin()
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var username = txtUsername.Text;
                var password = txtPassword.Text;
                var formContent = new FormUrlEncodedContent(new[]
                {
                     new KeyValuePair<string, string>("grant_type", "password"),
                     new KeyValuePair<string, string>("username", username),
                     new KeyValuePair<string, string>("password", password),
                 });

                HttpResponseMessage response = await client.PostAsync("http://localhost:50121/Token", formContent);

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                if (responseBody != null)
                {
                    return responseBody;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return string.Empty;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }
    }
    class LoginToken
    {
        public string access_token { set; get; }
        public string token_type { set; get; }
        public string expires_in { set; get; }
        public string userName { set; get; }
        public string issued { set; get; }
        public string expires { set; get; }
    }
}
