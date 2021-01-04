using System;

namespace Bussen
{
    class Passenger
    {
        private int age;

        public int GetAge()
        {
            return age;
        }
        public void SetAge(int x)
        {
            age = x;
        }

        private string gender;

        public string GetSex()
        {
            return gender;
        }
        public void SetSex(string x)
        {
            gender = x;
        }

        private int money;

        public int GetMoney()
        {
            return money;
        }
        public void SetMoney(int x)
        {
            money = x;
        }

        // Constructor for new passengers
        public Passenger(int age, string gender, int money)
        {
            this.age = age;
            this.gender = gender;
            this.money = money;
        }

        // Get passenger data
        public Passenger(Passenger passenger)
        {
            age = passenger.age;
            gender = passenger.gender;
            money = passenger.money;
        }

        // Empty constructor so we can use methods
        public Passenger() { }

        public void PokePicker(Passenger passenger)
        {
            if (passenger.age > 18 && passenger.age < 30)
            {
                if (passenger.gender == "Male")
                    Console.WriteLine("Hey, stop that!");
                else if (passenger.gender == "Female")
                    Console.WriteLine("Please dont");
            }

            if (passenger.age < 18)
            {
                if (passenger.gender == "Male")
                    Console.WriteLine("I dont talk to strangers!");
                else if (passenger.gender == "Female")
                    Console.WriteLine("I dont talk to strangers!");
            }

            if (passenger.age > 30)
            {
                if (passenger.gender == "Male")
                    Console.WriteLine("Dont touch me.");
                else if (passenger.gender == "Female")
                    Console.WriteLine("...");
            }
        }
    }
}
