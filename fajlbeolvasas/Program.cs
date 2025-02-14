namespace fajlbeolvasas
{
	internal class Program
	{

		static void Beolvasas(string filenev, List<Karakter> karakterek)
		{
			StreamReader sr = new(filenev);

			//string[] sorok = File.ReadAllLines(filenev); - első sort nem hagyja ki

			sr.ReadLine();

			while (!sr.EndOfStream)
			{
				string sor = sr.ReadLine();
				string[] szavak = sor.Split(';');

				Karakter karakter = new Karakter(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
				karakterek.Add(karakter);
			}
		}
		static void LegMagasabbEletero(List<Karakter> karakterek)
		{
			Karakter mhp = karakterek[0];
			foreach (var character in karakterek.Skip(1))
			{
				if (mhp.Eletero < character.Eletero)
				{
					mhp = character;
				}
			}
            Console.WriteLine($"\nLegmagasabb életerő: {mhp.Eletero}");
            Console.WriteLine(mhp);
        }
		static void AtlagSzint(List<Karakter> karakterek)
		{
			int szint = 0;
			foreach (var i in karakterek)
			{
				szint += i.Szint;
			}
			int atlag = szint / karakterek.Count;
            Console.WriteLine($"\nA karakterek átlagszintje: {atlag}");
        }
		static void Main(string[] args)
		{
			List<Karakter> karakterek = [];
			
			Beolvasas("karakterek.txt", karakterek);

			foreach (var item in karakterek)
			{
                Console.WriteLine(item); //Console.WriteLine(item.ToString);
			}

			LegMagasabbEletero(karakterek);
			AtlagSzint(karakterek);
		}
	}
}
