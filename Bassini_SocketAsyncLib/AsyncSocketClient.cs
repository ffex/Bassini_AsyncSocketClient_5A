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

        public AsyncSocketClient()
        {
            mServerIpAddress = null;
            mServerPort = -1;
            mClient = null;
        }
    }
}
