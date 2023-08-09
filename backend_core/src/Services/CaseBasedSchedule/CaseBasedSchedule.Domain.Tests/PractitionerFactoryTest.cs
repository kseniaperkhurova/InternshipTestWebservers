using CaseBasedSchedule.Domain.Interfaces;
using Moq;
using NUnit.Framework;
using CaseBasedSchedule.Domain.Fcatories;
using static CaseBasedSchedule.Domain.Entities.Practitioner;
using CaseBasedSchedule.Domain.Entities;
using CaseBasedSchedule.Domain.ValueObjects;
using CaseBasedSchedule.Domain.Enums;

namespace CaseBasedSchedule.Tests.Domain.Factories
{
    [TestFixture]
    public class PractitionerFactoryTests
    {
        private MockRepository _mockRepository;
        private IPractitionerFactory _practitionerFactory;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Default);
            _practitionerFactory = new PractitionerFactory();
        }

        [Test]
        public void CreatePractitioner_Should_ReturnNewPractitioner()
        {
            // Arrange
            var displayName = Guid.NewGuid().ToString();
            var discipline = new Discipline(Speciality.Fysiotherapeut);

            // Act
            var result = _practitionerFactory.CreatePractitioner(displayName, discipline);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<Practitioner>(result);
            Assert.AreEqual(displayName, result.DisplayName);
            Assert.AreEqual(discipline, result.Discipline);
        }
    }
}
