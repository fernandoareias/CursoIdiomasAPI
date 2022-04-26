using System;
using Xunit;

namespace CursoIdiomas.API.Tests.Identity
{
    public class IdentityTests
    {
        [Fact]
        public void ShouldRegisterNewUserIfNotExist()
        {
            Assert.True(1 == 2);
        }

        [Fact]
        public void NotShouldRegisterNewUserIfExist()
        {
            Assert.True(1 == 2);
        }

        [Fact]
        public void NotShouldRegisterNewUserIfEmailIsInvalid()
        {
            Assert.True(1 == 2);
        }

        [Fact]
        public void ShouldLoginIfUserAndPasswordIsValid()
        {
            Assert.True(1 == 2);
        }

        [Fact]
        public void NotShouldLoginIfUserAndPasswordIsInvalid()
        {
            Assert.True(1 == 2);
        }
    }
}
