using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReadFile{
	class ReadFromFile
	{
		static void Main()
		{
            //ini mulai bagian penting__________________________________________________________
            int i=0;
            char[] delimiterChars = { ' ', ',', '.'};
            //ganti @"/path" format string harus <@"X:\example\path\example.txt">
			string[] lines = File.ReadAllLines(@"C:\Users\Public\Test\test.txt");
            string[][] kode = new string[lines.Length][];
            string[] listOfKode = new string[lines.Length];

            for (i=0;i<lines.Length;i++){
                kode[i] = lines[i].Split(delimiterChars,StringSplitOptions.RemoveEmptyEntries);
                listOfKode[i] = kode[i][0];
            }
            bool[,] AdjMatrix = new bool[kode.Length,kode.Length];
            for(i=0;i<listOfKode.Length;i++){
                foreach(var k1 in kode)
                {
                    int j = 0;
                    if ((j = Array.IndexOf(k1, listOfKode[i])) >= 0)
                    {
                        AdjMatrix[i,j] = true;
                    }
                }
            }
            //ini akhir bagian penting__________________________________________________________

            //print adjacency matrix ke cmd
            for (i = 0; i < listOfKode.Length; i++)
            {
                for (int j = 0; j < listOfKode.Length; j++)
                {
                    if(AdjMatrix[i, j])
                    {
                        Console.Write("1 ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                Console.WriteLine(" ");
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
			System.Console.ReadKey();
		}
	}
}
