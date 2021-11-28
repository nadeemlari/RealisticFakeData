using System;

namespace RealisticFakeData
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // full name
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Income { get; set; }
    }

    public class Address
    {
        public string Add { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }

    }
}
