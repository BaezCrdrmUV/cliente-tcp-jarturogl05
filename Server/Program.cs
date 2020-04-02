using System;

namespace SocketCom
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args[0] == "server")
            {
                TCPServer server = new TCPServer("127.0.0.1", 8080, true);
                server.Listen();
            } else if(args[0] == "client")
            {
                string name = "Cliente";
                try
                {
                    name = args[1];
                }
                catch (Exception) { }

                // Ejecución de cliente .NET Core
            }
        }
    }
}
