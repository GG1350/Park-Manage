using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Parking_Managment___Praktika
{
    internal class Program
    {
        private static Data data = new Data();
        static void Main(string[] args)
        {
            SetIOEncoding();

            DisplayMenu();

            string choice;
            bool success=true;
            string message = "";
            while ((choice = Console.ReadLine()) != "x")
            {
                switch(choice)
                {
                    case "1"://add parking
                        try
                        {
                            Parking newParking = AddNewParkingUI();
                            data.Parkings.Add(newParking);
                            data.Save();
                            message = "Успешно добавен паркинг.";
                            success = true;
                        }
                        catch(InvalidDataException e)
                        {
                            message = e.Message;
                            success = false;
                        }
                        BackToMenu(message, success);
                        break;
                    case "2"://add new vehicle
                        success = RegisterVehicleInParkingUI(data.GetAvailableParkings());
                        if (success)
                        {
                            data.Save(); message = "Автомобилът бе приет успешно.";
                            message = "Автомобилът бе приет успешно.";
                        }
                        else
                        {
                            message = "Възникна грешка при приемането на автомобилът.";
                        }
                        BackToMenu(message, success);
                        break;
                    case "3"://remove vehicle

                        
                        break;
                    case "4"://check available park spaces

                        
                        break;
                    case "5"://report for all parkings
                        
                        break;
                    case "6"://check specified parking

                        
                        break;
                    case "7"://check for parkings with same loc

                        
                        break;
                    default:
                        break;
                }
            }
        }
        private static void DisplayMenu()//The Menu from which the user will control the program
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==================[ М Е Н Ю ]===================");
            Console.WriteLine("|                                              |");
            Console.WriteLine("|  [1] ▶ Добавяне на паркинг                   |");
            Console.WriteLine("|  [2] ▶ Добавяне на ново превозно средсто     |");
            Console.WriteLine("|  [3] ▶ Премахване на превозно средство       |");
            Console.WriteLine("|  [4] ▶ Спрaвка за наличните паркоместа       |");
            Console.WriteLine("|  [5] ▶ Справка за всички паркинги            |");
            Console.WriteLine("|  [6] ▶ Справка за посочен паркинг            |");
            Console.WriteLine("|  [7] ▶ Проверка за паркинги с еднаква локация|");
            Console.WriteLine("|  [x] ▶ Изход                                 |");
            Console.WriteLine("|                                              |");
            Console.WriteLine("================================================");
            Console.ResetColor();
            Console.Write("> Изберете опция: ");
            
        }
        private static Parking AddNewParkingUI()//Adds new parking with data specified by the user
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=====[ Добави паркинг ]=====");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("Въведи локация: ");
            string loc = Console.ReadLine();

            Console.Write("Въведи брой места: ");
            int totspaces;
            if (!int.TryParse(Console.ReadLine(), out totspaces))
            {
                throw new InvalidDataException("Въвели сте невалидни данни за паркинга.");
            }

            try
            {
                Parking newParking = new Parking(loc, totspaces);
                return newParking;
            }
            
            catch (InvalidDataException e)
            {
                throw new InvalidDataException(e.Message);
            }
        }
        private static bool RegisterVehicleInParkingUI(List<Parking>availableParkings)//registers a new Vehicle with a plate number specified by the user
        {
            bool success = true;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==========[ Регистриране на превозно средство ]==========");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Списък на всички налични паркинги");
            Console.WriteLine();
            int parkID = 0;
            if (availableParkings.Count > 0)
            {
                foreach (var park in availableParkings)
                {
                    Console.WriteLine($"{++parkID:d2}.{park}");
                }
                Console.WriteLine();

                Console.Write("Въведете номера на паркинга, в който искате да регистрирате превозното средство: ");
                int SelectedParkID = int.Parse(Console.ReadLine()!) - 1;

                if (SelectedParkID < availableParkings.Count)
                {
                    Console.Write("Регистрационен номер на превозното средство: ");
                    string plateNumber = Console.ReadLine()!;

                    Parking SelectedParking = availableParkings[SelectedParkID];
                    SelectedParking.AvailableSpaces++;
                    SelectedParking.Vehicles.Add(plateNumber);
                }
                else
                {
                    success = false;
                    Console.WriteLine("[ Грешен номер на превозно средство. ]");
                }
            }
            else
            {
                success = false;
                Console.WriteLine("[ Няма налични свободни места. ]");
            }

            return success;
        }
        private static void RemoveVehicleFromParkingUI()//removes a vehicle with plate number specified by the user
        {

        }
        private static void CheckAvailableParkingSpacesUI()//checks how much available spaces are there in a said parking
        {

        }
        private static void ReportForAllParkingsUI()//gives a report for the full info of each parking
        {

        }
        private static void CheckSpecificParkingUI()//gives a full info for a specified by the user parking
        {

        }
        private static void CheckForParkingsWithSameLocUI()//checks for parkings with the same location
        {

        }

        private static void SetIOEncoding()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
        }
        private static void BackToMenu(string message, bool success = true)
        {
            Console.ForegroundColor = success ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.Write("Натиснете ENTER към меню ");
            Console.ReadLine();
            DisplayMenu();
        }

    }
}
