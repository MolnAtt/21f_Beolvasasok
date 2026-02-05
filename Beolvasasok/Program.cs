using System;
using System.Collections.Generic; // listákhoz!
using System.Linq; // ajánlom mindenkinek
using System.Text;
using System.Threading.Tasks;
using System.IO; // fájlkezelés

namespace Beolvasasok
{
	internal class Program
	{
		static List<int> Beolvas_Godrok_1(string fajlnev)
		{
			List<int> result = new List<int>();
			StreamReader sr = new StreamReader(fajlnev, Encoding.Default);

			while (!sr.EndOfStream)
			{
				result.Add(int.Parse(sr.ReadLine()));
			}

			sr.Close();  // ha BEOLVASÁSNÁL elhagyod, nincs nagy probléma
			return result;
		}
		static List<int> Beolvas_Godrok_2(string fajlnev)
		{
			List<int> result = new List<int>();
			using (StreamReader sr = new StreamReader(fajlnev, Encoding.Default))
			{
				while (!sr.EndOfStream)
				{
					result.Add(int.Parse(sr.ReadLine()));
				}
			}

			return result;
		}

		static List<int> Beolvas_Godrok_3(string fajlnev)
		{
			List<int> result = new List<int>();
			string[] sorok = File.ReadAllLines(fajlnev);

			foreach (string sor in sorok)
			{
				result.Add(int.Parse(sor));
			}
			return result;
		}

		static List<int> Beolvas_Godrok_4(string fajlnev)
		{
			return File.ReadAllLines(fajlnev).Select(int.Parse).ToList();
		}

		static void Main(string[] args)
		{
			List<int> adatok = Beolvas_Godrok_4("melyseg.txt");

			for (int i = 0; i < adatok.Count; i++)
			{
				Console.WriteLine(adatok[i]);
			}
		}
	}
}
