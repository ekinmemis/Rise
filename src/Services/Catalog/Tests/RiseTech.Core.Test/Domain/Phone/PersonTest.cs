using Rise.Tests;

using NUnit.Framework;

using Rise.Phone.Core.Domain.Phone;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Core.Test.Domain.Phone
{
    [TestFixture]
    public class PersonTest
    {
        [Test]
        public void Can_clone_person()
        {
            var Person = new Person
            {
                Id = "60045ecceb9142723a47eadb",
                Name = "Ekin",
                Surname = "Memis",
                Company = "Rise Technology",
                CreatedById = 1,
                UpdatedById = 1,
                DeletedById = 0,
                Active = true,
                Deleted = false,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow
            };

            var newPerson = Person.Clone() as Person;

            newPerson.ShouldNotBeNull();
            newPerson.Id.ShouldEqual("60045ecceb9142723a47eadb");
            newPerson.Deleted.ShouldEqual(false);
        }
    }
}
