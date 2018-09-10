using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static byte[] data;  // 1
        static Socket socket; // 1

        static void Main(string[] args)
        {
            Console.WriteLine(" **** Server **** ");
           // Pokus_01().Wait(); // .Wait() .... cekam az dobehne cela procedura
            
            // Zemre kotatko
            //Thread thrd = new Thread(Pokus_02);
            //thrd.Start();

           // Task.Run(() => Pokus_02());              // spousitm dalsi vlakno a muzu pokracovat dale v praci
                       
            WaitCallback lCallback = new WaitCallback(Pokus_TcpListener); // vytvorim delegata
            //sdelime systemu, ze metodu asociovanou s predanym delegatem ma spustit asynchronne
            ThreadPool.QueueUserWorkItem(lCallback, "Server spusten");
            Console.ReadLine();
        }

        private static async  Task Pokus_01()
        {

        }

        private static void Pokus_02()
        {

        }

        private static void Pokus_03_Socket(Object stateInfo)
        {
            Console.WriteLine("Patameter : {0}", stateInfo);

            //Vytvořím si nový socket s typem socketu, jaký má protokol -> všimněte si, že jsem použil ProtocolType.Tcp (nečekaně).
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Vytvořím si nový IPEndPoint, což je cílová adresa, kterou chceme hostovat.V našem případě je to localhost. 
            //Také lze zaměnit IPAddress.Par­se("127.0.0.1") za 0.No a port(libovolný), v našem případě 6666.Funkce Bind přiřadí připojení k právě zmíněné IP adrese a portu.
            socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666)); 
            socket.Listen(1); // Funkce Listen(); slouží k tomu, aby server věděl vlastně kolik může maximálně naslouchat uživatelů. V našem případě je to jen jeden.
            while (true)
            {
                Socket accepteddata = socket.Accept(); // Ani nemusím vysvětlovat, prostě si vytvořím nový socket s datama co přijdou.
                data = new byte[accepteddata.SendBufferSize]; // Do proměnné typu byte se nám uloží data co přijdou.

                int j = accepteddata.Receive(data); // Zjednodušeně řečeno : "přeuložím si data co přijdou do nové proměnné", abych nedekódoval stále přicházející data.
                byte[] adata = new byte[j];         //  - || -
                for (int i = 0; i < j; i++)         //  - || -
                    adata[i] = data[i];             //  - || -

                string dat = Encoding.Default.GetString(adata); // Dekóduji data pomocí metody Default, což podporuje tuším snad všechny znaky -> taky tam je možnost ASCII a tak podobně, 
                Console.WriteLine(dat); //no a pak jen tisknu data co přijdou na obrazovku.

            }

            Console.WriteLine("Server END");
        }

        private static void Pokus_TcpListener(Object stateInfo)
        {
            List<TcpClient> klienti = new List<TcpClient>();
            Console.WriteLine("Server Starting...");
            TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 6666);
            listener.Start();                        // zacneme naslouchat
            Console.WriteLine("Server Started.");

            while (true)
            {
                if (listener.Pending())              // Někdo čeká na připojení
                {
                    TcpClient klient = listener.AcceptTcpClient();  // Vrátí klienta, co se připojuje
                    klienti.Add(klient);
                }

                ZpracovaniZprav(klienti);
            }
        }

        private static void ZpracovaniZprav(List<TcpClient> klienti)
        {
            //if (klienti.Count < 2)
            //{
            //    return;
            //}

            foreach (var klient in klienti)
            {
                try
                {
                    // Přijetí zprávy od klienta
                    if (klient.GetStream().DataAvailable)
                    {
                        string zprava = PosilacRetezcu.PrijmiString(klient);
                        Console.WriteLine(zprava);
                        // Poslání zprávy všem ostatním
                        foreach (TcpClient k2 in klienti)
                        {
                            if (k2 != klient)
                            {
                                PosilacRetezcu.PosliString(k2, zprava);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
