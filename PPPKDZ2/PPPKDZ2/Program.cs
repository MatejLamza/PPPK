using PPPKDZ2.DAO;
using PPPKDZ2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPKDZ2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student dummy;
            int     odabir;

            printMenu();
            Console.WriteLine("Vas odabir: ");
            odabir = int.Parse(Console.ReadLine());
            
            while (odabir != 5)
            {
                switch (odabir)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("- - - PRIKAZ ODABRANOG STUDENTA - - -");
                        Console.WriteLine("Navedite id studenta za prikaz: ");
                        odabir = int.Parse(Console.ReadLine());
                        dummy = DbHandler.SelectStudent(odabir);
                        Console.WriteLine("- - - STUDENT - - -");
                        Console.WriteLine(dummy.ToString());
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("- - - UPIS NOVOG STUDENTA - - -");
                        dummy = upisStudenta();
                        DbHandler.InsertStudent(dummy);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("- - - UREDJIVANJE POSTOJECEG STUDENTA - - -");
                        IspisSvihStudenata();
                        Console.WriteLine("Odaberite kojeg zelite urediti: ");
                        odabir = int.Parse(Console.ReadLine());
                        dummy = DbHandler.SelectStudent(odabir);
                        Console.WriteLine("Dohvacen student: " + dummy.ToString());
                        dummy = upisStudenta();
                        DbHandler.UpdateStudent(odabir, dummy);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("- - - BRISANJE STUDENTA - - -");
                        IspisSvihStudenata();
                        Console.WriteLine("Odaberite kojeg zelite obrisati: ");
                        odabir = int.Parse(Console.ReadLine());
                        DbHandler.DeleteStudent(odabir);
                        break;
                    default:
                        break;
                }
                
                printMenu();
                Console.WriteLine("Vas odabir: ");
                odabir = int.Parse(Console.ReadLine());
            }
        }

        public static void printMenu()
        {
            Console.WriteLine("- - - - I Z B O R N I K - - - -");
            Console.WriteLine("1. Prikazi odabranog studenta");
            Console.WriteLine("2. Ubaci novog studenta");
            Console.WriteLine("3. Uredi postojeceg studenta");
            Console.WriteLine("4. Obrisi studenta");
            Console.WriteLine("5. Izlaz");
        }

        public static Student upisStudenta()
        {
            Student dummy = new Student();

            Console.WriteLine("- - - UPIS STUDENTA - - -");

            Console.WriteLine("Ime: ");
            dummy.Ime = Console.ReadLine();

            Console.WriteLine("Prezime: ");
            dummy.Prezime = Console.ReadLine();

            Console.WriteLine("JMBAG: ");
            dummy.JMBAG = Console.ReadLine();

            Console.WriteLine("Email: ");
            dummy.Email = Console.ReadLine();

            return dummy;
        }

        public static void IspisSvihStudenata()
        {
            foreach (Student item in DbHandler.GetAllStudents())
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
