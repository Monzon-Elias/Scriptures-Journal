using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ScripturesJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ScripturesJournalContext(serviceProvider.GetRequiredService<DbContextOptions<ScripturesJournalContext>>()))
            {
                // Look for any scriptures
                if (context.Scripture.Any())
                {
                    return; // DB has been seeded
                }
                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Alma",
                        RegistrationDate = DateTime.Parse("2018-1-11"),
                        Chapter = 42,
                        Verse = 12,
                        Notes = "Powerful   verse!"
                    },
                    new Scripture
                    {
                        Book = "Helaman",
                        RegistrationDate = DateTime.Parse("2018-2-11"),
                        Chapter = 5,
                        Verse = 12,
                        Notes = "Super Missionarie!"
                    }
            );
                context.SaveChanges();
            }
        }
    }
}
