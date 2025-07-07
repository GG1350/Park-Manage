using System.Text;

namespace Parking_Managment___Praktika
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SetIOEncoding();

            DisplayMenu();

            string choice;
            while ((choice = Console.ReadLine()) != "x")
            {
                switch(choice)
                {
                    case "1"://add parking

                        
                        break;
                    case "2"://add new vehicle

                        
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
            Console.WriteLine("|  [6] ▶ Справка за посочен паркинг             |");
            Console.WriteLine("|  [7] ▶ Проверка за паркинги с еднаква локация|");
            Console.WriteLine("|  [x] ▶ Изход                                 |");
            Console.WriteLine("|                                              |");
            Console.WriteLine("================================================");
            Console.ResetColor();
            Console.Write("> Изберете опция: ");
            
        }
        private static void AddNewParkingUI()//Adds new parking with data specified by the user
        {

        }
        private static void RegisterVehicleInParkingUI()//registers a new Vehicle with a plate number specified by the user
        {

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

    }
}
