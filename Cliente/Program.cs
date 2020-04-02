using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TcpClientSample
{
   public static void Main()
   {
      byte[] data = new byte[1024];
      string input, stringData;
      TcpClient server;
 
      try
      {
         server = new TcpClient("127.0.0.1", 8080);
      } catch (SocketException)
      {
         Console.WriteLine("No se puede conectar al servidor");
         return;
      }
      NetworkStream networkstream = server.GetStream();

      int recv = networkstream.Read(data, 0, data.Length);
      stringData = Encoding.UTF8.GetString(data, 0, recv);
      Console.WriteLine(stringData);

      while(true)
      {
         input = Console.ReadLine();
         if (input == "bye")
            break;
         networkstream.Write(Encoding.UTF8.GetBytes(input), 0, input.Length);
         networkstream.Flush();

         data = new byte[1024];
         recv = networkstream.Read(data, 0, data.Length);
         stringData = Encoding.UTF8.GetString(data, 0, recv);
         Console.WriteLine(stringData);
      }
      Console.WriteLine("Desconectando del servidor");
      networkstream.Close();
      server.Close();
   }
}

           