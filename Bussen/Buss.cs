using System;

namespace Bussen
{
    class Buss
    {
        // Hanterar while-loop i Run metoden
        private bool runProgram;

        // Run()
        private string runInput;

        // AddPassenger()
        private int passengerAge;
        private string passengerGender;
        private int passengerMoney;

        

        // Skapa en Passenger vektor med 25 platser
        private Passenger[] passengers = new Passenger[25];

        private int allPassengers;
        private int emptySeats;

        private int totalAge;


        // Metoden som styr hela programmet i Main
        public void Run()
        {
            runProgram = true;
            Console.WriteLine("Welcome to Bus Simulator 2020");

            Console.WriteLine("The simulation changes based on choices you can make in the menu below" +
                              "\n\nmade by Mattias Robertsson\n\n");

            // Iterera över användarens val tills den väljer att avsluta programmet
            while (runProgram)
            {
                // Visa menyn
                Console.WriteLine("\n# # # # # # # # # # # # # # # # # # # # # # #" +
                                  "\n                                             " +
                                  "\n Select menu option to influnce simulation   " +
                                  "\n                                             " +
                                  "\n Add | Delete | List | Fill | TotalAge       " +
                                  "\n AverageAge | OldAge | Genders | Poke | Sort " +
                                  "\n                   Exit                      " +
                                  "\n# # # # # # # # # # # # # # # # # # # # # # #");

                // Återställ data så inga problem uppstår om vi tar bort eller lägger till passengers
                totalAge = 0;
                emptySeats = passengers.Length - allPassengers;

                try
                {
                    runInput = Console.ReadLine();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                // Meny som låter användaren styra programmet
                switch (runInput)
                {
                    case "Exit":
                        runProgram = false;
                        break;
                    case "List":
                        ListPassengers();
                        break;
                    case "Add":
                        AddPassenger();
                        break;
                    case "TotalAge":
                        Console.WriteLine(CalcTotalAge());
                        break;
                    case "AverageAge":
                        Console.WriteLine(CalcAverageAge(CalcTotalAge()));
                        break;
                    case "OldAge":
                        Console.WriteLine(OldestPassenger());
                        break;
                    case "Fill":
                        FillBuss();
                        break;
                    case "Delete":
                        Console.WriteLine("Pick seat to delete passenger");
                        int delInput = int.Parse(Console.ReadLine());
                        DeletePassenger(delInput);
                        break;
                    case "Find":
                        Console.WriteLine("Input age to find match");
                        int findInput = int.Parse(Console.ReadLine());
                        FindAge(findInput);
                        break;
                    case "Genders":
                        PrintGenders();
                        break;
                    case "Poke":
                        Console.WriteLine("Poke a passenger based on their seat position");
                        int pokeInput = int.Parse(Console.ReadLine());
                        Poke(passengers[pokeInput]);
                        break;
                    case "Sort":
                        Console.WriteLine("Sorting passenger list...");
                        BubbleSort();
                        break;
                }
            } 
        }

        // BubbleSort kollar om värdet i en plats är större än värdet i nästa, om det är det, byt plats på dom
        // Personligen tycker jag att koden blir otroligt ful för det lilla resultat man får ut av det
        // Känns som konstigt att behöva strukturera det på detta sätt för att få ett lämpligt resultat.
        // Har inte lyckats komma fram till hur man kan Bubble Sort med tomma platser
        private void BubbleSort()
        {
            Passenger debugPassenger = new Passenger(999, "DEBUG", 999);
            // Vi kan inte sortera om en plats är tom, så vi fyller dom temporärt
            if(emptySeats > 0)
            {
                for (int i = 0; i < passengers.Length; i++)
                {
                    if (passengers[i] == null)
                        passengers[i] = debugPassenger;
                }
            }

            for (int i = 0; i < passengers.Length - 1; i++)
                for (int j = 0; j < passengers.Length - i - 1; j++)
                    if (passengers[j].GetAge() > passengers[j + 1].GetAge())
                    {
                        // swap temp and arr[i] 
                        Passenger temp = passengers[j];
                        passengers[j] = passengers[j + 1];
                        passengers[j + 1] = temp;
                    }

            // Ta bort temporära passengers
            for (int i = 0; i < passengers.Length; i++)
            {
                if(passengers[i] == debugPassenger)
                {
                    passengers[i] = null;
                }
            }
        }

        private void Poke(Passenger x)
        {
            Passenger myMethod = new Passenger();
            try
            {
                myMethod.PokePicker(x);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + " | That seat is empty!");
            }
        }

