/*Hjälpkod för att komma igång
 * Notera att båda klasserna är i samma fil för att det ska underlätta.
 * Om programmet blir större bör man ha klasserna i separata filer såsom jag går genom i filmen
 * Då kan det vara läge att ställa in startvärden som jag gjort.
 * Man kan också skriva ut saker i konsollen i konstruktorn för att se att den "vaknar
 * Denna kod hjälper mest om du siktar mot betyget E och C
 * För högre betyg krävs mer självständigt arbete
 */
using System;
using System.Collections.Generic;
//Nedan är namnet på "namespace" - alltså projektet. 
//SKapa ett nytt konsollprojekt med namnet "Bussen" så kan ni kopiera över all koden rakt av från denna fil
//Fredrik Törnberg, programmering 1, Hermods, 2101014.
namespace Bussen
{
	enum Gender //enum för kön
	{
		Male,
		Female,
		Other
	}
	class Person    //Klass för person
	{

		public Person(Gender _gender, int _age)  //Konstruktor för Person
		{
			Gender = _gender;
			Age = _age;
		}
		public Gender Gender //Egenskap för kön
		{
			get;
			set;
		}
		public int Age //Egenskap för ålder
		{
			get;
			set;
		}
	}
	class Buss
	{
		Person[] passagerare = new Person[25]; // Skapar en vektor för passagerare.
		public int antal_passagerare;
		int ageMax = 100; // Sätter en maxålder för att åka med, kanske inte så realistiskt att en person över 100 åker buss på egen hand. 

		public void Run() 
		{
			Console.Clear(); // Varje gång Run() kallas rensas konsollen och man får en ren meny.
			Console.WriteLine("\n - Welcome to the awesome Buss-simulator - ");
			
			while (true) // While-loop 
			{
				// Huvudmeny för programmet Bussen.

				Console.WriteLine("\n - Alternativ - ");
				Console.WriteLine("\n [ 1 ] - Lägg till passagerare.");
				Console.WriteLine(" [ 2 ] - Skriv ut alla passagerare.");
				Console.WriteLine(" [ 3 ] - Beräkna total ålder.");
				Console.WriteLine(" [ 4 ] - Beräkna genomsnittsålder.");
				Console.WriteLine(" [ 5 ] - Sök efter den äldsta passageraren.");
				Console.WriteLine(" [ 6 ] - Sök efter ålder inom ett intervall.");
				Console.WriteLine(" [ 7 ] - Sök efter könstillhörighet.");
				Console.WriteLine(" [ 8 ] - Sortera bussen efter ålder (bubble sort).");
				Console.WriteLine(" [ 9 ] - Avstigande passagerare.");
				Console.WriteLine("\n [ESC] - Återgå till huvudmenyn.");
				Console.WriteLine(" [ Q ] - Avsluta programmet.");

				ConsoleKeyInfo val = Console.ReadKey(true); // Tar användarens tangenttryck som input och lagrar den i variabeln "val"
				switch (val.Key) // Switch/Case-sats för att välja i menyn.
				{
					case ConsoleKey.D1:  // Om användaren trycker på tangent "1"
						{
							Add_passenger(); // Kör metoden Add_passenger()
							break;  // avbryt loopen
						}
					case ConsoleKey.D2:
						{
							Print_buss();
							break;
						}
					case ConsoleKey.D3:
						{
							Calc_total_age();
							break;
						}
					case ConsoleKey.D4:
						{
							Calc_average_age();
							break;
						}
					case ConsoleKey.D5:
						{
							Print_max_age();
							break;
						}
					case ConsoleKey.D6:
						{
							Find_age();
							break;
						}
					case ConsoleKey.D7:
						{
							Print_sex();
							break;
						}
					case ConsoleKey.D8:
						{
							Sort_buss();
							break;
						}
					case ConsoleKey.D9:
						{
							Getting_off();
							break;
						}
					case ConsoleKey.Escape: // Escapetangenten rensar skärmen och visar menyn på nytt.
						{
							Run();
							break;
						}
					case ConsoleKey.Q: // Q-tangenten avslutar programmet.
						{
							Environment.Exit(0);
							break;
						}
					default:  // Om inget giltigt val görs skrivs "Gör ett val" ut och menyn börjar om.
						{
							Console.WriteLine("Gör ett val.");
							Run();
							break;
						}
				}
			}
		}
		
