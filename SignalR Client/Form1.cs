using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Connect();
        }

        public IHubProxy HubProxy { get; set; }
        public IHubProxy AnotherHubProxy { set; get; }
        public const string ServerUrl = "http://localhost:50121/";//SignalR Server host
        public HubConnection Connection { get; set; }

        public async void Connect()
        {
            Connection = new HubConnection(ServerUrl);
            HubProxy = Connection.CreateHubProxy("SignalRTestHub"); //hub name
            AnotherHubProxy = Connection.CreateHubProxy("AnotherSignalRTestHub");
            await Connection.Start();

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
        }
    }
}
