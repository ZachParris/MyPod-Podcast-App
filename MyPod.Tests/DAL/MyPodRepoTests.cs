using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Moq;
using MyPod.Models;
using MyPod.DAL;
using System.Collections.Generic;
using System.Linq;

namespace MyPod.Tests.DAL
{
    [TestClass]
    public class MyPodRepoTests
    {
        private Mock<DbSet<User>> mock_users { get; set; }
        private Mock<MyPodContext> mock_context { get; set; }
        private MyPodRepository Repo { get; set; }
        private List<User> users { get; set; }
        private List<Podcast> podcasts { get; set; }

        

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<MyPodContext>();
            mock_users = new Mock<DbSet<User>>();
            Repo = new MyPodRepository(mock_context.Object);
        }

        public void ConnectToDatastore()
        {
            var query_users = users.AsQueryable();

            mock_users.As<IQueryable<User>>().Setup(m => m.Provider).Returns(query_users.Provider);
            mock_users.As<IQueryable<User>>().Setup(m => m.Expression).Returns(query_users.Expression);
            mock_users.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(query_users.ElementType);
            mock_users.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => query_users.GetEnumerator());

            mock_context.Setup(c => c.User).Returns(mock_users.Object);
            mock_users.Setup(u => u.Add(It.IsAny<User>())).Callback((User t) => users.Add(t));
        }

        [TestMethod]
        public void RepoEnsureCanCreateAnInstance()
        {
            MyPodRepository repo = new MyPodRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureCanSubscribeToPodcasts()
        {
            ConnectToDatastore();
            Repo.AddPodcastToUser("trentS", "thejoeroganexperience");

            int expected_podcasts = 1;
            int actual_podcasts = Repo.GetPodcasts().Count();

            Assert.AreEqual(expected_podcasts, actual_podcasts);
        }

        [TestMethod]
        public void RepoEnsureCanRemovePodcastSubscription()
        {

        }
    }
}
