using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace System_FIle_IO
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo MyInfo = new DirectoryInfo(@"C:\Users\Dkaestner");
            

            #region
            /*
            DirectoryInfo DataDir = new DirectoryInfo(@"C:\Users\Dkaestner\Desktop\DataDir");
            DataDir.Create();
            string[] customer =
            {
                "@echo off","echo Hallo","Pause"
            };
            string PathFile = @"C:\Users\Dkaestner\Desktop\DataDir\Smith.bat";
            File.WriteAllLines(PathFile, customer);
            foreach (string cust in File.ReadAllLines(PathFile))
            {
                Console.WriteLine(cust);
            }
            Process.Start(@"C:\Users\Dkaestner\Desktop\DataDir\Smith.bat");
            
             */
#endregion 


            #region how to get File Info
            DirectoryInfo myDataDir = new DirectoryInfo(@"C:\Users\Dkaestner\Desktop\DataDir");

            FileInfo[] newdataInfo = myDataDir.GetFiles("*.txt", SearchOption.AllDirectories);

            Console.WriteLine("Matches : {0}",newdataInfo.Length);
            Console.WriteLine("-----------------------");
            foreach (FileInfo match in newdataInfo)
            {
                Console.WriteLine(match.Name);
                Console.WriteLine(match.Length);
                Console.WriteLine("-----------------------");
            }
            #endregion


            #region Filestream don´t get it
            /*FileStream

            string textPathFile = @"C:\users\dkaestner\Desktop\DataDir\textfile.txt";

            FileStream fs = new FileStream(textPathFile, FileMode.Create);

            string randString = "This is a random string";

            byte[] rsByteArr = Encoding.Default.GetBytes(randString);

            fs.Write(rsByteArr, 0, rsByteArr.Length);
            fs.Position = 0;
            byte[] fileByteArray = new byte[rsByteArr.Length];

            for (int i = 0; i < rsByteArr.Length; i++)
            {
                fileByteArray[i] = (byte)fs.ReadByte();
            }
            Console.WriteLine(Encoding.Default.GetString(fileByteArray)); */
            #endregion


            #region streamwriter
            /*   string textfilePath3 = @"C:\Users\Dkaestner\Desktop\DataDir\textFile2.txt";

            StreamWriter sw = File.CreateText(textfilePath3);

            sw.Write("Hallo");
            sw.WriteLine("Dies ist Der StreanWriter:");
            sw.WriteLine("600");
            sw.Write("SonderBar");

            sw.Close();

            StreamReader sr = File.OpenText(textfilePath3);


            Console.WriteLine("Peek: {0}", Convert.ToChar(sr.Peek()));
            Console.WriteLine("First Sentence: {0}", sr.ReadLine());
            Console.WriteLine("Rest: {0}", sr.ReadToEnd());
            sr.Close(); */
            #endregion

            #region BinaryWriter and reader
            string textfilePath4 = @"C:\Users\Dkaestner\Desktop\DataDir\textFile4.dat";

            FileInfo datFile = new FileInfo(textfilePath4);

            BinaryWriter bw = new BinaryWriter(datFile.OpenWrite());

            string Name = "Damian";
            string NachName = "Kästner";
            int Alter = 18;
            double Größe = 1.85;

            bw.Write(Name);
            bw.Write(NachName);
            bw.Write(Alter);
            bw.Write(Größe);

            bw.Close();

            BinaryReader br = new BinaryReader(datFile.OpenRead());

            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadString());
            
            Console.WriteLine(br.ReadDouble());

            br.Close();
            #endregion


            Console.ReadLine();
        }
    }
}
