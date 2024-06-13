using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Færdighedsprøveforår2024
{
    public enum DogRace
    {
        GoldenRetriever,
        FrenchBulldog,
        GermanShepherd,
        LabradorRetriever,
        Poodle,
        Rottweiler,
        Other
    }
    
    public class Dog
    {
        public int DogId { get; set; }
        public string DogName { get; set; }
        public DogRace Race { get; set; }
        public int YearOfBirth { get; set; }

        public override string ToString()
        {
            return $"Dog {DogId}: {DogName} ({Race}) born in {YearOfBirth}";
        }

    }

    public List<Dog> dogs = new List<Dog>();
    


    // Create
    public void AddDog(Dog dog)
    {
        dogs.Add(dog);
    }

    // Read
    public void PrintDogs()
    {
        foreach (Dog dog in dogs)
        {
            Console.WriteLine(dog.ToString());
        }
    }

    public Dog GetDog(int id)
    {
        return dogs.Find(d => d.Id == id);
    }

    // Update
    public void UpdateDog(Dog updatedDog)
    {
        Dog dog = GetDog(updatedDog.DogId);
        if (dog != null)
        {
            dog.DogName = updatedDog.DogName;
            dog.Race = updatedDog.Race;
            dog.YearOfBirth = updatedDog.YearOfBirth;
        }
    }

    // Delete
    public void DeleteDog(int id)
    {
        Dog dog = GetDog(id);
        if (dog != null)
        {
            dogs.Remove(dog);
        }
    }
}


