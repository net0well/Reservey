using Application;
using Application.Guest.DTOs;
using Application.Guest.Requests;
using Domain.Entities;
using Domain.Ports;
using Moq;
using System.Threading.Tasks;

namespace ApplicationTests
{
    public class Tests
    {
        GuestManager guestManager;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public async Task CreateGuestWithValidDataShouldReturnSuccess()
        {
            var guestDto = new GuestDTO
            {
                Name = "Fulano",
                Surname = "Tal",
                Email = "fulano@tal.com.br",
                IdNumber = "abcd",
                IdTypeCode = 1
            };

            int expectedId = 222;

            var request = new CreateGuestRequest()
            {
                Data = guestDto
            };

            var repo = new Mock<IGuestRepository>();

            repo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(expectedId));

            guestManager = new GuestManager(repo.Object);

            var res = await guestManager.CreateGuest(request);
            Assert.IsNotNull(res);
            Assert.True(res.IsSuccess);
            Assert.Equals(res.Data.Id, expectedId);
        }

        [TestCase("")]
        [TestCase("a")]
        [TestCase("ab")]
        [TestCase("abc")]
        [TestCase(null)]
        public async Task ShouldReturnInvalidPersonDocumentIdExceptionWhenDocsAreInvalid(string? docNumber)
        {
            var guestDto = new GuestDTO
            {
                Name = "Fulano",
                Surname = "Tal",
                Email = "fulano@tal.com.br",
                IdNumber = docNumber,
                IdTypeCode = 1
            };

            int expectedId = 222;

            var request = new CreateGuestRequest()
            {
                Data = guestDto
            };

            var repo = new Mock<IGuestRepository>();

            repo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(expectedId));

            guestManager = new GuestManager(repo.Object);

            var res = await guestManager.CreateGuest(request);

            Assert.IsNotNull(res);
            Assert.False(res.IsSuccess);
            Assert.That(res.ErrorCode, Is.EqualTo(ErrorCodes.INVALID_PERSON_ID));
        }

        [TestCase("", "", "")]
        [TestCase(null, null, null)]
        public async Task ShouldReturnMissingRequiredInformationExceptionWhenNameSurnameEmailIsNullOrEmpty(string? name, string? surname, string? email)
        {
            var guestDto = new GuestDTO
            {
                Name = name,
                Surname = surname,
                Email = email,
                IdNumber = "abcd",
                IdTypeCode = 1
            };

            int expectedId = 222;

            var request = new CreateGuestRequest()
            {
                Data = guestDto
            };

            var repo = new Mock<IGuestRepository>();

            repo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(expectedId));

            guestManager = new GuestManager(repo.Object);

            var res = await guestManager.CreateGuest(request);

            Assert.IsNotNull(res);
            Assert.False(res.IsSuccess);
            Assert.That(res.ErrorCode, Is.EqualTo(ErrorCodes.MISSING_REQUIRED_INFORMATION));
        }

        [TestCase("abc")]
        [TestCase("asb@")]
        [TestCase(".com")]
        public async Task ShouldReturnInvalidEmailExceptionWhenEmailIsInvalid(string email)
        {
            var guestDto = new GuestDTO
            {
                Name = "Fulano",
                Surname = "Tal",
                Email = email,
                IdNumber = "abcd",
                IdTypeCode = 1
            };

            int expectedId = 222;

            var request = new CreateGuestRequest()
            {
                Data = guestDto
            };

            var repo = new Mock<IGuestRepository>();

            repo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(expectedId));

            guestManager = new GuestManager(repo.Object);

            var res = await guestManager.CreateGuest(request);

            Assert.IsNotNull(res);
            Assert.False(res.IsSuccess);
            Assert.That(res.ErrorCode, Is.EqualTo(ErrorCodes.INVALID_EMAIL_ADDRESS));
        }
    }
}