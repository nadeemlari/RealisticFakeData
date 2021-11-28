using System;
using Bogus;

namespace RealisticFakeData
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var addressFaker = new Faker<Address>()
                    .RuleFor(x=> x.Add,x=> x.Address.FullAddress())
                    .RuleFor(x=> x.City,x=>x.Address.City())
                    .RuleFor(x => x.Country, x => x.Address.Country())
                    .RuleFor(x => x.Zip, x => x.Address.ZipCode())
                ;
            addressFaker.Locale =  "en-IN";
            var data = addressFaker.Generate();
            
            Console.Read();
        }
    }
}
