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

            //to access autorized hub and map logged user u need to pass token
            Connection.Headers.Add("Authorization", String.Format("Bearer {0}", "0hHhYVvKw51eJbritK1Jdqz5_j-ys_53ISauXGQHH5yQSMogFeLcKxKULGDiodVDJeodCW24M44xF-llhK-mDTa0eP0_sJ4LTWxZsk8q0jPbk31wCDITsJeniGzi93gHhlUW7kMasu-ilctf4bvkKqKX0kAstJxJMRsth0Fffm-BGUfvlZKjUNTvtCOzHrU5XuuNl_0y50okcuiY7m6NbtBQis2YsFrNkBH00bTveZjGn_83aOwFi0rhFUQaYRdyll98F72hQr9TJxqBNDQyuMuIU117MqHT8H8J7O2drIaQ0Y0pyc3ju28cMzo-rfg7V233LxhtB-4ta71Z-vCjSvnec_JEY_7SBs7BY23j6wiyupTox_Q_6V3juh4jexFBDSoWNCYw-qNlyAuQFuUbpOO5XGHsIw1Z9reG8ttTDnZILIuVbrRppFXWrLKFmxsBGcsOYL2NUB30QPCiysAzL75bO4aoxWv8y1iZCA2gNAk")); //THIS IS WHERE YOU ADD YOUR ACCESS TOKEN MENTIONED ABOVE

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
            
            HubProxy.On("allConnectedUsers", (message) =>
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
