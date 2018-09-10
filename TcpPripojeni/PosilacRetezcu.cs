using System;

public class PosilacRetezcu
{
    public PosilacRetezcu()
    {
    }

    /// <summary>
    /// Separátor
    /// </summary>
    public const int separator = 0;

    /// <summary>
    /// Pošle textový řetězec danému klientovi
    /// </summary>
    /// <param name="klient">Klient</param>
    /// <param name="zprava">Řetězec k odeslání</param>
    public static void PosliString(TcpClient klient, string zprava)
    {
        byte[] byteBuffer = Encoding.UTF8.GetBytes(zprava);
        NetworkStream netStream = klient.GetStream();
        netStream.Write(byteBuffer, 0, byteBuffer.Length);
        netStream.Write(new byte[] { separator }, 0, sizeof(byte));
        netStream.Flush();
    }

    /// <summary>
    /// Přijme řetězec od daného klienta
    /// </summary>
    /// <param name="klient">Klient</param>
    /// <returns>Řetězec od klienta</returns>
    public static string PrijmiString(TcpClient klient)
    {
        List<int> buffer = new List<int>();
        NetworkStream stream = klient.GetStream();
        int readByte;
        while ((readByte = stream.ReadByte()) != 0)
        {
            buffer.Add(readByte);
        }
        return Encoding.UTF8.GetString(buffer.Select<int, byte>(b => (byte)b).ToArray(), 0, buffer.Count);
    }
}
