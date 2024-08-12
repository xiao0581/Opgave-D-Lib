using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ParticipantsLib
{
    public class ParticipantsRepository
    {

        public int _nextId = 6;
        public List<Participants> participants = new(){
         new Participants(){Id=1,Name="Rene holten",Age=35,Country="Denmark"},
         new Participants(){Id=2,Name="Anne Marie",Age=32,Country="Denmark"},
         new Participants(){Id=3,Name="Armand Duplantis",Age=24,Country="Sweden"},
         new Participants(){Id=4,Name="LeBron james",Age=35,Country="USA"},
         new Participants(){Id=5,Name="Kevin Durant",Age=35,Country="USA"}
        };

        public List<Participants> GetAll()
        {
            return new List<Participants>(participants);
        }
        public Participants? GetById(int id)
        {
           Participants p= participants.Find(participant => participant.Id == id);
            if (p == null)
            {
                return null;
            }
            else { 
            return p;
            }

           
        }


        public Participants Add(Participants participant)
        {

            participant.validateName();
            participant.validateCountry();
            participant.validateAge();
            participant.Id = _nextId++;
            participants.Add(participant);
            return participant;
        }
        public Participants? Delete(int id)
        {

            Participants? participant = participants.Find(participant => participant.Id == id);
            if (participant != null)
            {
                participants.Remove(participant);
                return participant;
            }
            else
            {
                return null;
            }
            

        }
        
    }
}
