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
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers                                                              DONE!!
            int sum = 0;
            sum = numbers.Sum();
            Console.WriteLine($"{sum}");
            double average = 0;
            average = numbers.Average();
            Console.WriteLine($"{average}");
            Console.WriteLine("------------------------------------------");


            //Order numbers in ascending order and decsending order. Print each to console.                     DONE!!
            int[] numbersAscending = new int[10];
            numbersAscending = numbers.OrderBy(c => c).ToArray();
            int[] numbersDescending = new int[10];
            numbersDescending = numbers.OrderByDescending(c => c).ToArray();
            foreach (int num in numbersAscending)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("------------------------------------------");

            foreach (int x in numbersDescending)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("------------------------------------------");

            //Print to the console only the numbers greater than 6                                              DONE!!
            foreach (int num in numbers)
                if (num > 6)
                {
                Console.WriteLine(num);
                }
            Console.WriteLine("------------------------------------------");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**    DONE!!
            foreach (int g in numbersAscending)
                if (g % 2 == 0 && g > 0)
                {
                    Console.WriteLine(g);
                }

            Console.WriteLine("------------------------------------------");


            //Change the value at index 4 to your age, then print the numbers in decsending order               DONE!!
            numbers.SetValue(40, 4);
            numbersDescending = numbers.OrderByDescending(c => c).ToArray();
            foreach (int val in numbersDescending)
            {
                Console.WriteLine(val);
            }
            Console.WriteLine("------------------------------------------");

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();
            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.                 DONE!!
            //Order this in acesnding order by FirstName.
            var filtered = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);
            Console.WriteLine("C or S employees");
            foreach (var q in filtered)
            {
                Console.WriteLine(q.FullName);
            }

            Console.WriteLine("------------------------------------------");



            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(person => person.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName).ThenBy(emp => emp.YearsOfExperience);
            foreach (var y in overTwentySix)
            {
                Console.WriteLine($"Full Name: {y.FullName} Age: {y.Age}");
            }


            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35                                           DONE!!!
            var guys = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            
                var sumOfYOE = guys.Sum(emp => emp.YearsOfExperience);
                var avgOfYOE = guys.Average(emp => emp.YearsOfExperience);
            Console.WriteLine($"SUM: {sumOfYOE} AVERAGE: {avgOfYOE}");
            Console.WriteLine("----------------------------------------------------");
            //Add an employee to the end of the list without using employees.Add()                                      DONE!!
            employees = employees.Append(new Employee("Reid", "Stewart", 40, 18)).ToList();
            foreach (var g in employees)
            {
                Console.WriteLine($"{g.FirstName} {g.LastName} {g.Age} {g.YearsOfExperience}");
            }
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
