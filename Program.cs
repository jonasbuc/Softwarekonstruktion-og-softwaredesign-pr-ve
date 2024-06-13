using System.Diagnostics;

namespace Færdighedsprøveforår2024;

class Program
{
    static void Main(string[] args)
    {
        //makeing members 
        Members members = new Members
        {
            ID = 1,
            Name = "John C",
            Address = "123 Main St",
            Age =30,
            Phone = "555-1234",
            Email = "johndoe@example.com"
        };

       
        List<Dog> dogs = new List<Dog>();
        dogs.Add(new Dog { DogId = 1, DogName = "Fido", Race = DogRace.GoldenRetriever, YearOfBirth = 2015 });
        dogs.Add(new Dog { DogId = 2, DogName = "Buddy", Race = DogRace.LabradorRetriever, YearOfBirth = 2018 });
        dogs.Add(new Dog { DogId = 3, DogName = "Rocky", Race = DogRace.Rottweiler, YearOfBirth = 2012 });
        Booking booking = new Booking(members, DateTime.Parse("2023-03-15"), dogs);
        Console.WriteLine($"Booking for {members.Name} on {booking.Date.ToString("yyyy-MM-dd")} costs {booking.TotalPrice} DKK.");

        members.Age = 70;
        booking = new Booking(members, DateTime.Parse("2023-03-15"), dogs);
        Console.WriteLine($"Booking for {members.Name} on {booking.Date.ToString("yyyy-MM-dd")} costs {booking.TotalPrice} DKK.");

        members.Age = 17;
        try
        {
            booking = new Booking(members, DateTime.Parse("2023-03-15"), dogs);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Read
        dogs.PrintDogs();

        // Update
        Dog updatedDog = new Dog { DogId = 2, DogName = "Buddy Jr.", Race = DogRace.LabradorRetriever, YearOfBirth = 2018 };
        dogs.UpdateDog(updatedDog);

        // Read again to see the updated dog
        dogs.PrintDogs();

        // Delete
        dogs.DeleteDog(1);

        // Read again to see the deleted dog
        dogs.PrintDogs();
    }

}


