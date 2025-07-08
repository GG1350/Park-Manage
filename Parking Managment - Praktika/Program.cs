using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            while ((choice = Console.ReadLine()) != "x")
            {
                switch (choice)
                {
                    case "1"://adds new parking
                        AddNewParkingUI();
                        break;
                    case "2"://adds new vehicle to parking
                        RegisterVehicleInParkingUI();
                        break;
                    case "3"://removes vehicle from parking
                        RemoveVehicleFromParkingUI();
                        break;
                    case "4"://checks available parking spaces for each parking
                        CheckAvailableParkingSpacesUI();
                        break;
                    case "5"://gives report for all parkings
                        ReportForAllParkingsUI();
                        break;
                    case "6"://gives info for specific parking by ID
                        CheckSpecificParkingUI();
                        break;
                    case "7"://checks for parkings with the same location
                        CheckForParkingsWithSameLocUI();
                        break;
                    case "8"://removes parking by ID
                        RemoveParkingUI();
                        break;
                    default://gives error message for invalid input
                        Console.WriteLine("Невалиден избор.");
                        break;
                }
            }
        }

        private static void DisplayMenu()//the menu used by the user
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("==================[ М Е Н Ю ]===================");
            Console.WriteLine("| [1]  Добавяне на паркинг                     |");
            Console.WriteLine("| [2]  Добавяне на ново превозно средство      |");
            Console.WriteLine("| [3]  Премахване на превозно средство         |");
            Console.WriteLine("| [4]  Справка за наличните паркоместа         |");
            Console.WriteLine("| [5]  Справка за всички паркинги              |");
            Console.WriteLine("| [6]  Справка за посочен паркинг              |");
            Console.WriteLine("| [7]  Проверка за паркинги с еднаква локация  |");
            Console.WriteLine("| [8]  Премахване на паркинг                   |");
            Console.WriteLine("| [x]  Изход                                   |");
            Console.WriteLine("================================================");
            Console.ResetColor();
            Console.Write("> Изберете опция: ");
        }

        private static void AddNewParkingUI()//the UI for adding a new parking
        {
            Console.Write("Въведете локация: ");
            string location = Console.ReadLine();

            Console.Write("Въведете брой паркоместа: ");
            if (int.TryParse(Console.ReadLine(), out int spaces))//check for wrong input and if there is gives a message
            {
                string newId = (data.Parkings.Count + 1).ToString();
                Parking newParking = new Parking(location, spaces)
                {
                    ParkingID = newId
                };
                data.Parkings.Add(newParking);
                data.Save();
                BackToMenu("Паркингът беше добавен успешно.");
            }
            else
            {
                BackToMenu("Невалиден брой паркоместа.", false);
            }
        }

        private static void RegisterVehicleInParkingUI()//the UI for registering a vehicle in a parking
        {
            Console.WriteLine("Изберете паркинг по ID:");
            foreach (var p in data.Parkings)
            {
                Console.WriteLine($"ID: {p.ParkingID} | {p.Location} | Свободни: {p.AvailableSpaces}");
            }

            string id = Console.ReadLine();
            var parking = data.Parkings.FirstOrDefault(p => p.ParkingID == id);

            if (parking == null)//checks if the ID is valid
            {
                BackToMenu("Невалиден ID на паркинг.", false);
                return;
            }

            if (parking.AvailableSpaces == 0)//checks if there are available spaces in the parking
            {
                BackToMenu("Няма свободни места в този паркинг.", false);
                return;
            }

            Console.Write("Въведете регистрационен номер: ");
            string plate = Console.ReadLine();

            if (parking.Vehicles.Contains(plate))//checks if the vehicle is already registered in the parking
            {
                BackToMenu("Този номер вече е регистриран.", false);
                return;
            }

            parking.Vehicles.Add(plate);
            parking.AvailableSpaces--;
            data.Save();
            BackToMenu("Превозното средство беше регистрирано.");

        }

        private static void RemoveVehicleFromParkingUI()//the UI for removing a vehicle from a parking
        {
            Console.Write("Въведете регистрационен номер: ");
            string plate = Console.ReadLine();

            foreach (var parking in data.Parkings)
            {
                if (parking.Vehicles.Contains(plate))
                {
                    parking.Vehicles.Remove(plate);
                    parking.AvailableSpaces++;
                    data.Save();
                    BackToMenu("Превозното средство беше премахнато.");
                    return;
                }
            }

            BackToMenu("Превозното средство не беше намерено.", false);
        }

        private static void CheckAvailableParkingSpacesUI()//the UI for checking available parking spaces for all parkings
        {
            foreach (var p in data.Parkings)
            {
                Console.WriteLine($"{p.Location} ({p.ParkingID}) - Свободни места: {p.AvailableSpaces}/{p.TotalSpaces}");
            }
            BackToMenu("Справката приключи успешно.");
        }

        private static void ReportForAllParkingsUI()//outputs a report for all parkings
        {
            
        }

        private static void CheckSpecificParkingUI()//outputs information for a specific parking by ID
        {
            
        }

        private static void CheckForParkingsWithSameLocUI()//outputs all parkings with the same location
        {
            
        }


        private static void SetIOEncoding()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
        }

        private static void BackToMenu(string message, bool success = true)//returns to the menu 
        {
            Console.ForegroundColor = success ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine("\n" + message);
            Console.ResetColor();
            Console.WriteLine("\nНатиснете ENTER за връщане в менюто.");
            Console.ReadLine();
            DisplayMenu();
        }
        private static void RemoveParkingUI()//removes a parking by ID
        {
            
        }
    }
}
