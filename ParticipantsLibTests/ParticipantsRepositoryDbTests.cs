using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParticipantsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ParticipantsLib.Tests
{
    [TestClass()]
    public class ParticipantsRepositoryDbTests
    {
        private const bool useDatabase = true;
        private static ParticipantsRepositoryDb _repo;
        private static ParticipantsDbContext _dbContext;
        [ClassInitialize]
        public static void InitOnce(TestContext context)
        {
            
                var optionsBuilder = new DbContextOptionsBuilder<ParticipantsDbContext>();
                optionsBuilder.UseSqlServer(Secrets._connectionString);
                _dbContext = new ParticipantsDbContext(optionsBuilder.Options);
                _dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Participantss");
                _repo = new ParticipantsRepositoryDb(_dbContext);
                _repo.Add(new Participants { Name = "hello", Age = 30, Country = "KINA" });
                         
        }

       

        

        [TestMethod()]
        public void AddTest()
        {
            Participants a2 = new Participants { Name = "hello", Age = 30, Country = "KINA" };
            Participants? a1 = _repo.Add(a2);
            Assert.AreEqual(a2.Name, a1.Name);
        }
        [TestMethod()]
        public void GetAllTest()
        {
            IEnumerable<Participants> p = _repo.GetAll();
            Assert.IsNotNull(p);
            Assert.AreEqual(2, p.Count());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Participants? p = _repo.GetById(1);
            Assert.IsNotNull(p);
            Assert.AreEqual("hello", p.Name);
        }

    }
}