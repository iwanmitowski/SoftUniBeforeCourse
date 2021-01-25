using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {


            using FileStream readFileStream = new FileStream("MonsterHigh icon Transp.png",FileMode.Open);
            using FileStream writeFileStream = new FileStream("copy.png",FileMode.Create);
            byte[] buffer = new byte[4096];

            while (true)
            {
                int count =readFileStream.Read(buffer, 0, buffer.Length);
                if (count == 0)
                {
                    break;
                }
                writeFileStream.Write(buffer);

            }
        }
    }
}
