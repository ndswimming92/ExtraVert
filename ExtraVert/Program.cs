using System;
using System.Collections.Generic;
using ExtraVert;

class Program
{
    private static Random random = new Random();

    static void Main()
    {
        List<Plant> plants = new List<Plant>
        {
            new Plant
            {
                Species = "Rose",
                LightNeeds = 3,
                AskingPrice = 20.0m,
                City = "ExampleCity",
                ZIP = "12345",
                Sold = false,
                AvailableUntil = DateTime.Now.AddDays(2)
            },
            new Plant
            {
                Species = "Lily",
                LightNeeds = 4,
                AskingPrice = 15.0m,
                City = "AnotherCity",
                ZIP = "67890",
                Sold = false,
                AvailableUntil = DateTime.Now.AddDays(4)
            },
            new Plant
            {
                Species = "Tulip",
                LightNeeds = 2,
                AskingPrice = 18.0m,
                City = "CityA",
                ZIP = "11111",
                Sold = true,
                AvailableUntil = DateTime.Now.AddDays(6)
            },
            new Plant
            {
                Species = "Daisy",
                LightNeeds = 3,
                AskingPrice = 12.5m,
                City = "CityB",
                ZIP = "22222",
                Sold = false,
                AvailableUntil = DateTime.Now.AddDays(5)
            },
            new Plant
            {
                Species = "Sunflower",
                LightNeeds = 5,
                AskingPrice = 25.0m,
                City = "CityC",
                ZIP = "33333",
                Sold = true,
                AvailableUntil = DateTime.Now.AddDays(3)
            },
            new Plant
            {
                Species = "Orchid",
                LightNeeds = 4,
                AskingPrice = 30.0m,
                City = "CityD",
                ZIP = "44444",
                Sold = false,
                AvailableUntil = DateTime.Now.AddDays(8)
            },
            new Plant
            {
                Species = "Fern",
                LightNeeds = 2,
                AskingPrice = 15.0m,
                City = "CityE",
                ZIP = "55555",
                Sold = true,
                AvailableUntil = DateTime.Now.AddDays(9)
            },
            new Plant
            {
                Species = "Cactus",
                LightNeeds = 1,
                AskingPrice = 10.0m,
                City = "CityF",
                ZIP = "66666",
                Sold = true,
                AvailableUntil = DateTime.Now.AddDays(10)
            },
            new Plant
            {
                Species = "Maple",
                LightNeeds = 3,
                AskingPrice = 22.0m,
                City = "CityG",
                ZIP = "77777",
                Sold = false,
                AvailableUntil = DateTime.Now.AddDays(7)
            },
            new Plant
            {
                Species = "Bamboo",
                LightNeeds = 4,
                AskingPrice = 17.0m,
                City = "CityH",
                ZIP = "88888",
                Sold = true,
                AvailableUntil = DateTime.Now.AddDays(2)
            }
        };

        int randomIndex = random.Next(0, plants.Count);
        Plant randomPlant = plants[randomIndex];

        
        Console.WriteLine("╔════════════════════════════╗");
        Console.WriteLine("║  Welcome to the Plant App! ║");
        Console.WriteLine("╚════════════════════════════╝\n");

        Console.WriteLine($"Selected Random Plant: {randomPlant.Species} in {randomPlant.City} " +
                         $"{(randomPlant.Sold ? "was sold" : "is available")} for {randomPlant.AskingPrice} dollars");

        while (true)
        {
            // Get a new random plant for each iteration
            randomPlant = GetRandomAvailablePlant(plants);

            DisplayMenu();

            Console.Write("\nEnter your choice (1, 2, 3, 4, 5, 6, 7): ");
            string choice = Console.ReadLine();

            PerformAction(choice, plants, ref randomPlant);

            // Pause and wait for user input before clearing the console
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            Console.Clear();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Main Menu:\n");
        Console.WriteLine("1. Display all plants");
        Console.WriteLine("2. Post a plant to be adopted");
        Console.WriteLine("3. Adopt a plant");
        Console.WriteLine("4. Delist a plant");
        Console.WriteLine("5. Display random plant details");
        Console.WriteLine("6. Search for plants");
        Console.WriteLine("7. Exit\n");
    }

    static void PerformAction(string choice, List<Plant> plants, ref Plant randomPlant)
    {
        if (int.TryParse(choice, out int selectedOption) && selectedOption >= 1 && selectedOption <= 6)
        {
            switch (choice)
            {
                case "1":
                    DisplayAllPlants(plants);
                    break;
                case "2":
                    PostAPlant(plants);
                    break;
                case "3":
                    AdoptAPlant(plants);
                    break;
                case "4":
                    DelistAPlant(plants);
                    break;
                case "5":
                    randomPlant = GetRandomAvailablePlant(plants);
                    DisplayRandomPlantDetails(randomPlant);
                    break;
                case "6":
                    SearchForPlants(plants);
                    break;
                case "7":
                    Console.WriteLine("\nThank you for using the Plant App. Goodbye!");
                    Environment.Exit(0);
                    break;
            }
        }
    }

    static void DisplayAllPlants(List<Plant> plants)
    {
        Console.WriteLine("Available Plants for Adoption:\n");

        // Display only available (not sold) and not expired plants
        foreach (Plant plant in plants)
        {
            if (!plant.Sold && plant.AvailableUntil > DateTime.Now)
            {
                Console.WriteLine($"{plant.Species} in {plant.City} " +
                                  $"is available for adoption until {plant.AvailableUntil.ToShortDateString()} for {plant.AskingPrice} dollars");
            }
        }
    }

    static void PostAPlant(List<Plant> plants)
    {
        Console.WriteLine("Enter details for the new plant:");

        Console.Write("Species: ");
        string species = Console.ReadLine();

        Console.Write("Light Needs (1-5): ");
        if (int.TryParse(Console.ReadLine(), out int lightNeeds) && lightNeeds >= 1 && lightNeeds <= 5)
        {
            Console.Write("Asking Price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal askingPrice))
            {
                Console.Write("City: ");
                string city = Console.ReadLine();

                Console.Write("ZIP: ");
                string zip = Console.ReadLine();

                Console.WriteLine("Enter the expiration date for the post:");

                Console.Write("Year: ");
                if (int.TryParse(Console.ReadLine(), out int year) && year >= DateTime.Now.Year)
                {
                    Console.Write("Month: ");
                    if (int.TryParse(Console.ReadLine(), out int month) && month >= 1 && month <= 12)
                    {
                        Console.Write("Day: ");
                        if (int.TryParse(Console.ReadLine(), out int day) && day >= 1 && day <= DateTime.DaysInMonth(year, month))
                        {
                            // Create a new DateTime object for the expiration date
                            DateTime expirationDate = new DateTime(year, month, day);

                            // Create a new Plant object with user input
                            Plant newPlant = new Plant
                            {
                                Species = species,
                                LightNeeds = lightNeeds,
                                AskingPrice = askingPrice,
                                City = city,
                                ZIP = zip,
                                Sold = false, // By default, a posted plant is available
                                AvailableUntil = expirationDate
                            };

                            // Add the new plant to the plants list
                            plants.Add(newPlant);

                            Console.WriteLine("\nThe plant has been successfully posted!");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid day. Please enter a valid day for the month.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid month. Please enter a valid month (1-12).");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid year. Please enter a valid year greater than or equal to the current year.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid asking price. Please enter a valid decimal value.");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid light needs. Please enter a valid integer between 1 and 5.");
        }
    }


    static void AdoptAPlant(List<Plant> plants)
    {
        Console.WriteLine("Available Plants for Adoption:\n");

        // Display only available (not sold) plants with AvailableUntil not expired
        for (int i = 0; i < plants.Count; i++)
        {
            Plant plant = plants[i];

            if (!plant.Sold && plant.AvailableUntil >= DateTime.Now)
            {
                Console.WriteLine($"{i + 1}. {plant.Species} in {plant.City} " +
                                  $"is available for adoption until {plant.AvailableUntil.ToShortDateString()} for {plant.AskingPrice} dollars");
            }
        }

        // Ask the user to choose a plant to adopt
        Console.Write("\nEnter the number of the plant you want to adopt: ");
        if (int.TryParse(Console.ReadLine(), out int adoptionChoice) && adoptionChoice >= 1 && adoptionChoice <= plants.Count)
        {
            // Update the chosen plant's Sold property to true
            plants[adoptionChoice - 1].Sold = true;
            Console.WriteLine("\nCongratulations! You have adopted a plant.");
        }
        else
        {
            Console.WriteLine("\nInvalid choice. Please enter a valid number.");
        }
    }

    static void DelistAPlant(List<Plant> plants)
    {
        Console.WriteLine("All Plants:\n");

        for (int i = 0; i < plants.Count; i++)
        {
            Plant plant = plants[i];

            // Display all plants for delisting
            Console.WriteLine($"{i + 1}. {plant.Species} in {plant.City} " +
                              $"{(plant.Sold ? "was sold" : "is available")} for {plant.AskingPrice} dollars");
        }

        // Ask the user to choose a plant to delist
        Console.Write("\nEnter the number of the plant you want to delist: ");
        if (int.TryParse(Console.ReadLine(), out int delistChoice) && delistChoice >= 1 && delistChoice <= plants.Count)
        {
            // Remove the chosen plant from the plants list
            plants.RemoveAt(delistChoice - 1);
            Console.WriteLine("\nThe plant has been successfully delisted.");
        }
        else
        {
            Console.WriteLine("\nInvalid choice. Please enter a valid number.");
        }
    }

    static Plant GetRandomAvailablePlant(List<Plant> plants)
    {
        Plant availablePlant = null;

        while (availablePlant == null)
        {
            int randomIndex = random.Next(0, plants.Count);
            Plant randomPlant = plants[randomIndex];

            if (!randomPlant.Sold)
            {
                availablePlant = randomPlant;
            }
        }

        return availablePlant;
    }

    static void DisplayRandomPlantDetails(Plant randomPlant)
    {
        Console.WriteLine("\nRandomly Selected Plant Details:");
        Console.WriteLine($"Species: {randomPlant.Species}");
        Console.WriteLine($"Location: {randomPlant.City}, ZIP: {randomPlant.ZIP}");
        Console.WriteLine($"Light Needs: {randomPlant.LightNeeds}");
        Console.WriteLine($"Price: {randomPlant.AskingPrice} dollars");
    }

    static void SearchForPlants(List<Plant> plants)
    {
        Console.Write("Enter the maximum light needs (1-5): ");
        if (int.TryParse(Console.ReadLine(), out int maxLightNeeds) && maxLightNeeds >= 1 && maxLightNeeds <= 5)
        {
            List<Plant> searchResults = new List<Plant>();

            foreach (var plant in plants)
            {
                if (!plant.Sold && plant.LightNeeds <= maxLightNeeds)
                {
                    searchResults.Add(plant);
                }
            }

            Console.WriteLine("\nAvailable Plants with Light Needs at or below the specified level:\n");

            foreach (var result in searchResults)
            {
                Console.WriteLine($"{result.Species} in {result.City} " +
                                  $"is available for adoption for {result.AskingPrice} dollars");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid maximum light needs. Please enter a valid integer between 1 and 5.");
        }
    }

    string PlantDetails(Plant plant)
    {
        string plantString = plant.Species;

        return plantString;

    }

}