        private void PrintGenders()
        {
            try
            {
                for (int i = 0; i < passengers.Length; i++)
                {
                    if (passengers[i].GetSex() == "Male")
                        Console.WriteLine("Position: " + i + " | " + passengers[i].GetSex());
                    else if (passengers[i].GetSex() == "Female")
                        Console.WriteLine("Position: " + i + " | " + passengers[i].GetSex());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + "\nThe bus is empty! You can randomize passengers with Fill command");
            }
        }

        private void FindAge(int age)
        {
            int x = 0;
            try
            {
                for (int i = 0; i < passengers.Length; i++)
                {
                    if (passengers[i].GetAge() == age)
                        Console.WriteLine("Found a match: " + passengers[i].GetAge() + " " + passengers[i].GetSex() + " " + passengers[i].GetMoney() + " | DEBUG: " + i);
                    else
                        x++;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + "\nThe bus is empty! You can randomize passengers with Fill command");
            }
            if (x == passengers.Length)
                Console.WriteLine("Did not find a match, try again!");
        }

        // Hitta äldsta passenger
        private int OldestPassenger()
        {
            // Vi måste initialisera variablerna för att villkorssatsen ska fungera korrekt
            int age = 0;
            int oldest = 0;

            for (int i = 0; i < passengers.Length; i++)
            {
                age = passengers[i].GetAge();

                if (age > oldest)
                    oldest = age;
            }

            return oldest;
        }

        // Räknar ut genomsnittliga åldern
        private int CalcAverageAge(int totalAge)
        {
            int x = totalAge / allPassengers;
            return x;
        }

        // Visar att jag vet hur man använder foreach-loop, men jag föredrar for-loop
        private int CalcTotalAge()
        {
            foreach(Passenger x in passengers)
            {
                if (x != null)
                    totalAge += x.GetAge();
            }

            return totalAge;
        }
        
        // Lägg till passenger på första lediga plats
        private void AddPassenger()
        {
            if(emptySeats > 0)
            {
                Console.WriteLine("Please enter Age, Gender (Male or Female) and Money of Passenger, in correct order.");

                try
                {
                    passengerAge = int.Parse(Console.ReadLine());
                    passengerGender = Console.ReadLine();
                    passengerMoney = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                for (int i = 0; i < passengers.Length; i++)
                {
                    if (passengers[i] == null)
                    {
                        passengers[i] = new Passenger(passengerAge, passengerGender, passengerMoney);
                        // Ser till att vi inte lägger till mer än en passenger
                        i = passengers.Length;
                        allPassengers++;
                    }
                }
            }
            else
                Console.WriteLine("The bus is full!");  
        }

        // Tar bort passenger från specifik position
        private void DeletePassenger(int seatPosition)
        {
            // Vi kan bara ta bort passenger om platsen inte är ledig
            if (passengers[seatPosition] != null)
            {
                // Återställ data i vektor positionen till null, noll, zero, nada
                passengers[seatPosition] = null;
                // Behövs för att räkna ut hur många lediga platser som finns på bussen
                allPassengers--;
            } 
        }

        // Fyll bussen med slumpade passengers
        private void FillBuss()
        {
            // Kolla om det finns lediga platser
            if(emptySeats > 0)
            {
                Console.WriteLine("Filling the bus with random people . . .");

                // Iterera över passengers vektorn och skapa en slumpad passenger ifall platsen är ledig
                for (int i = 0; i < passengers.Length; i++)
                {
                    if (passengers[i] == null)
                    {
                        Random rng = new Random();

                        int passengerAge = rng.Next(14, 77);
                        int selectGender = rng.Next(1, 3);
                        int passengerMoney = rng.Next(1, 101);

                        switch (selectGender)
                        {
                            case 1:
                                passengerGender = "Male";
                                break;
                            case 2:
                                passengerGender = "Female";
                                break;
                        }

                        passengers[i] = new Passenger(passengerAge, passengerGender, passengerMoney);
                        allPassengers++;
                    }
                }
            }
            else
                Console.WriteLine("The bus is full!");
        }

        // Iterera över Passengers vektorn och skriv ut relevant data
        private void ListPassengers()
        {
            Console.WriteLine("Passenger (Age, Gender, Money)");

            for (int i = 0; i < passengers.Length; i++)
            {
                if (passengers[i] != null)
                {
                    Console.WriteLine(passengers[i].GetAge() + " " + passengers[i].GetSex() + " " + passengers[i].GetMoney() + " | Position: " + i);
                }
            }

            Console.WriteLine("Passenger amount: " + allPassengers + " | Empty seats: " + emptySeats);
        }
    }
}
