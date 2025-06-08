using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MSTestProject.Common;
using TaskManagerBase.Models;
using TaskManagerBase.Models.Shared;

namespace MSTestProject.OpenMethodsTesting
{
    [TestClass]
    public class TaskControllTesting
    {
        private User? _createdUser;
        private string _login { get => _createdUser is null ? "TestUser" : string.Concat("TestUser_", Guid.NewGuid().ToString()); }
        private string _password = "TestPassword";

        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public async Task AddTaskTest()
        {
            using (var dbConnector = new DBConnector())
            {
                var tlogin = _login;
                Assert.IsNotNull(tlogin);
                Assert.IsNotNull(_password);
                _createdUser = await dbConnector.UserControll.LogIn(new LogInUser { Login = tlogin, Password = _password });
                if (_createdUser is null)
                {
                    Assert.IsTrue(await dbConnector.UserControll.RegistrationUser(new RegistractionUser { Login = tlogin, Name = "TestUser", Password = _password }));
                    _createdUser = await dbConnector.UserControll.LogIn(new LogInUser { Login = tlogin, Password = _password });
                    Assert.IsNotNull(_createdUser);
                }
                var newTask = new AddedTask { Title = "Test task", Description = "Is Created task!", Creator = _createdUser.Id.ToString(), Status = TaskManagerBase.Enums.CRMTaskStatus.Created };
                Assert.IsTrue(await dbConnector.TaskControll.AddTask(newTask));
            }
        }

        [TestMethod]
        public async Task GetTasksTest()
        {
            using (var dbConnector = new DBConnector())
            {
                var tasks = await dbConnector.TaskControll.GetTasks(new TaskFilter());
                Assert.IsNotNull(tasks);
            }
        }

        [TestMethod]
        public async Task RemoveTaskTest()
        {
            var tlogin = _login;
            Assert.IsNotNull(tlogin);
            Assert.IsNotNull(_password);
            using (var dbConnector = new DBConnector())
            {
                _createdUser = await dbConnector.UserControll.LogIn(new LogInUser { Login = tlogin, Password = _password });
                Assert.IsNotNull(_createdUser);
                var tasks = await dbConnector.TaskControll.GetTasks(new TaskFilter { UserId = _createdUser.Id });
                Assert.IsNotNull(tasks);
                Assert.IsTrue(tasks.Count > 0);
                Assert.IsTrue(await dbConnector.TaskControll.RemoveTask(tasks.First().Id.ToString()));
            }
        }

        [TestMethod]
        public async Task ChangeTaskTest()
        {
            var tlogin = _login;
            Assert.IsNotNull(tlogin);
            Assert.IsNotNull(_password);
            using (var dbConnector = new DBConnector())
            {
                _createdUser = await dbConnector.UserControll.LogIn(new LogInUser { Login = tlogin, Password = _password });
                Assert.IsNotNull(_createdUser);
                var tasks = await dbConnector.TaskControll.GetTasks(new TaskFilter { UserId = _createdUser.Id });
                Assert.IsNotNull(tasks);
                if (tasks.Count > 0)
                {
                    Assert.IsNotNull(await dbConnector.TaskControll.ChangeTask(new ChangedTask { Id = tasks.First().Id.ToString(), Status = TaskManagerBase.Enums.CRMTaskStatus.Processed }));
                }
            }
        }
    }
}