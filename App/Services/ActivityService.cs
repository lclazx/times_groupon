using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using TimesGroupon.Models;

namespace TimesGroupon.Services
{
    public class ActivityService
    {
        public IMongoCollection<ActivityModel> Activities { get; }
        public IMongoCollection<User> Users { get; }
        public ActivityService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ActivityDb"));
            var database = client.GetDatabase("timesgroupon");
            Activities = database.GetCollection<ActivityModel>("ActivityModel");
            Users = database.GetCollection<User>("UserModel");
        }

        public ActivityService(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("timesgroupon");
            Activities = database.GetCollection<ActivityModel>("ActivityModel");
            Users = database.GetCollection<User>("UserModel");
        }
    }
}