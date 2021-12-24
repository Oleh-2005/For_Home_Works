using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CursovaServer
{
    class ServerObject
    {
        public TcpListener tcpListener; 
        List<ClientObject> clients = new List<ClientObject>(); 

        public void AddConnection(ClientObject clientObject)
        {
            clients.Add(clientObject);
        }
        public void RemoveConnection(string id)
        {
            ClientObject client = clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                clients.Remove(client);
            }
        }
        public void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
                Console.WriteLine("Server has been started . Wait for connection ... ");

                while (true)
                {

                    TcpClient tcpClient = tcpListener.AcceptTcpClient();

                    ClientObject clientObject = new ClientObject(tcpClient, this);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }

        public void BroadcastMessage(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);            
            foreach (var item in clients)
            {
                if(item.Id != id)
                {
                    item.Stream.Write(data, 0, data.Length);
                }
            }
        }
        public void Disconnect()
        {
            tcpListener.Stop(); 

            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close(); 
            }
            Environment.Exit(0); 
        }
    }
}
