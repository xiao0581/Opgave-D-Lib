using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipantsLib
{
    public class ParticipantsRepositoryDb
    {
        private readonly ParticipantsDbContext _context;

        public ParticipantsRepositoryDb(ParticipantsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Participants> GetAll()
        {
            return _context.participantss.ToList();
        }

        public Participants? GetById(int id)
        {
            return _context.participantss.Find(id);
        }

        public Participants Add(Participants participant)
        {

             _context.participantss.Add(participant);
            _context.SaveChanges();
            return participant;
        }

        public Participants? Delete(int id)
        {
            Participants? participant = _context.participantss.Find(id);
            if (participant != null)
            {
                _context.participantss.Remove(participant);
                _context.SaveChanges();
            }
            return participant;
        }   
    }
}