		public void Add_passenger()  // Metod för att lägga till en ny passagerare (påstigning)
		{
			
			string newGender = string.Empty; // Skapar en tom strängvariabel för newGender.
			ConsoleKeyInfo val; // Sätter en variabel för att lagra värdet för knapptryckning.

			Console.Clear();  // Rensar skärmen för en renare inmatning.
			while (true)    // Tar emot tangent för könstillhörighet
			{
				Console.WriteLine("\n - Könstillhörighet, [M]an, [K]vinna, [A]nnan - ");  // Text till användaren som även specificerar giltiga svar
				try  // Tryblock för inmatning av kön.
				{
					val = Console.ReadKey(true);  // Tar emot tangent från användaren, lagrar i variabeln "val"
					newGender = val.Key.ToString(); // konverterar knapptryckningen till string och lagrar i "newGender"
				}
				catch (Exception ex) // Undantagshantering 
				{
					Console.WriteLine(ex.Message);
				}

				if (newGender == "M" || newGender == "K" || newGender == "A")  // OM användaren har matat in giltiga alternativ 
				{
					break;  // Gå vidare i koden.
				}
				else
				{
					Console.WriteLine("Endast M, K eller A tillåtet"); // ANNARS meddela att användaren har gjort felaktigt val. 
				}
			}

			int newAge;
			while (true)    //Input för ålder
			{
				try  // Try-block för inmatning av ålder.
				{
					Console.Write("\n - Du har angett könstillhörighet {0}, ange ålder: ", newGender); // Text till användaren, som även presenterar vilken könstillhörighet man valde i förra menyn.
					newAge = int.Parse(Console.ReadLine()); // Sätter int-varibeln "newAge" till värdet som användaren skriver in. 
					if (newAge > ageMax) // OM newAge är mer än ageMax.
					{
						Console.WriteLine("Vi kör tyvärr inte personer över {0}", ageMax); // Text till användaren och presenterar värdet i ageMax
					}
					else
					{
						break;  // ANNARS bryt loopen och fortsätt.
					}

				}
				catch // Catch-meddelande till användaren. 
				{
					Console.WriteLine("\n - Ålder endast tillåten att ange i heltal. - ");
				}

			}

			for (int i = 0; i < passagerare.Length; i++)  // FOR-loop för att lagra in passageraren i vektorn.
			{
				if (passagerare[i] == null) //OM positionen i vektorn är lika med null (platsen är tom).
				{
					Gender gender; // Gör en variabel med datatypen "Gender" 
					switch (newGender) // Switch/case som läser värdet i variabeln newGender 
					{
						case "M":  // Om värdet i newGender är "M" så lagras variabeln "gender" som Gender.Male
							gender = Gender.Male;
							break;
						case "K":  // Om värdet i newGender är "K" så lagras variabeln "gender" som Gender.Female
							gender = Gender.Female;
							break;
						default:  // Om värdet i newGender är "A" så lagras variabeln "gender" som Gender.Other
							gender = Gender.Other;
							break;
					}

					passagerare[i] = new Person(gender, newAge); // Lagrar den nya passageraren i vektorn på första lediga plats.
					break;
				}
				else if (i == passagerare.Length - 1) // om ingen ledig plats hittas i vektorn så meddelas att bussen är full. 
				{
					Console.Clear();
					Console.WriteLine("\n - Ingen påstigning, bussen är full med {0} passagerare - ", passagerare.Length);
				}

			}
		}

		public void Print_buss() // Skriver ut och visar samtliga passagerare i bussen. 
		{

			Console.Clear();
			Console.WriteLine("\n - Lista på samtliga passagerare -");
			Console.WriteLine("");
			int platsNummer = 0; // variabel för platsnummer.
			foreach (Person i in passagerare)  // FÖRVARJE position i vektorn passagerare.
			{
				platsNummer++;  // Räknar upp variabeln platsNummer vid varje iteration.
				if (i == null) //OM positionen i vektorn är lika med null (platsen är tom).
				{
					Console.WriteLine(" - Sittplats	{0} är tom.", platsNummer); // Skriv ut meddelande för den platsen.
				}
				else  // ANNARS kontrollera vilken könstillhörighet, 
				{
					string gender = string.Empty;  // Skapar en string-variabel.
					switch (i.Gender) // Switch/case som läser könstillhörighet för positionen, och tilldelar värdet till variabeln gender.
					{
						case Gender.Male:
							gender = "man";
							break;
						case Gender.Female:
							gender = "kvinna";
							break;
						case Gender.Other:
							gender = "person";
							break;
					}
					Console.WriteLine(" - På sittplats {0} sitter det en {1}, {2} år gammal.", platsNummer, gender, i.Age); // Utsskrift för att presentera upptagna platser i bussen.
				}
			}
		}

		public void Calc_total_age() // Beräknar och visar den totala åldern i bussen.
		{

			Console.Clear();
			Console.WriteLine("\n - Sammanlagd ålder på samtliga passagerare -");
			int x = 0;  // Sätter int variabeln x med värdet 0
			foreach (Person i in passagerare)  //FÖRVARJE position i vektorn.
			{
				if (i == null) //OM positionen i vektorn är lika med null (platsen är tom).
				{
					continue; // fortsätt platsen är tom.
				}
				else // ANNARS
				{
					x += i.Age;  // adderar värdet i.Age för varje position i vektorn med x ( x = x + i)
				}
			}
			Console.WriteLine("\n - Den sammanlagda åldern är: {0} år. - ", x);  // presenterar den totala åldern i bussen.
		}


