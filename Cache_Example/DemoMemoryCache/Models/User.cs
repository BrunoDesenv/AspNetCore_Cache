using System;
using System.Collections.Generic;

namespace DemoMemoryCache.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> CreateRandomList()
        {
            var users = new List<User>();
            Random random = new Random();
            int total = random.Next(1, 20);

            for (int i = 0; i < total; i++)
            {
                users.Add(new User
                {
                    Id = random.Next(1, 1000),
                    Name = Helper.RandomString(10)
                });
            }

            return users;
        }


    }
}
