using Microsoft.AspNet.SignalR.Client;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            this.Connect();

            if (Properties.Settings.Default.access_token != "")
            {
                var userInfo = await GetAll("http://localhost:50121/api/Account/UserInfo");
                UserInfoModel result = JsonConvert.DeserializeObject<UserInfoModel>(userInfo);
                txtUsername.Text = result.email;
            }
        }

        public IHubProxy HubProxy { get; set; }
        public IHubProxy AnotherHubProxy { set; get; }
        public const string ServerUrl = "http://localhost:50121/";//SignalR Server host
        public HubConnection Connection { get; set; }
        public async void Connect()
        {
            Connection = new HubConnection(ServerUrl);

            //to access autorized hub and map logged user u need to pass token
            Connection.Headers.Add("Authorization", String.Format("Bearer {0}", Properties.Settings.Default.access_token)); //THIS IS WHERE YOU ADD YOUR ACCESS TOKEN MENTIONED ABOVE

            HubProxy = Connection.CreateHubProxy("SignalRTestHub"); //hub name
            AnotherHubProxy = Connection.CreateHubProxy("AnotherSignalRTestHub");
            await Connection.Start();

            var myConnectedModelString = await HubProxy.Invoke<string>("getCurrentConnectedModel");//invoke to get my connection id and my logged in email

            this.displayConnectedUsers(myConnectedModelString);

            HubProxy.On("sayHello", (message) =>
                this.Invoke((Action)(() =>
                        {
                            Console.WriteLine(Convert.ToString(message));
                        }
                    )
                )
            );

            HubProxy.On("anotherSayHello", (message) =>
                this.Invoke((Action)(() =>
                        {
                            Console.WriteLine(Convert.ToString(message));
                        }
                    )
                )
            );

            HubProxy.On("allConnectedUsers", (message) =>
                        this.Invoke((Action)(() =>
                        {
                            Console.WriteLine(Convert.ToString(message));
                            this.displayConnectedUsers(Convert.ToString(message));
                        }
                    )
                )
            );

            HubProxy.On("listenMessage", (message) =>
                        this.Invoke((Action)(() =>
                        {
                            Console.WriteLine(Convert.ToString(message));
                            txtRecieveMessage.Text = Convert.ToString(message);
                        }
                    )
                )
            );
        }

        private void displayConnectedUsers(string resources)
        {
            List<ConnectedUserModel> result = JsonConvert.DeserializeObject<List<ConnectedUserModel>>(resources);

            DataTable dt = new DataTable();
            dt.Columns.Add("Connection ID", typeof(string));
            dt.Columns.Add("User Email", typeof(string));

            foreach (var item in result)
            {
                string cId = item.connectionId.ToString();
                string name = item.userEmail.ToString();

                dt.Rows.Add(new object[] { cId, name });
            }

            dgvConnectedUsers.DataSource = dt;
        }

        //get logged user info
        static readonly HttpClient client = new HttpClient();
        static async Task<string> GetAll(string uri)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SignalR_Client.Properties.Settings.Default.access_token);
                string responseBody = await client.GetStringAsync(uri);
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

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            var resources = await GoLogout("http://localhost:50121/api/Account/Logout");
            if (resources.IsSuccessStatusCode)
            {
                Properties.Settings.Default.access_token = null;
                SignalR_Client.Properties.Settings.Default.Save();

                LoginForm loginForm = new LoginForm();
                this.Hide();
                loginForm.Show();

                Connection.Stop();
            }
        }
        static async Task<HttpResponseMessage> GoLogout(string uri)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SignalR_Client.Properties.Settings.Default.access_token);
                HttpResponseMessage responseBody = await client.PostAsync(uri, null);
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
            return null;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Connection.Stop();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            await HubProxy.Invoke<string>("sendMessage", txtConnectionId.Text, txtMessage.Text);
        }

        private void dgvConnectedUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            object connectionId = dgvConnectedUsers.Rows[e.RowIndex].Cells[0].Value;
            txtConnectionId.Text = connectionId.ToString();
        }
    }

    class UserInfoModel
    {
        public string email { set; get; }
        public bool hasRegistered { get; set; }
        public string loginProvider { get; set; }
    }

    class ConnectedUserModel
    {
        public string connectionId { get; set; }
        public string userEmail { set; get; }
    }
}
