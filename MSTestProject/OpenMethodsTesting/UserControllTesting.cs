using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.Implementations.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using TaskManagerBase.Implementations;
using TaskManagerBase.Interfaces;
using TaskManagerBase.Models;
using WebApi.Common;
using TaskManagerBase.Models.Shared;
using MSTestProject.Common;

namespace MSTestProject.OpenMethodsTesting
{
    [TestClass]
    public class UserControllTesting
    {
        private User? _createdUser;
        private string _login { get => _createdUser is null ? "TestUser" : string.Concat("TestUser_", Guid.NewGuid().ToString()); }
        private string _password = "TestPassword";

        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public async Task RegistrationLogInUserTest()
        {
            Assert.IsNotNull(_login);
            Assert.IsNotNull(_password);
            using (var dbConnector = new DBConnector())
            {
                _createdUser = await dbConnector.UserControll.LogIn(new LogInUser { Login = _login, Password = _password });
                Assert.IsTrue(await dbConnector.UserControll.RegistrationUser(new RegistractionUser { Login = _login, Name = "TestUser", Password = _password }));
            }
        }

        [TestMethod]
        public async Task RemoveUserTest()
        {
            using (var dbConnector = new DBConnector())
            {
                if (_createdUser is null)
                {
                    Assert.IsNotNull(_login);
                    Assert.IsNotNull(_password);
                    _createdUser = await dbConnector.UserControll.LogIn(new LogInUser { Login = _login, Password = _password });
                    Assert.IsNotNull(_createdUser);
                }
                Assert.IsTrue(await dbConnector.UserControll.RemoveUser(_createdUser.Id.ToString()));
            }
        }
    }
}