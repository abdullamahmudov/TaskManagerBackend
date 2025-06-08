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
    public class TaskCommentControllTesting
    {
        private User? _createdUser;
        private string _login { get => _createdUser is null ? "TestUser" : string.Concat("TestUser_", Guid.NewGuid().ToString()); }
        private string _password = "TestPassword";

        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public async Task AddCommentTest()
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
                var tasks = await dbConnector.TaskControll.GetTasks(new TaskFilter());
                Assert.IsNotNull(tasks);
                if (tasks.Count == 0)
                {
                    var newTask = new AddedTask { Title = "Test task", Description = "Is Created task!", Creator = _createdUser.Id.ToString(), Status = TaskManagerBase.Enums.CRMTaskStatus.Created };
                    Assert.IsTrue(await dbConnector.TaskControll.AddTask(newTask));
                    tasks = await dbConnector.TaskControll.GetTasks(new TaskFilter());
                    Assert.IsNotNull(tasks);
                }
                Assert.IsTrue(tasks.Count > 0);
                var taskId = tasks.First().Id.ToString();
                Assert.IsTrue(await dbConnector.TaskCommentControll.AddComment(new AddedTaskComment { CreatorId = _createdUser.Id.ToString(), TaskId = taskId, Text = "Test Comment!" }));
                var comments = await dbConnector.TaskCommentControll.GetComments(taskId);
                Assert.IsNotNull(comments);
                Assert.IsTrue(comments.Count > 0);
            }
        }

        [TestMethod]
        public async Task RemoveCommentTest()
        {
            using (var dbConnector = new DBConnector())
            {
                var tlogin = _login;
                Assert.IsNotNull(tlogin);
                Assert.IsNotNull(_password);
                _createdUser = await dbConnector.UserControll.LogIn(new LogInUser { Login = tlogin, Password = _password });
                Assert.IsNotNull(_createdUser);
                var tasks = await dbConnector.TaskControll.GetTasks(new TaskFilter());
                Assert.IsNotNull(tasks);
                Assert.IsTrue(tasks.Count > 0);
                var taskId = tasks.First().Id.ToString();
                var comments = await dbConnector.TaskCommentControll.GetComments(taskId);
                Assert.IsNotNull(comments);
                Assert.IsTrue(comments.Count > 0);
                Assert.IsTrue(await dbConnector.TaskCommentControll.RemoveComment(comments.First().Id.ToString()));
            }
        }
    }
}