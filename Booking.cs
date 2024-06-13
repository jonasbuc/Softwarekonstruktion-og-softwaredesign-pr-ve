using System;
namespace Færdighedsprøveforår2024
{
	public class Booking
	{
        public int Id { get; set; }
        public Members Member { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Dog> Dogs { get; set; }

        public Booking(Members member, DateTime date)
        {
            Member = member;
            Date = date;
            CalculatePrice();
        }

        private void CalculatePrice()
        {
            DayOfWeek day = Date.DayOfWeek;
            if (day == DayOfWeek.Monday || day == DayOfWeek.Tuesday || day == DayOfWeek.Wednesday || day == DayOfWeek.Thursday || day == DayOfWeek.Friday)
            {
                Price = 100;
            }
            else
            {
                Price = 150;
            }
        }
    
       

        public Booking(Members member, DateTime date, List<Dog> dogs)
        {
            Member = member;
            Date = date;
            Dogs = dogs;
            CalculateMemberFee();
        }

        private void CalculateMemberFee()
        {
            decimal basePrice = 1000;
            decimal additionalDogPrice = 500;
            decimal fixedPriceForFiveDogs = 2500;

            if (Member.BirthDate =< 65)
            {
                basePrice *= 0.5m;
                additionalDogPrice *= 0.5m;
                fixedPriceForFiveDogs *= 0.5m;
            }
            else
            {
              
            if (Dogs.Count == 1)
            {
                TotalPrice = basePrice;
            }
            else if (Dogs.Count > 1 && Dogs.Count < 5)
            {
                TotalPrice = basePrice + (Dogs.Count + 1) * additionalDogPrice;
            }
            else if (Dogs.Count >= 5)
            {
                TotalPrice = fixedPriceForFiveDogs;
            }

            if (Member.BirthDate >= 18)
            {
                throw new InvalidOperationException("Members must be at least 18 years old to book.");
            }
            }
        }
    }
}

