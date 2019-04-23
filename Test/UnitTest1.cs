using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimesGroupon.Models;
using TimesGroupon.Services;
using MongoDB.Driver;
using System.Linq;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInsertData()
        {
            var service = new ActivityService("mongodb://localhost:27017");
            var previousCount = service.Activities.CountDocuments(x => true);
            var activity = new ActivityModel { ActivityName = "activity1", Price = 1.00 };
            var activityTwo = new ActivityModel { ActivityName = "activity2", Price = 2.00 };
            service.Activities.InsertMany(new[] { activity, activityTwo });
            Assert.AreEqual(previousCount + 2, service.Activities.CountDocuments(x => true));
        }

        [TestMethod]
        public void TestInserUser()
        {
            var service = new ActivityService("mongodb://localhost:27017");
            var previousCount = service.Users.CountDocuments(x => true);
            var user = new User { Name = "liucanming", Phone = "13500000000" };
            var user2 = new User { Name = "zhangwantao", Phone = "13300000000" };
            var activity1 = service.Activities.Find(x => true).First();
            var activity2 = service.Activities.Find(x => true).Skip(1).First();
            // user.AttentedActivities = new System.Collections.Generic.List<ActivityModel>();
            // user.AttentedActivities.Add(activity1);
            // user2.AttentedActivities = new System.Collections.Generic.List<ActivityModel>();
            // user2.AttentedActivities.Add(activity2);
            activity1.Host = user;
            activity2.Host = user;
            service.Users.InsertMany(new[] { user, user2 });
            // service.Activities.UpdateMany(x => new[] { activity1.Id, activity2.Id }.Contains(x.Id), new UpdateDefinition<ActivityModel>);
            service.Activities.ReplaceOne(x => x.Id == activity1.Id, activity1);
            service.Activities.ReplaceOne(x => x.Id == activity2.Id, activity2);
            Assert.AreEqual(previousCount + 2, service.Users.CountDocuments(x => true));
        }
    }
}
