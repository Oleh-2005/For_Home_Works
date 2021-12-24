using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CursovaServer
{
    class ClientObject
    {
        public string Id { get; private set; }
        public NetworkStream Stream { get; private set; }
        string userName;
        TcpClient client;
        ServerObject server; 

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                string message = GetMessage();
                userName = message;

                message = userName + " connected to the chat";
                server.BroadcastMessage(message, this.Id);
                Console.WriteLine(message);
                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        if(message == "leaveTheChat")
                        {
                            message = String.Format("{0} : leave the chat", userName);
                            server.BroadcastMessage(message, this.Id);
                            break;
                        }
                        message = $"{userName} : {message}";
                        Console.WriteLine(message);
                        server.BroadcastMessage(message, this.Id);
                    }
                    catch
                    {
                        message = String.Format("{0} : leave the chat", userName);
                        Console.WriteLine(message);
                        server.BroadcastMessage(message, this.Id);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                server.RemoveConnection(this.Id);
                Close();
            }
        }

        public string GetMessage()
        {
            byte[] data = new byte[64];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
        }

        
        public void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();

        }
    }
}
