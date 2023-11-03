using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Servises;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Tests
{
    public class SocialNetworkTests
    {
        private static UserService userService;
        public SocialNetworkTests()
        {
            userService = new UserService();
        }


        [Fact]
        public void AuthenticateMustThrowUserNotFoundException()
        {
            var authenticationData = new UserAuthenticationData()
            {
                Email = "123@gmail.com",
                Password = "12345678"
            };

            Assert.Throws<UserNotFoundException>(() => userService.Authenticate(authenticationData));
        }

        [Fact]
        public void AuthenticateMustThrowWrongPasswordException()
        {
            var authenticationData = new UserAuthenticationData()
            {
                Email = "email1@gmail.com",
                Password = "12345678"
            };

            Assert.Throws<WrongPasswordException>(() => userService.Authenticate(authenticationData));
        }

        [Fact]
        public void AuthenticateMustReternNotNullUserObject()
        {
            var authenticationData = new UserAuthenticationData()
            {
                Email = "email1@gmail.com",
                Password = "11111111"
            };
            var user = userService.Authenticate(authenticationData);
            Assert.NotNull(user);
        }
    }
}
