// See https://aka.ms/new-console-template for more information
using System;
using IntroLibrary;


namespace IntroUI 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, ");
            PersonalModel p = new PersonalModel
            {
                FirstName = "Erick",
                LastName = "Munoz"
            };

            System.Console.WriteLine($"My Name is { p.FirstName } { p.LastName } ");
        }
    }
}