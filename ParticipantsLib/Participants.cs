using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipantsLib
{
    public class Participants
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Country { get; set; }


        public void validateName()
        {
            if (Name is null)
            {
                throw new ArgumentNullException("name is null");
            }
            if (Name.Length < 2)
            {
                throw new ArgumentException("Name has to be at least 2 character ");
            }
        }
        public void validateAge()
        {
            if (Age < 12)
            {
                throw new ArgumentOutOfRangeException("age at least 12");
            }
        }

        public void validateCountry()
        {
            if (Country is null)
            {
                throw new ArgumentNullException("country is null");
            }
            if (Country.Length <4)
            {
                throw new ArgumentException("country has to be at least 4 character ");
            }
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}, Country: {Country}";
        }
    }
}
