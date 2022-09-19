using System;
using System.Collections.Generic;

namespace JsonParsing
{
    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public bool Gender { get; set; }
        public int Age { get; set; }
        public List<string> Addresses { get; set; } = new();
    }
    public class Person2
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Asd { get; set; }
        public string Askjds { get; set; }
        public string Ksdlkfs { get; set; }
        public string Uskdjnkj { get; set; }

        public bool Pslkddslkf { get; set; }
        public int Msdfkj { get; set; }
        public List<string> Isdlkf { get; set; } = new();
    }
}