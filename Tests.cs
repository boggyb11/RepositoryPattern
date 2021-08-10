using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

namespace Interview
{
    [TestFixture]
    public class Tests
    {
        private readonly Repository<Storeable> repository;

        public Tests()
        {
            var entities = new List<Storeable>();
            repository = new Repository<Storeable>(entities);
        }

        [Test]
        public void Test_Repository_All_Returns_IEnumberable()
        {
            var result = repository.All();
            Assert.IsInstanceOf<IEnumerable<Storeable>>(result);
        }

        [Test]
        public void Test_Repository_Delete()
        {
            var item = new Storeable { Id = 1 };
            repository.Save(item);
            repository.Delete(1);
            var result = repository.All();
            Assert.IsFalse(result.Contains(item));
        }

        [Test]
        public void Test_Repository_Save()
        {
            var item = new Storeable { Id = 2 };
            repository.Save(item);
            var result = repository.All();
            Assert.IsTrue(result.Contains(item));
        }

        [Test]
        public void Test_Repository_Find_By_Id()
        {
            var item = new Storeable { Id = 2 };
            var item2 = new Storeable { Id = 3 };
            var item3 = new Storeable { Id = 4 };
            repository.Save(item);
            repository.Save(item2);
            repository.Save(item3);

            var result = repository.FindById(2);

            Assert.AreEqual(item, result);
        }
    }
}