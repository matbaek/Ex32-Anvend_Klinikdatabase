using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex32_Anvend_Klinikdatabase
{
    public class Menu
    {
        DatabaseConnection dc = new DatabaseConnection();
        public void ShowMenu()
        {
            bool menuRunning = true;
            do
            {
                menuStructure();
                Console.Write("Indtast menu punkt: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        menuRunning = false;
                        break;
                    case "1":
                        InsertAddress();
                        break;
                    case "2":
                        InsertDoctor();
                        break;
                    case "3":
                        ShowAppointment();
                        break;
                    default:
                        Console.WriteLine("Menupunktet findes ikke, prøv igen.");
                        Console.ReadLine();
                        break;
                }
            } while (menuRunning);
        }

        public void menuStructure()
        {
            List<string> menu = new List<string>()
            {
                "Indsæt adresse",
                "Indsæt læge",
                "Vis aftale"
            };

            Console.Clear();
            Console.Write("╔");
            Console.Write(new String('═', Console.WindowWidth - 3));
            Console.WriteLine("╗");
            for (int i = 0; i < menu.Count; i++)
            {
                MenuStructureSetup(i + 1 + ". " + menu[i]);
            }

            MenuStructureSetup("0. Exit");
            Console.Write("╚");
            Console.Write(new String('═', Console.WindowWidth - 3));
            Console.WriteLine("╝");
        }

        public void MenuStructureSetup(string menuPoint)
        {
            string text = "║  " + menuPoint;
            StringBuilder spaces = new StringBuilder();
            for (int i = 0; i < (Console.WindowWidth - text.Length - 2); i++)
            {
                spaces.Append(" ");
            }
            Console.WriteLine(text + spaces + "║");
        }

        //Menu metoder
        private void InsertAddress()
        {
            Console.Write("Indsæt gade: ");
            string street = Console.ReadLine();
            Console.Write("Indsæt nummer: ");
            string number = Console.ReadLine();
            Console.Write("Indsæt post nummber: ");
            string code = Console.ReadLine();
            Console.Clear();
            dc.InsertAddress(street, number, code);
        }

        private void InsertDoctor()
        {
            Console.Write("Indsæt navn: ");
            string name = Console.ReadLine();
            Console.Write("Indsæt hjemme gade: ");
            string homeStreet = Console.ReadLine();
            Console.Write("Indsæt hjemme nummer: ");
            string homeNumber = Console.ReadLine();
            Console.Write("Indsæt hjemme post nummer: ");
            string homeCode = Console.ReadLine();
            Console.Write("Indsæt hjemme by: ");
            string homeCity = Console.ReadLine();
            Console.Write("Indsæt arbejdsgade: ");
            string workStreet = Console.ReadLine();
            Console.Write("Indsæt arbejdsnummer: ");
            string workNumber = Console.ReadLine();
            Console.Write("Indsæt arbejdspost nummer: ");
            string workCode = Console.ReadLine();
            Console.Write("Indsæt arbejdsby: ");
            string workCity = Console.ReadLine();
            Console.Write("Indsæt klinik ID: ");
            int clinicID = int.Parse(Console.ReadLine());
            Console.Write("Indsæt lønramma: ");
            string salaryScale = Console.ReadLine();
            Console.Clear();
            dc.InsertDoctor(name, homeStreet, homeNumber, homeCode, homeCity, workStreet, workNumber, workCode, workCity, clinicID, salaryScale);
        }

        private void ShowAppointment()
        {
            Console.Write("Indsæt ID: ");
            int patientID = int.Parse(Console.ReadLine());
            Console.Clear();
            dc.ShowAppointment(patientID);
        }
    }
}
