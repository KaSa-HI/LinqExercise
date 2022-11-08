using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //DONE: Print the Sum of numbers

            int sum = numbers.Sum();
            Console.WriteLine(sum);
            Console.WriteLine();
            //DONE: Print the Average of numbers

            double average = numbers.Average();
            Console.WriteLine(average);
            Console.WriteLine();

            //DONE: Order numbers in ascending order and print to the console

            var ascending = numbers.OrderBy(numbers => numbers);
            Console.WriteLine("Ascending Number Order: ");
            foreach (int value in ascending)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();

            //DONE: Order numbers in decsending order and print to the console

            var descending = numbers.OrderByDescending(numbers => numbers);
            Console.WriteLine("Descending Number Order: ");
            foreach (int value in descending)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();

            //DONE: Print to the console only the numbers greater than 6

            var greaterThan = numbers.Where(numbers => numbers > 6);
            Console.WriteLine("Numbers Greater Than 6");
            foreach (int i in greaterThan)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            //DONE: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            var oddsList = numbers.Where(x => (x % 2) != 0);
            Console.WriteLine("Odds Number Order: ");
            foreach (int value in oddsList.Take(4))
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();

            //DONE: Change the value at index 4 to your age, then print the numbers in decsending order

            numbers[4] = 30;
            var ageNum = numbers.OrderByDescending(numbers => numbers);
            Console.WriteLine("Descending Number Order Including Age: ");
            foreach (int value in ageNum)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //DONE: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            IEnumerable<Employee> list = employees.Where(e => e.FirstName.StartsWith("C") || e.FirstName.StartsWith("S")).OrderBy( e => e.FirstName);

            foreach (var e in list)
            {
                Console.WriteLine($"Employee: {e.FullName}");
            }
            
            Console.WriteLine();

            //DONE: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            IEnumerable<Employee> midTwenties = employees.Where(e => e.Age > 26).OrderBy(e => e.Age).ThenBy(e => e.FirstName);
            foreach (var e in midTwenties)
            {
                Console.WriteLine($"{e.Age}, Employee: {e.FullName}");
            }
            Console.WriteLine();

            Console.WriteLine(">26:");
            employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ToList().ForEach(x => Console.WriteLine(x.FullName));

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            int YOE = 0;
            int AmtEmployees = 0;
            IEnumerable<Employee> YearsOfExperience = employees.Where(e => e.YearsOfExperience <= 10).Where(e => e.Age > 35).OrderBy(e => average.CompareTo(e.Age));
            foreach (var e in YearsOfExperience)
            {
                AmtEmployees++;
                YOE = YOE + e.YearsOfExperience;
            }
            Console.WriteLine();
            Console.WriteLine($" Sum of Years of Experience = {YOE}");
            Console.WriteLine($" Average of Years of Experience = {YOE/AmtEmployees}");
            Console.WriteLine();

            //TODO: Add an employee to the end of the list without using employees.Add()

            Console.WriteLine("Added Employee:");
            var newList = employees.Append(new Employee("Kahvi", "Sabatino", 30, 0));
            newList.ToList().ForEach(x => Console.WriteLine(x.FullName));

            Console.WriteLine();
            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
