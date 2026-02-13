using System;
using System.Collections.Generic; // listákhoz!
using System.Linq; // ajánlom mindenkinek
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel; // fájlkezelés

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

		/// <summary>
		/// 3. Állapítsa meg, hány dobásból állt a kísérlet, és a választ a mintának megfelel􀄘en írassa ki a képerny􀄘re!
		/// </summary>
		/// <param name="fajlnev"></param>
		/// <returns></returns>
		static int Fej_vagy_iras_3(string fajlnev)
		{
			int db = 0;
			using (StreamReader sr = new StreamReader(fajlnev))
			{
				while (!sr.EndOfStream)
				{
					sr.ReadLine();
					db++;
				}
			}
			return db;
		}

		static void Godrok_kiirasa(List<int> adatok)
		{
			StreamWriter w = new StreamWriter("godrok.txt");

			for (int i = 0; i < adatok.Count; i++)
			{
				if (adatok[i]>0)
				{
					w.Write(adatok[i] + " ");
				}
				else
				{
					if (0<i && adatok[i-1] != 0)
					{
						w.WriteLine();
					}
				}
			}

			//w.Close();
		}



		static void Main(string[] args)
		{
			List<int> adatok = Beolvas_Godrok_4("melyseg.txt");

			//for (int i = 0; i < adatok.Count; i++)
			//{
			//	Console.WriteLine(adatok[i]);
			////}

			//Console.WriteLine(Fej_vagy_iras_3("kiserlet.txt"));

			//// fájlba írás

			//StreamWriter sw = new StreamWriter("ideirok.txt");
			//sw.WriteLine("halihó");
			//sw.Close(); // ez itt elhagyhatatlan! Enélkül csak a fájl jön létre, de a módosítások nem lesznek elmentve!

			//string s = "20190326-0700";

			////furadatumstr = "2019-03-26 07:00";
			////DateTime d = DateTime.Parse(furadatumstr); // erről lebeszélnék mindenkit, mert nem működik mindig olyan jól...

			//DateTime d = new DateTime(int.Parse(s.Substring(0,4)),int.Parse(s.Substring(4,2)),26,7,0,0);
			//Console.WriteLine(d);

			Console.WriteLine($"1. feladat\nA fájl adatainak száma: {adatok.Count}");

			Console.WriteLine($"2. feladat\nAdjon meg egy távolságértéket!");
			int szam = int.Parse(Console.ReadLine());
			Console.WriteLine(adatok[szam-1]);

			double f = 100*(double)adatok.Count(x => x == 0) / (double)adatok.Count();
			Console.WriteLine($"3. feladat\nAz érintetlen terület aránya {f:00.00}%.");

			Godrok_kiirasa(adatok);

			Console.WriteLine($"5. feladat\nA gödrök száma: {File.ReadAllLines("godrok.txt").Length}");

			if (adatok[szam-1] == 0)
			{
				Console.WriteLine("Az adott helyen nincs gödör.");
			}
			else
			{
				int eleje = Eleje(adatok, szam-1);
				int vege = Vege(adatok, szam-1);
				bool folyamatosan_melyul_e = Folyamatosan_melyul_e(adatok, eleje, vege);
				int legnagyobb_melyseg = Legnagyobb_melyseg(adatok, eleje, vege);
				int terfogat = Terfogat(adatok, eleje, vege);
				int vizmennyiseg = Vizmennyiseg(adatok, eleje, vege);


			}





		}

		private static int Vizmennyiseg(List<int> adatok, int eleje, int vege)
		{
			throw new NotImplementedException();
		}

		private static int Terfogat(List<int> adatok, int eleje, int vege)
		{
			throw new NotImplementedException();
		}

		private static int Legnagyobb_melyseg(List<int> adatok, int eleje, int vege)
		{
			throw new NotImplementedException();
		}

		private static bool Folyamatosan_melyul_e(List<int> adatok, int eleje, int vege)
		{
			throw new NotImplementedException();
		}

		private static int Vege(List<int> adatok, int szam)
		{
			throw new NotImplementedException();
		}

		private static int Eleje(List<int> adatok, int szam)
		{
			int i = szam;
			while (0<=i && adatok[i]!=0)
			{
				i--;
			}
			return i;
		}

		// folyt kov a végével.
	}
}
