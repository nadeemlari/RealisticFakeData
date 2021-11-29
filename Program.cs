using System;
using System.Text.Json;
using System.Threading.Tasks;
using Bogus;

namespace RealisticFakeData
{
    internal class Program
    {
        static async Task Main()
        {
            Randomizer.Seed = new Random(100000);
            var addressFaker = new Faker<Address>()
                    .RuleFor(x=> x.AddLine1,x=> x.Address.StreetAddress())
                    .RuleFor(x=> x.City,x=>x.Address.City())
                    .RuleFor(x => x.Country, x => x.Address.Country())
                    .RuleFor(x => x.Zip, x => x.Address.ZipCode())
                ;

            var personFaker = new Faker<Person>()
                .RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Name, x => x.Person.FullName)
                .RuleFor(x => x.Email, x => x.Person.Email)
                .RuleFor(x => x.Phone, x => x.Person.Phone)
                .RuleFor(x => x.Currency, x => x.Finance.Currency().Code)
                .RuleFor(x => x.Income, x => x.Finance.Amount(2000, 3000))
                .RuleFor(x => x.Address, _=>addressFaker);


            foreach (var person in personFaker.GenerateForever())   
            {
                var text = JsonSerializer.Serialize(person);
                Console.WriteLine(text);
                await Task.Delay(200);
            }
            
            
            
            
           
        }
    }
}
