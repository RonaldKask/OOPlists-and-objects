using System;
using System.Collections.Generic;
using System.IO;

namespace OOPListsAndObjects
{
    class Program
    {
        class Planet
        {
            string name;
            int mass;

            public Planet(string _name, int _mass)
            {
                name = _name;
                mass = _mass;
            } 

            public string Name { get { return name; } }
            public int Mass { get { return mass; } }
        }

        class ListOfPlanets
        {
            List<Planet> planets;
            int totalMass;

            public ListOfPlanets()
            {
                planets = new List<Planet>();
                totalMass = 0;
            }

            public void AddPlanetToList(string planetName, int planetMass)
            {
                Planet newPlanet = new Planet(planetName, planetMass);
                planets.Add(newPlanet);
            }

            public void PrintPlanets()
            {
                foreach(Planet planetsfromList in planets)
                {
                    Console.WriteLine($"Planet: {planetsfromList.Name}; Mass: {planetsfromList.Mass}");
                }
            }
        }
        static void Main(string[] args)
        {
            ListOfPlanets newplanetList = new ListOfPlanets();

            string filePath = @"C:\Users\opilane\samples";
            string fileName = "planets.txt";
            string fullPath = Path.Combine(filePath, fileName);

            string[] planetsFromFile = File.ReadAllLines(fullPath);

            foreach(string line in planetsFromFile)
            {
                string[] tempArray = line.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                string planetName = tempArray[0];
                int planetMass = int.Parse(tempArray[1]);
                Console.WriteLine(planetName);
                Console.WriteLine(planetMass);
                Console.WriteLine("----");

                newplanetList.AddPlanetToList(planetName, planetMass);
            }

            newplanetList.PrintPlanets();
        }
    }
}
