using Posts.API.Models;
using System;
using System.Linq;

namespace Posts.API.Database
{
    public class DbInitializer
    {
        public static void Initialize(PostsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Posts.Any())
            {
                return;
            }

            context.AddRange(
                new Tag
                {
                    title = "IOS"
                },
                new Tag
                {
                    title = "AR"
                },
                new Tag
                {
                    title = "Gazzda"
                });
            context.SaveChanges();

            context.AddRange(
                new Post
                {
                    body = "The app is simple to use, and will help you decide on your best furniture fit.",
                    title = "Augmented Reality iOS Application",
                    slug = "augmented-reality-ios-application",
                    createdAt = DateTime.Now,
                    updatedAt = DateTime.Now.AddDays(1),
                    description = "Rubicon Software Development and Gazzda furniture are proud" +
                    " to launch an augmented reality app.",
                },
                new Post
                {
                    body = "The app is simple to use, and will help you decide on your best furniture fit.",
                    title = "Augmented Reality iOS Application 2",
                    slug = "augmented-reality-ios-application-2",
                    createdAt = DateTime.Now,
                    updatedAt = DateTime.Now.AddDays(1),
                    description = "Rubicon Software Development and Gazzda furniture are proud" +
                    "to launch an augmented reality app.",
                });
            context.SaveChanges();

            context.AddRange(
                new PostTag
                {
                    TagID = 1,
                    PostID = 1
                },
                new PostTag
                {
                    TagID = 1,
                    PostID = 2
                },
                new PostTag
                {
                    TagID = 2,
                    PostID = 2
                });

            context.SaveChanges();
        }
    }
}
