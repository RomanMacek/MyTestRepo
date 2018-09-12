using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" **** Klient **** ");
            //WaitCallback lCallback = new WaitCallback(Pokus_01);
            //ThreadPool.QueueUserWorkItem(lCallback, "Klient spusten");
<<<<<<< HEAD
            // Pokus_TcpClient("Klient spusten");
            PikusServicePointManager();
=======
            Pokus_TcpClient("Klient spusten");
>>>>>>> novy projekt TCP komunikace
            Console.ReadLine();
        }

        private static void Pokus_Socket(object parameters)
        {
            Console.WriteLine("Patameter : {0}", parameters);
            while (true)
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try // Zkusím se připojit na server. Pokud to půjde, dostaneme se dále. Pokud ne, smůla, vyskočí třeba nějaká chybová hláška.
                {
                    s.Connect(IPAddress.Parse("127.0.0.1"), 6666); // Zkusím se tedy připojit pomocí funkce Connect. Naparsujeme si opět IP adresu ze stringu a zadáme port, který server naslouchá, tudíž 6666.
                    Console.Write("Zadej nejakej text : ");
                    string q = Console.ReadLine();                 // Uživatel zadá nějaký text, já si ho uložím a zakóduji pomocí metody default do proměnné, kterou jsem si vytvořil. Je to proměnná data typu byte.
                    byte[] data = Encoding.Default.GetBytes(q);    // Uživatel zadá nějaký text, já si ho uložím a zakóduji pomocí metody default do proměnné, kterou jsem si vytvořil. Je to proměnná data typu byte.
                    s.Send(data);                                  // A tadá, odešlu data na server. :)
                }
                catch // 1
                {
                    // nepripojeno
                }
            }

            Console.WriteLine("Klient END");
        }

        public const int separator = 0;
        private static void Pokus_TcpClient(object parameters)
        {
            var klient = new TcpClient("127.0.0.1", 6666);
            WaitCallback lCallback = new WaitCallback(Pokus_TcpClient_ReadMessageFromServer);
            ThreadPool.QueueUserWorkItem(lCallback, klient);

            while (true)
            {
                Console.Write("Zadej nejakej text : ");
                string zprava = Console.ReadLine();

                byte[] byteBuffer = Encoding.UTF8.GetBytes(zprava);
                NetworkStream netStream = klient.GetStream();
                netStream.Write(byteBuffer, 0, byteBuffer.Length);
                netStream.Write(new byte[] { separator }, 0, sizeof(byte));
                netStream.Flush();
            }
        }

        private static void Pokus_TcpClient_ReadMessageFromServer(object parameters)
        {
            var klient = (TcpClient) parameters;
            List<int> buffer = new List<int>();
            NetworkStream stream = klient.GetStream();
            int readByte;
            while ((readByte = stream.ReadByte()) != 0)
            {
                buffer.Add(readByte);
            }
            var message = Encoding.UTF8.GetString(buffer.Select<int, byte>(b => (byte)b).ToArray(), 0, buffer.Count);
            Console.WriteLine(message);
        }
<<<<<<< HEAD

        private static void PikusServicePointManager()
        {
            Uri uri_income = new Uri("http://www.income.cz/");

            // nemel najit ale mel by zalozit
            ServicePoint incomeFrom_01 = ServicePointManager.FindServicePoint(uri_income);
            // mel by uz najit
            ServicePoint incomeFrom_02 = ServicePointManager.FindServicePoint(uri_income);

            Uri uri_incomeSub = new Uri("http://jackpot.income.cz/");
            ServicePoint incomeFrom_03 = ServicePointManager.FindServicePoint(uri_incomeSub);

            Uri uri01 = new Uri("https://www.youtube.com/watch?v=teK_6kuQSiQ");
            var uri01Res = ServicePointManager.FindServicePoint(uri01);

            Uri uri02 = new Uri("https://www.youtube.com/watch?v=v-oPRvgMLOQ");
            var uri02Res = ServicePointManager.FindServicePoint(uri02);
        }

=======
>>>>>>> novy projekt TCP komunikace
    }
}
