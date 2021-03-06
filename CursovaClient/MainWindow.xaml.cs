using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CursovaClient
{
    public partial class MainWindow : Window
    {
        static string userName;
        private const string host = "127.0.0.1";
        private const int port = 8888;
        static TcpClient client;
        static NetworkStream stream;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbxName.Text == " " || tbxName.Text == "")
            {
                MessageBox.Show("Your name is null or white space", "Error", MessageBoxButton.OK);

            }
            else
            {

                userName = tbxName.Text;
                client = new TcpClient();
                try
                {
                    client.Connect(host, port);
                    stream = client.GetStream();
                    string message = userName;
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                    
                    Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                    receiveThread.Start();
                    tbxChat.Text += $"Server : Hi , {userName}";
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
                }

                this.Dispatcher.Invoke(() =>
                {
                    tbxName.IsEnabled = false;
                    btnConnect.IsEnabled = false;
                });
                    
            }
        }
        public void SendMessage()
        {   
            string message = tbxMsg.Text;
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
            this.Dispatcher.Invoke(() =>
            {
                tbxChat.Text += $"\nYou : {message}";
                tbxMsg.Text = null;
            });
        }

        public void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();
                    this.Dispatcher.Invoke(() =>
                    {
                        tbxChat.Text += $"\n{message}";
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, $"Error", MessageBoxButton.OK);
                    Disconnect();
                }

            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string message = "leaveTheChat";
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
            Disconnect();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }
        public void Disconnect()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
            Environment.Exit(0); 
        }
    }
}
