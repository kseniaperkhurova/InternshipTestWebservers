//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using CaseBasedSchedule.Application;
//using CaseBasedSchedule.Domain.Entities;
//using Moq;
//using NUnit.Framework;

//namespace CaseBasedSchedule.Tests.Application
//{
//    [TestFixture]
//    public class AppointmentRepositoryTests
//    {
//        private MockRepository _mockRepository;
//        private IAppointmentRepository _appointmentRepository;

//        [SetUp]
//        public void SetUp()
//        {
//            _mockRepository = new MockRepository(MockBehavior.Default);
//            _appointmentRepository = _mockRepository.Create<IAppointmentRepository>().Object;
//        }

//        [Test]
//        public async Task GetAllClientsAppointmentsForTimeRangeAsync_Should_ReturnCorrectAppointments()
//        {
//            // Arrange
//            var clientId = Guid.NewGuid();
//            var startDate = DateTime.Now;
//            var endDate = startDate.AddDays(1);

//            var expectedAppointments = new List<AgendaItem>()
//            {
//                new AgendaItem() { Id = Guid.NewGuid(), ClientId = clientId, StartDateTime = startDate.AddHours(1), EndDateTime = startDate.AddHours(2) },
//                new AgendaItem() { Id = Guid.NewGuid(), ClientId = clientId, StartDateTime = startDate.AddHours(3), EndDateTime = startDate.AddHours(4) },
//                new AgendaItem() { Id = Guid.NewGuid(), ClientId = clientId, StartDateTime = startDate.AddHours(5), EndDateTime = startDate.AddHours(6) }
//            };

//            _mockRepository.Setup(x => x.GetAllClientsAppointmentsForTimeRangeAsync(clientId, startDate, endDate)).ReturnsAsync(expectedAppointments);

//            // Act
//            var result = await _appointmentRepository.GetAllClientsAppointmentsForTimeRangeAsync(clientId, startDate, endDate);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.IsInstanceOf<IEnumerable<AgendaItem>>(result);
//            Assert.AreEqual(expectedAppointments.Count, result.Count);
//            CollectionAssert.AreEqual(expectedAppointments, result);
//        }

//        [Test]
//        public async Task GetAllPractitionersAppointmentsForTimeRangeAsync_Should_ReturnCorrectAppointments()
//        {
//            // Arrange
//            var practitionerId = Guid.NewGuid();
//            var startDate = DateTime.Now;
//            var endDate = startDate.AddDays(1);

//            var expectedAppointments = new List<AgendaItem>()
//            {
//                new AgendaItem() { Id = Guid.NewGuid(), PractitionerId = practitionerId, StartDateTime = startDate.AddHours(1), EndDateTime = startDate.AddHours(2) },
//                new AgendaItem() { Id = Guid.NewGuid(), PractitionerId = practitionerId, StartDateTime = startDate.AddHours(3), EndDateTime = startDate.AddHours(4) },
//                new AgendaItem() { Id = Guid.NewGuid(), PractitionerId = practitionerId, StartDateTime = startDate.AddHours(5), EndDateTime = startDate.AddHours(6) }
//            };

//            _mockRepository.Setup(x => x.GetAllPractitionersAppointmentsForTimeRangeAsync(practitionerId, startDate, endDate)).ReturnsAsync(expectedAppointments);

//            // Act
//            var result = await _appointmentRepository.GetAllPractitionersAppointmentsForTimeRangeAsync(practitionerId, startDate, endDate);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.IsInstanceOf<IEnumerable<AgendaItem>>(result);
//            Assert.AreEqual(expectedAppointments.Count, result.Count);
//            CollectionAssert.AreEqual(expectedAppointments, result);
//        }
//    }
//}
