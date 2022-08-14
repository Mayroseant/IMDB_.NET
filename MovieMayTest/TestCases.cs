using System;
using Xunit;
using MovieMayDL;
using MovieMayDL.Models;

namespace MovieMayTest
{
    public class TestCases
    {
        [Fact]
        public void Test1()
        {
            User _user = new User();
            UserDL _udl = new UserDL();

            _user.Email = "mayrose@gmail.com";
            _user.Pwd = "may123";
            _user.UserRole = "Admin";
            _user.Name = "Mayrose";

            bool expected = true;

            bool actual = _udl.UserValidate(_user);

            Assert.Equal(expected, actual);
        }
    }
}
