namespace SharpForum.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SharpForum.Models.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SharpForum.Data.SharpForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SharpForum.Data.SharpForumContext";
        }

        protected override void Seed(SharpForum.Data.SharpForumContext context)
        {
            // Add Roles
            if (!context.Roles.Any())
            {
                var store = new RoleStore<IdentityRole>(context);
                var manage = new RoleManager<IdentityRole>(store);

                var adminRole = new IdentityRole("Admin");
                var moderatorRole = new IdentityRole("Moderator");
                var userRole = new IdentityRole("User");

                context.Roles.Add(adminRole);
                context.Roles.Add(moderatorRole);
                context.Roles.Add(userRole);
            }

            // Add Categories
            if (!context.Categories.Any())
            {
                Category homeCategory = new Category()
                {
                    Name = "Home",
                    Description = "Default home category",
                    Priority = 1,
                    IsSuperCategory = true
                };

                Category newsCategory = new Category()
                {
                    Name = "News",
                    Description = "News about the forum",
                    Priority = 2,
                    IsSuperCategory = false
                };

                Category introductionCategory = new Category()
                {
                    Name = "Introduction",
                    Description = "Tell us more about yourself",
                    Priority = 3,
                    IsSuperCategory = false
                };

                Category entertainmentCategory = new Category()
                {
                    Name = "Entertainment",
                    Description = "Default entertainment category",
                    Priority = 4,
                    IsSuperCategory = true
                };

                Category moviesCategory = new Category()
                {
                    Name = "Movies",
                    Description = "Discuss movies here",
                    Priority = 5,
                    IsSuperCategory = false
                };

                Category musicCategory = new Category()
                {
                    Name = "Music",
                    Description = "Discuss music here",
                    Priority = 6,
                    IsSuperCategory = false
                };

                context.Categories.Add(homeCategory);
                context.Categories.Add(newsCategory);
                context.Categories.Add(introductionCategory);
                context.Categories.Add(entertainmentCategory);
                context.Categories.Add(moviesCategory);
                context.Categories.Add(musicCategory);

                context.SaveChanges();
            }

            #region Add Users For Testing
            // Add Users
            if (!context.Users.Any())
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);

                User johnRuth = new User()
                {
                    Email = "thehangman@mustache.com",
                    UserName = "JohnRuth",
                    AboutMe = "I am a bounty hunter. You could know me better as The Hangman.",
                    WebsiteUrl = "http://www.imdb.com/character/ch0479805/",
                    AvatarUrl = "http://content.internetvideoarchive.com/content/photos/9930/468395_025.jpg",
                    DateOfRegistration = DateTime.Now,
                    ForumSignature = "You only need to hang mean bastards, but mean bastards you need to hang!",
                    RoleTitle = "Admin"
                };

                manager.Create(johnRuth, "JohnRuth");
                manager.AddToRole(johnRuth.Id, "Admin");

                User marquisWarren = new User()
                {
                    Email = "theblackdeath@bounty.com",
                    UserName = "MajorWarren",
                    AboutMe = "I am former US calvary major. Busted out of Wellenbeck war prison. Currently bounty hunter.",
                    WebsiteUrl = "http://thehatefuleight.wikia.com/wiki/Marquis_Warren",
                    AvatarUrl = "http://wiki.tarantino.info/images/thumb/Marquis1.jpg/250px-Marquis1.jpg",
                    DateOfRegistration = DateTime.Now,
                    ForumSignature = "Move a little strange, youre gonna get a bullet.",
                    RoleTitle = "Moderator"
                };

                manager.Create(marquisWarren, "MajorWarren");
                manager.AddToRole(marquisWarren.Id, "Moderator");

                User chrisMannix = new User()
                {
                    Email = "sheriff@redrock.com",
                    UserName = "ChrisMannix",
                    AboutMe = "I am the new sheriff of Redrock.",
                    WebsiteUrl = "http://thehatefuleight.wikia.com/wiki/Chris_Mannix",
                    AvatarUrl = "https://pbs.twimg.com/media/CZOLo9-WkAEhfaT.png",
                    DateOfRegistration = DateTime.Now,
                    ForumSignature = "Well, cut my legs off and call me Shorty!",
                    RoleTitle = "User"
                };

                manager.Create(chrisMannix, "ChrisMannix");
                manager.AddToRole(chrisMannix.Id, "User");

                User daisyDomergue = new User()
                {
                    Email = "daisy@jodiesgang.com",
                    UserName = "DaisyDomergue",
                    AboutMe = "I am part of Jody Domingray gang.",
                    WebsiteUrl = "http://wiki.tarantino.info/",
                    AvatarUrl = "http://wiki.tarantino.info/images/thumb/Daisy1.jpg/250px-Daisy1.jpg",
                    DateOfRegistration = DateTime.Now,
                    ForumSignature = "When you get to hell, John, tell them Daisy sent you...",
                    RoleTitle = "User"
                };

                manager.Create(daisyDomergue, "DaisyDomergue");
                manager.AddToRole(daisyDomergue.Id, "User");

                User bob = new User()
                {
                    Email = "bob@minnie.com",
                    UserName = "Bob",
                    AboutMe = " I just put those other horses away! You want it done fast, you need to help.",
                    WebsiteUrl = "http://wiki.tarantino.info/",
                    AvatarUrl = "https://s-media-cache-ak0.pinimg.com/564x/d2/05/b6/d205b6bfb30a650459d1ff5a502231cd.jpg",
                    DateOfRegistration = DateTime.Now,
                    RoleTitle = "User"
                };

                manager.Create(bob, "Bobbob");
                manager.AddToRole(bob.Id, "User");

                User oswaldoMobray = new User()
                {
                    Email = "hangman@redrock.com",
                    UserName = "OswaldoMobray",
                    AboutMe = "The man who pulls the lever that breaks your neck will be a dispassionate man. And that dispassion is the very essence of justice. For justice delivered without dispassion is always in danger of not being justice.",
                    AvatarUrl = "http://wiki.tarantino.info/images/thumb/Oswald1.jpg/250px-Oswald1.jpg",
                    DateOfRegistration = DateTime.Now,
                    RoleTitle = "User"
                };

                manager.Create(oswaldoMobray, "OswaldoMobray");
                manager.AddToRole(oswaldoMobray.Id, "User");

                User joeGage = new User()
                {
                    Email = "joe@cowboy.com",
                    UserName = "JoeGage",
                    AboutMe = "I made pretty penny by being a cowboy.",
                    AvatarUrl = "https://static.independent.co.uk/s3fs-public/styles/story_medium/public/thumbnails/image/2015/12/30/13/5909457.jpg",
                    DateOfRegistration = DateTime.Now,
                    RoleTitle = "User"
                };

                manager.Create(joeGage, "JoeGage");
                manager.AddToRole(joeGage.Id, "User");

                User sanfordSmithers = new User()
                {
                    Email = "thegeneral@confederation.com",
                    UserName = "GenSmithers",
                    AboutMe = "I am former confederate general.",
                    WebsiteUrl = "http://wiki.tarantino.info/",
                    AvatarUrl = "http://4.bp.blogspot.com/-nslV4ZlQnZ4/Vp_i5NFYu0I/AAAAAAAAAWE/9C0jM158sI8/s1600/Hateful%2B8-4.jpg",
                    DateOfRegistration = DateTime.Now,
                    ForumSignature = "According to the Yankees, its a free country.",
                    RoleTitle = "User"
                };

                manager.Create(sanfordSmithers, "GenSmithers");
                manager.AddToRole(sanfordSmithers.Id, "User");

                User oBJackson = new User()
                {
                    Email = "obj@stagecoach.com",
                    UserName = "OBJackson",
                    AboutMe = "I am stagecoach driver.",
                    WebsiteUrl = "http://wiki.tarantino.info/",
                    AvatarUrl = "https://s-media-cache-ak0.pinimg.com/564x/a8/f5/67/a8f567b5fcd79c472b6ccdb2c006750e.jpg",
                    DateOfRegistration = DateTime.Now,
                    ForumSignature = "Give me 50 dollars and Ill help you put dead bodies on the roof.",
                    RoleTitle = "User"
                };

                manager.Create(oBJackson, "OBJackson");
                manager.AddToRole(oBJackson.Id, "User");

                User minnieMink = new User()
                {
                    Email = "minnie@thehaberdashery.com",
                    UserName = "MinnieMink",
                    AboutMe = "I am the owner of the Haberdashery.",
                    WebsiteUrl = "http://wiki.tarantino.info/",
                    AvatarUrl = "http://www.postavy.cz/foto/minnie-mink-foto.jpg",
                    DateOfRegistration = DateTime.Now,
                    ForumSignature = "Come to the Haberdashery for a hot coffie.",
                    RoleTitle = "User"
                };

                manager.Create(minnieMink, "MinnieMink");
                manager.AddToRole(minnieMink.Id, "User");

                User jodyDomingray = new User()
                {
                    Email = "jody@gang.com",
                    UserName = "JodyDomingray",
                    AboutMe = "I am the gang leader of the Domingray gang.",
                    AvatarUrl = "http://store.picbg.net/pubpic/57/CA/2f2db3abea1f57ca.png",
                    DateOfRegistration = DateTime.Now,
                    RoleTitle = "User"
                };

                manager.Create(jodyDomingray, "JodyDomingray");
                manager.AddToRole(jodyDomingray.Id, "User");

                User sixHorseJudy = new User()
                {
                    Email = "judy@stagecoachworld.com",
                    UserName = "SixHorseJudy",
                    AvatarUrl = "http://store.picbg.net/pubpic/06/11/ca8c28726bf90611.jpg",
                    DateOfRegistration = DateTime.Now,
                    RoleTitle = "User"
                };

                manager.Create(sixHorseJudy, "SixHorseJudy");
                manager.AddToRole(sixHorseJudy.Id, "User");

                User sweetDave = new User()
                {
                    Email = "dave@thehaberdashery.com",
                    UserName = "SweetDave",
                    AvatarUrl = "http://store.picbg.net/pubpic/15/9E/bc1abdd33420159e.jpg",
                    DateOfRegistration = DateTime.Now,
                    RoleTitle = "User"
                };

                manager.Create(sweetDave, "SweetDave");
                manager.AddToRole(sweetDave.Id, "User");

                User daniel = new User()
                {
                    Email = "contact@danielignatov.tk",
                    UserName = "Daniel",
                    DateOfRegistration = DateTime.Now,
                    RoleTitle = "Admin"
                };

                manager.Create(daniel, "Daniel");
                manager.AddToRole(daniel.Id, "Admin");

                User taylorSwift = new User()
                {
                    Email = "taylor@swift.com",
                    UserName = "TaylorSwift",
                    AvatarUrl = "http://kstz-fm.sagacom.com/wp-content/blogs.dir/23/files/2013/01/tswift-620x400.jpg",
                    DateOfRegistration = DateTime.Now,
                    RoleTitle = "User"
                };

                manager.Create(taylorSwift, "TaylorSwift");
                manager.AddToRole(taylorSwift.Id, "User");

                User parisHilton = new User()
                {
                    Email = "paris@hilton.com",
                    UserName = "ParisHilton",
                    AvatarUrl = "https://s-media-cache-ak0.pinimg.com/originals/75/54/2e/75542e3b1cebbccd6042740050b950c0.jpg",
                    DateOfRegistration = DateTime.Now,
                    RoleTitle = "User"
                };

                manager.Create(parisHilton, "ParisHilton");
                manager.AddToRole(parisHilton.Id, "User");

                User amberHeard = new User()
                {
                    Email = "amber@heard.com",
                    UserName = "AmberHeard",
                    AvatarUrl = "http://www.kliuki.bg/wp-content/uploads//2016/08/660_fc87ef40ff1eee39db51e3e597bd770f.jpg",
                    DateOfRegistration = DateTime.Now,
                    RoleTitle = "User"
                };

                manager.Create(amberHeard, "AmberHeard");
                manager.AddToRole(amberHeard.Id, "User");
            }

            context.SaveChanges();
            #endregion 
        }
    }
}
