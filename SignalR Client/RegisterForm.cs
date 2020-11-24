using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalR_Client
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            var resource = await Register();
            Console.WriteLine(resource);

            MessageBox.Show("Registered");

            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.Show();
        }

        static readonly HttpClient client = new HttpClient();
        async Task<string> Register()
        {
            try
            {
                var registerModel = new RegisterModel();
                registerModel.Email = txtEmail.Text;
                registerModel.Password = txtPassword.Text;
                registerModel.ConfirmPassword = txtConfirmPassword.Text;

                var json = JsonConvert.SerializeObject(registerModel);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("http://localhost:50121/api/Account/Register", data);

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
    }

    class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
