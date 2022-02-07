using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName { get => firstName; private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!\nFirst name cannot contain fewer than 3 symbols!\nLast name cannot contain fewer than 3 symbols!\nSalary cannot be less than 650 leva!\nCarolina Richards receives 737.00 leva.");
                }
                else
                {
                    firstName = value;
                }
            } }
        public string LastName { get => lastName; private set {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!\nFirst name cannot contain fewer than 3 symbols!\nLast name cannot contain fewer than 3 symbols!\nSalary cannot be less than 650 leva!\nCarolina Richards receives 737.00 leva.");
                }
                else
                {
                    lastName = value;
                }
            } }
        public int Age { get => age; private set {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!\nFirst name cannot contain fewer than 3 symbols!\nLast name cannot contain fewer than 3 symbols!\nSalary cannot be less than 650 leva!\nCarolina Richards receives 737.00 leva.");
                }
                else
                {
                    age = value;
                }
            } }
        public decimal Salary { get => salary; private set {
                if (value < 650)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!\nFirst name cannot contain fewer than 3 symbols!\nLast name cannot contain fewer than 3 symbols!\nSalary cannot be less than 650 leva!\nCarolina Richards receives 737.00 leva.");
                }
                else
                {
                    salary = value;
                }
            } }

        public void IncreaseSalary(decimal percentage)
        {
            if(Age < 30)
            {
                Salary += Salary * (percentage / 200 );
            }
            else
            {
                Salary += Salary * percentage / 100;

            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }

    }
}
