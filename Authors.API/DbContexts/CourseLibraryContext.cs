using Authors.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Authors.API.DbContexts;

public class CourseLibraryContext : DbContext
{
    public CourseLibraryContext(DbContextOptions<CourseLibraryContext> options)
       : base(options)
    {
    }

    // base DbContext constructor ensures that Books and Authors are not null after
    // having been constructed.  Compiler warning ("uninitialized non-nullable property")
    // can safely be ignored with the "null-forgiving operator" (= null!)

    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed the database with dummy data
        modelBuilder.Entity<Author>().HasData(
            new Author("Berry", "Griffin Beak Eldritch", "Ships")
            {
                Id = 101,
                DateOfBirth = new DateTime(1980, 7, 23)
            },
            new Author("Nancy", "Swashbuckler Rye", "Rum")
            {
                Id = 102,
                DateOfBirth = new DateTime(1978, 5, 21)
            },
            new Author("Eli", "Ivory Bones Sweet", "Singing")
            {
                Id = 103,
                DateOfBirth = new DateTime(1957, 12, 16)
            },
            new Author("Arnold", "The Unseen Stafford", "Singing")
            {
                Id = 104,
                DateOfBirth = new DateTime(1957, 3, 6)
            },
            new Author("Seabury", "Toxic Reyson", "Maps")
            {
                Id = 105,
                DateOfBirth = new DateTime(1956, 11, 23)
            },
            new Author("Rutherford", "Fearless Cloven", "General debauchery")
            {
                Id = 106,
                DateOfBirth = new DateTime(1981, 4, 5)
            },
            new Author("Atherton", "Crow Ridley", "Rum")
            {
                Id = 107,
                DateOfBirth = new DateTime(1982, 10, 11)
            },

             new Author("mike", "tyson", "Rum")
             {
                 Id = 108,
                 DateOfBirth = new DateTime(1982, 10, 11)
             },

              new Author("arthava", "shinde", "Rum")
              {
                  Id = 109,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("shyubham", "jyoti", "Rum")
              {
                  Id = 110,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },

              new Author("baba", "k", "Rum")
              {
                  Id = 111,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("rohan", "jamanat", "Rum")
              {
                  Id = 112,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("guddu", "pandit", "Rum")
              {
                  Id = 113,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("kamalesh", "timwari", "Rum")
              {
                  Id = 114,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("jahangir", "aman", "Rum")
              {
                  Id = 115,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("tirtha", "kamat", "Rum")
              {
                  Id = 116,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("jan", "jani", "Rum")
              {
                  Id = 117,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("akshay", "bhau", "Rum")
              {
                  Id = 118,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("udasas", "rahil", "Rum")
              {
                  Id = 119,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("sahil", "nasy", "Rum")
              {
                  Id = 120,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("pyarag", "aadsd", "Rum")
              {
                  Id = 121,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              //
              new Author("shyubham", "jyoti", "Rum")
              {
                  Id = 8035,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },

              new Author("baba", "k", "Rum")
              {
                  Id = 8034,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("rohan", "jamanat", "Rum")
              {
                  Id = 8033,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("guddu", "pandit", "Rum")
              {
                  Id = 8032,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("kamalesh", "timwari", "Rum")
              {
                  Id = 8031,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("jahangir", "aman", "Rum")
              {
                  Id = 8030,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("tirtha", "kamat", "Rum")
              {
                  Id = 8029,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("jan", "jani", "Rum")
              {
                  Id = 8028,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("akshay", "bhau", "Rum")
              {
                  Id = 8027,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("udasas", "rahil", "Rum")
              {
                  Id = 8026,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("sahil", "nasy", "Rum")
              {
                  Id = 8025,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("pyarag", "aadsd", "Rum")
              {
                  Id = 8024,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
               new Author("shyubham", "jyoti", "Rum")
               {
                   Id = 8023,
                   DateOfBirth = new DateTime(1982, 10, 11)
               },

              new Author("baba", "k", "Rum")
              {
                  Id = 8022,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("rohan", "jamanat", "Rum")
              {
                  Id = 8021,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("guddu", "pandit", "Rum")
              {
                  Id = 8020,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("kamalesh", "timwari", "Rum")
              {
                  Id = 8019,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("jahangir", "aman", "Rum")
              {
                  Id = 8018,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("tirtha", "kamat", "Rum")
              {
                  Id = 8017,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("jan", "jani", "Rum")
              {
                  Id = 8016,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("akshay", "bhau", "Rum")
              {
                  Id = 9001,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("udasas", "rahil", "Rum")
              {
                  Id = 8015,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("sahil", "nasy", "Rum")
              {
                  Id = 8014,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("pyarag", "aadsd", "Rum")
              {
                  Id = 8013,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
               new Author("shyubham", "jyoti", "Rum")
               {
                   Id = 8012,
                   DateOfBirth = new DateTime(1982, 10, 11)
               },

              new Author("baba", "k", "Rum")
              {
                  Id = 8011,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("rohan", "jamanat", "Rum")
              {
                  Id = 8010,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("guddu", "pandit", "Rum")
              {
                  Id = 8009,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("kamalesh", "timwari", "Rum")
              {
                  Id = 8007,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("jahangir", "aman", "Rum")
              {
                  Id = 8006,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("tirtha", "kamat", "Rum")
              {
                  Id = 8117,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("jan", "jani", "Rum")
              {
                  Id = 8005,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("akshay", "bhau", "Rum")
              {
                  Id = 8004,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("udasas", "rahil", "Rum")
              {
                  Id = 8003,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("sahil", "nasy", "Rum")
              {
                  Id = 8002,
                  DateOfBirth = new DateTime(1982, 10, 11)
              },
              new Author("pyarag", "aadsd", "Rum")
              {
                  Id = 8001,
                  DateOfBirth = new DateTime(1982, 10, 11)
              }
            );

        modelBuilder.Entity<Course>().HasData(
           new Course("Commandeering a Ship Without Getting Caught")
           {
               Id = 501,
               AuthorId = 101,
               Description = "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers."
           },
           new Course("Overthrowing Mutiny")
           {
               Id = 502,
               AuthorId = 102,
               Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny."
           },
           new Course("Avoiding Brawls While Drinking as Much Rum as You Desire")
           {
               Id = 503,
               AuthorId = 103,
               Description = "Every good pirate loves rum, but it also has a tendency to get you into trouble.  In this course you'll learn how to avoid that.  This new exclusive edition includes an additional chapter on how to run fast without falling while drunk."
           },
           new Course("Singalong Pirate Hits")
           {
               Id = 504,
               AuthorId = 104,
               Description = "In this course you'll learn how to sing all-time favourite pirate songs without sounding like you actually know the words or how to hold a note."
           }
           );

        // fix to allow sorting on DateTimeOffset when using Sqlite, based on
        // https://blog.dangl.me/archive/handling-datetimeoffset-in-sqlite-with-entity-framework-core/
        if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
        {
            // Sqlite does not have proper support for DateTimeOffset via Entity Framework Core, see the limitations
            // here: https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
            // To work around this, when the Sqlite database provider is used, all model properties of type DateTimeOffset
            // use the DateTimeOffsetToBinaryConverter
            // Based on: https://github.com/aspnet/EntityFrameworkCore/issues/10784#issuecomment-415769754 
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTimeOffset)
                        || p.PropertyType == typeof(DateTimeOffset?));
                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name)
                        .Property(property.Name)
                        .HasConversion(new DateTimeOffsetToBinaryConverter());
                }
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}


