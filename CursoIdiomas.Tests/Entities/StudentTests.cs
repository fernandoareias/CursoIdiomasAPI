using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.CourseContext.Entities;
using Domain.CourseContext.ValueObjects;

namespace CursoIdiomas.Tests
{
    [TestClass]
    public class StudentTests
    {
        // Deve retorna se aluno for valido.
        [TestMethod]
        public void ShouldReturnIfStudentIsValid()
        {
            //       var name = new Name("Bob", "Bobson");
            //     var email = new Email("bob.bobson@gmail.com");
            //    var student = new Student(name, email);

            //   Assert.AreEqual(true, student.IsValid);
        }

        // Deve retorna se aluno for invalido.
        [TestMethod]
        public void ShouldReturnIfStudentIsInvalid()
        {
            var name = new Name("", "");
            var email = new Email("");
            var student = new Student(name, email);

            Assert.AreEqual(false, student.IsValid);
        }

        [TestMethod]
        public void StudentShouldBelongToAnyClasse()
        {
            Assert.Fail();
        }


        [TestMethod]
        public void ShouldReturnInvalidIfStudentCreateNoClass()
        {
            Assert.Fail();
        }



    }
}