		public void Calc_average_age() // Beräknar genomsnittlig ålder i bussen, ett alternativ hade kanske varit att använda "Calc_total_age()" och dividerat det resultatet på antal passagerare. 
		{
		
			Console.Clear();
			Console.WriteLine("\n - Genomsnittlig ålder av samtliga passagerare -");
			double x = 0; // Sätter double variabeln med värdet 0
			antal_passagerare = 0; // Variabel för att räkna antal passagerare.
			foreach (Person i in passagerare)  //FÖRVARJE position i vektorn.
			{
				if (i == null) //OM positionen i vektorn är lika med null (platsen är tom).
				{
					continue; // fortsätt platsen är tom.
				}
				else // ANNARS
				{
					x += i.Age;  // adderar värdet i.Age för varje position i vektorn med x ( x = x + i)
					antal_passagerare++; // Räknar upp antal passagerare.
				}
			}
			Console.WriteLine("\n Den genomsnittliga passageraren är " + Math.Round(x / antal_passagerare, 2) + " år gammal."); // Skriver ut text samt beräknar genomsnittsåldern för passagerarna, presenterar åldern med två decimaler.
		}

		private Person Max_age()  // Metod för att få fram den äldsta passageraren.
		{
		
			Person oldestPerson = null; // Skapar variabeln oldestPerson med datatypen Person tilldelar värdet null.

			foreach (Person i in passagerare) // FÖRVARJE person i vektorn passagerare
			{
				if (i == null) //OM positionen i vektorn är lika med null (platsen är tom).
				{
					continue; // fortsätt, platsen är tom.
				}
				else if (oldestPerson == null || i.Age > oldestPerson.Age) // ANNARS OM variabeln oldestPerson ÄR LIKA MED null ELLER i.Age ÄR MER ÄN oldestPerson.Age 
																		   // (Det första villkoret är utifall det bara är en person i bussen, vid första jämförelsen har inte oldestPerson fått något värde än)
				{
					oldestPerson = i; // Sätter värdet på oldestPerson till värdet av i.
				}
			}
			return oldestPerson; // Returnerar värdet av oldestPerson.
		}

		public void Print_max_age() //skapade en metod för att skriva ut äldsta passageraren, den hämtar värdet från "Max_age()"
		{
			Console.Clear();
			Console.WriteLine("\n - Äldsta passagerare -");
			var oldestPassenger = Max_age(); // Anropar metoden Max_age() och sätter variabeln oldestPassenger med det returnerade värdet 
			if (oldestPassenger == null) // OM oldestPassenger ÄR LIKA MED null
			{
				Console.WriteLine("Bussen är tom"); // Skriv ut att bussen är tom.
			}
			else // ANNARS
			{
				Console.WriteLine("\n - Den äldsta passageraren är: {0} år. -", oldestPassenger.Age); // Presenterar åldern på den äldsta passageraren.
			}
		}
		
		public void Find_age() // Sök efter passagerares ålder inom ett valfritt intervall.
		{
		
			Console.Clear();
			// Variabler för max och min värde i sökningen samt platsNummer.
			int searchHigh = 0; 
			int searchLow = 0;
			int platsNummer = 0;

			while (true) // While-loop för sökningen. 
			{
				Console.WriteLine("\n - Sök på ålder inom ett intervall -");
				try // Try/catch-block för att se till att man bara använder siffror i sökningen. 
				{
					Console.Write("\n Skriv in den ålder du vill söka FRÅN: ");
					searchLow = int.Parse(Console.ReadLine());  // Sätter värdet på inmatningen till variabel att söka FRÅN.
					Console.Write("\n Skriv in den ålder du vill söka TILL: ");
					searchHigh = int.Parse(Console.ReadLine()); // Sätter värdet på inmatningen till variabel att söka TILL
					break; // Bryter loopen vid lyckad inmatning.
				}
				catch //när inget heltal har inmatats.
				{
					Console.WriteLine("Endast siffror tack!"); // Skriver ut förklaring till användaren.
				}
			}
			Console.WriteLine(""); // För att få ett mellanrum mellan sökdelen och presentationen av passagerare.
			foreach (Person i in passagerare) // FÖRVARJE person i vektorn passagerare.
			{
				platsNummer++; // Räknar upp platsNummer
				if (i == null) //OM positionen i vektorn är lika med null (platsen är tom).
				{
					continue; // Fortsätt, platsen är tom.
				}
				if (i.Age >= searchLow && i.Age <= searchHigh) // OM ålder på passagerare är inom önskat intervall.
				{
					Console.WriteLine(" - Vi hittade följande passagerare: {0} år, på plats {1}", i.Age, platsNummer); // Skriv ut passageraren.
				}

			}
		}

