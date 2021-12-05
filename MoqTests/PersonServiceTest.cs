using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MoqTests
{
    [TestClass]
    public class PersonServiceTest
    {
        private readonly PersonService _sut;
        private readonly Mock<IPersonRepository> _personRepository = new Mock<IPersonRepository>();
        public PersonServiceTest()
        {
            _sut = new PersonService(_personRepository.Object);
            
        }
        [TestMethod]
        public async Task GetAsync_ShouldReturnPerson_WhenCustomerExists()
        {
            //Arrange
            string name = "Ahmed";
            Person p = new Person{Name = name, Age = 24};
            _personRepository.Setup(x => x.GetAsync(name)).ReturnsAsync(p);

            //Act
            var res = await _sut.GetAsync(name);

            //Assert
            Assert.AreEqual(name, res.Name);
        
        }
        [TestMethod]
        public async Task GetAsync_ShouldReturnNothing_WhenCustomerDoesNotExists()
        {
            //Arrange
            string name = "Ahmed";
            Person p = new Person{Name = name, Age = 24};
            _personRepository.Setup( x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(() => null);

            //Act
            var res = await _sut.GetAsync(name);

            //Assert
            Assert.IsNull(res);
        
        }
    }
}
