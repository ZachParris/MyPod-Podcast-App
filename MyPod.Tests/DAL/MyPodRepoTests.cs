using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Moq;
using MyPod.Models;
using MyPod.DAL;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace MyPod.Tests.DAL
{
    [TestClass]
    public class MyPodRepoTests
    {
        private Mock<DbSet<Podcast>> mock_podcasts;
        private Mock<DbSet<Episode>> mock_episodes;
        private Mock<DbSet<Blog>> mock_posts;

        private Mock<DbSet<ApplicationUser>> mock_users { get; set; }
        private Mock<MyPodContext> mock_context { get; set; }
        private MyPodRepository Repo { get; set; }
        private List<ApplicationUser> users { get; set; }
        private List<Podcast> podcasts { get; set; }
        public List<Blog> posts { get; private set; }
        public List<Episode> episodes { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<MyPodContext>();
            mock_users = new Mock<DbSet<ApplicationUser>>();
            mock_podcasts = new Mock<DbSet<Podcast>>();
            mock_episodes = new Mock<DbSet<Episode>>();
            mock_posts = new Mock<DbSet<Blog>>();
            Repo = new MyPodRepository(mock_context.Object);

            posts = new List<Blog>();
            episodes = new List<Episode>();
            podcasts = new List<Podcast>();
            ApplicationUser paulyD = new ApplicationUser { Email = "paulyD@example.com", Id = "1234567" };
            ApplicationUser mikeD = new ApplicationUser { Email = "mikeyD@example.com", Id = "1234569" };
            users = new List<ApplicationUser>()
            {
                paulyD,
                mikeD
            };
        }

        public void ConnectToDatastore()
        {
            var query_users = users.AsQueryable();
            var query_podcasts = podcasts.AsQueryable();
            var query_episodes = episodes.AsQueryable();
            var query_blog = posts.AsQueryable();

            mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.Provider).Returns(query_users.Provider);
            mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.Expression).Returns(query_users.Expression);
            mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.ElementType).Returns(query_users.ElementType);
            mock_users.As<IQueryable<ApplicationUser>>().Setup(m => m.GetEnumerator()).Returns(() => query_users.GetEnumerator());

            mock_context.Setup(c => c.Users).Returns(mock_users.Object);
            mock_users.Setup(u => u.Add(It.IsAny<ApplicationUser>())).Callback((ApplicationUser t) => users.Add(t));

            mock_podcasts.As<IQueryable<Podcast>>().Setup(m => m.Provider).Returns(query_podcasts.Provider);
            mock_podcasts.As<IQueryable<Podcast>>().Setup(m => m.Expression).Returns(query_podcasts.Expression);
            mock_podcasts.As<IQueryable<Podcast>>().Setup(m => m.ElementType).Returns(query_podcasts.ElementType);
            mock_podcasts.As<IQueryable<Podcast>>().Setup(m => m.GetEnumerator()).Returns(() => query_podcasts.GetEnumerator());

            mock_context.Setup(c => c.Podcasts).Returns(mock_podcasts.Object);
            mock_podcasts.Setup(u => u.Add(It.IsAny<Podcast>())).Callback((Podcast t) => podcasts.Add(t));

            mock_episodes.As<IQueryable<Episode>>().Setup(m => m.Provider).Returns(query_episodes.Provider);
            mock_episodes.As<IQueryable<Episode>>().Setup(m => m.Expression).Returns(query_episodes.Expression);
            mock_episodes.As<IQueryable<Episode>>().Setup(m => m.ElementType).Returns(query_episodes.ElementType);
            mock_episodes.As<IQueryable<Episode>>().Setup(m => m.GetEnumerator()).Returns(() => query_episodes.GetEnumerator());

            mock_context.Setup(c => c.Episodes).Returns(mock_episodes.Object);
            mock_episodes.Setup(u => u.Add(It.IsAny<Episode>())).Callback((Episode t) => episodes.Add(t));

            mock_posts.As<IQueryable<Blog>>().Setup(m => m.Provider).Returns(query_blog.Provider);
            mock_posts.As<IQueryable<Blog>>().Setup(m => m.Expression).Returns(query_blog.Expression);
            mock_posts.As<IQueryable<Blog>>().Setup(m => m.ElementType).Returns(query_blog.ElementType);
            mock_posts.As<IQueryable<Blog>>().Setup(m => m.GetEnumerator()).Returns(() => query_blog.GetEnumerator());

            mock_context.Setup(c => c.Posts).Returns(mock_posts.Object);
            mock_posts.Setup(u => u.Add(It.IsAny<Blog>())).Callback((Blog t) => posts.Add(t));
        }

        [TestMethod]
        public void RepoEnsureCanCreateAnInstance()
        {
            MyPodRepository repo = new MyPodRepository();
            Assert.IsNotNull(repo);
        }


        [TestMethod]
        public void RepoEnsureCanSearchForPodcasts()
        {
            MyPodRepository repo = new MyPodRepository();


        }

        [TestMethod]
        public void RepoEnsureCanSubscribeToPodcastChannel()
        {
            ConnectToDatastore();
            Repo.AddPodcastChannelToUser("trentS", "thejoeroganexperience");

            int expected_podcasts = 1;
            //int actual_podcasts = Repo.GetPodcasts().Count;

            //Assert.AreEqual(expected_podcasts, actual_podcasts);
        }

        [TestMethod]
        public void RepoEnsureCanRemovePodcastSubscription()
        {

        }

        [TestMethod]
        public void RepoEnsureUserCanPlayEpisode()
        {

        }

        [TestMethod]
        public void RepoEnsureUserCanCreateBlogPost()
        {

        }

        [TestMethod]
        public void RepoEnsureCanEditBlogPost()
        {

        }

        [TestMethod]
        public void RepoEnsureUserCanRemoveBlogPost()
        {

        }

    }
}
