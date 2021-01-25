using System;
using System.IO;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "MonsterHigh icon Transp.png";
            using ZipArchive zip = ZipFile.Open("../../../archive.zip", ZipArchiveMode.Create);
            zip.CreateEntryFromFile(filePath, filePath);
        }
    }
}
