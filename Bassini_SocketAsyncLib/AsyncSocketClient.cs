using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Bassini_SocketAsyncLib
{
    class AsyncSocketClient
    {
        IPAddress mServerIpAddress;
        int mServerPort;
        TcpClient mClient;

        public IPAddress ServerIpAddress
        {
            get
            {
                return mServerIpAddress;
            }
        }

        public int ServerPort
        {
            get
            {
                return mServerPort;
            }
        }
        public bool SetServerIPAddress(string str_ipaddr)
        {
            IPAddress ipaddr=null;
            if (!IPAddress.TryParse(str_ipaddr,out ipaddr))
            {
                Console.WriteLine("IP non valido");
                return false;
            }
            mServerIpAddress = ipaddr;
            return true;
        }
        public bool SetServerPort(string str_port)
        {
            int port = -1;
            if (!int.TryParse(str_port,out port))
            {
                Console.WriteLine("Porta non valida");
                return false;
            }
            if(port <0 || port > 65535)
            {
                Console.WriteLine("La porta deve essere compresa tra 0 e 65535");
                return false;
            }
            mServerPort = port;
            return true;
                
        }
        public async Task ConnettiAlServer()
        {
            if (mClient == null)
            {
                mClient = new TcpClient();
            }

            try
            {
                await mClient.ConnectAsync(mServerIpAddress, mServerPort);
                Console.WriteLine("Connesso al server IP/Port: {0} / {1}",
                                    mServerIpAddress.ToString(),mServerPort);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public AsyncSocketClient()
        {
            mServerIpAddress = null;
            mServerPort = -1;
            mClient = null;
        }
    }
}