		public void Sort_buss() // Sorterar bussen med bubble sort, jag valde att sätta de äldsta passagerarna längst fram i bussen och de yngsta längst bak, det är ju ändå så det oftast ser ut i bussarna (tomma platser sorteras längst bak).
		{

			int max = passagerare.Length - 1; // sätter i till värdet för antal positioner i vektorn, -1 för att hamna rätt i index.

			for (int i = 0; i < max; i++) // Den yttre loopen går igenom hela listan
			{
				// Den inre går igenom element för element. 
				int nrLeft = max - i; // Hur många element som inte redan är färdigsorterade.

				for (int j = 0; j < nrLeft; j++)
				{
					var passagerareX = passagerare[j]; // tilldelar passagerareX en plats i vektorn
					var passagerareY = passagerare[j + 1]; // tilldelar passagerareY platsen efter passagerareX (passagerareX + 1)
					var passagerareX_age = passagerareX == null ? -1 : passagerareX.Age; // Om passagerareX ÄR LIKA MED null, då är det en tom plats, flytta bakåt, ANNARS är passagerareX_age LIKA MED passagerareX.Age.
					var passagerareY_age = passagerareY == null ? -1 : passagerareY.Age;

					if (passagerareX_age < passagerareY_age) // jämför ålder på passagerareX och passagerareY
					{
						// Byt plats på passagerarna.
						var temp = passagerare[j];
						passagerare[j] = passagerare[j + 1];
						passagerare[j + 1] = temp;
					}
				}
			}
			Print_buss(); // Använder metoden "print_bus()" för att skriva ut sorteringen.
		}

		//Metoder för betyget A

		public void Print_sex()
		{

			Console.Clear();
			Console.WriteLine("\n - Lista på könstillhörighet passagerare -");
			Console.WriteLine(""); // Tom rad för att skapa lite mellanrum.
			int platsNummer = 0; // Sätter variabeln platsNummer till 0
			foreach (Person i in passagerare)  // FÖRVARJE position i vektorn passagerare
			{
				platsNummer++; // Räknar upp variabeln platsNummer för varje iteration.
				if (i == null) //OM positionen i vektorn ÄR LIKA MED null (platsen är tom).
				{
					Console.WriteLine("Sittplats {0} är tom.", platsNummer);
				}
				else  // ANNARS 
				{
					string gender = string.Empty; // Sätter sträng-variabeln till empty
					switch (i.Gender) // Switch/case som använder värdet i i.Gender för att sätta variabeln gender.
					{
						case Gender.Male:
							gender = "man";
							break;
						case Gender.Female:
							gender = "kvinna";
							break;
						case Gender.Other:
							gender = "person";
							break;
					}
					Console.WriteLine("På sittplats {0} sitter det en {1}.", platsNummer, gender); // Skriver ut plats och könstillhörighet på passageraren.
				}

			}
		}
		
		public void poke()
		{
			//Betyg A
			//Vilken passagerare ska vi peta på?
			//Denna metod är valfri om man vill skoja till det lite, men är också bra ur lärosynpunkt.
			//Denna metod ska anropa en passagerares metod för hur de reagerar om man petar på dom (eng: poke)
			//Som ni kan läsa i projektbeskrivningen så får detta beteende baseras på ålder och kön.
		}

		public void Getting_off()
		{
			
			Console.Clear();
			int exitingPassenger = 0;  
						
			Print_buss(); // anropar metoden print_bus() för att skriva ut passagerarna.
			Console.WriteLine("Skriv vilket platsnummer som lämnar bussen:");
            while (true)
            {
                try
                {
					exitingPassenger = Convert.ToInt32(Console.ReadLine()); // Tilldelar värdet på inmatningen till variabeln exitingPassenger.
					passagerare[exitingPassenger - 1] = null; // sätter platsen (-1 för att hamna rätt i index) till null (tom), vid en påstigning efter detta tar den nya passageraren första tomma plats. 
					break;
				}
                catch
                {
					Console.WriteLine("\n Endast siffror tack! ");
                }
                
            }
		}

		class Program
		{
			public static void Main(string[] args)
			{
				Console.Clear();
				Console.SetWindowSize(70, 50);
				Console.BackgroundColor = ConsoleColor.Gray;
				Console.ForegroundColor = ConsoleColor.Black;
				var minbuss = new Buss();
				minbuss.Run();

				Console.Write("Press any key to continue . . . ");
				Console.ReadKey(true);
			}
		}
	}
}