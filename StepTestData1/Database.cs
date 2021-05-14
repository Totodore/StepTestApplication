﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace StepTestData1
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=Database")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        public DbSet<Test> Tests { get; set; }

        /// <summary>
        /// Search a test, if the needle is not specified it returns all tests
        /// </summary>
        /// <param name="needle"></param>
        /// <returns>A list of <see cref="Test"/></returns>
        public static async Task<List<Test>> Search(string needle)
        {
            using (var context = new DatabaseContext())
            {
                return await context.Tests.Where(test => test.UserName.Contains(needle)).ToListAsync();
            }
        }

        /// <returns>Get all the <see cref="Test"/></returns>
        public static async Task<List<Test>> GetAll()
        {
            using (var context = new DatabaseContext())
            {
                return await context.Tests.ToListAsync();
            }
        }

        /// <summary>
        /// Delete a <see cref="Test"/> from the database
        /// </summary>
        /// <param name="id">The Id of the test to delete</param>
        public static void Delete(Test test)
        {
            using (var context = new DatabaseContext())
            {
                context.Tests.SingleDelete(test);
            }
        }

        /// <summary>
        /// Add a test from the database
        /// </summary>
        /// <param name="test">The <see cref="Test"/> to add</param>
        public static async Task Add(Test test)
        {
            using (var context = new DatabaseContext())
            { 
                context.Tests.Add(test);
                await context.SaveChangesAsync();
            }
        }
    }

    /// <summary>
    /// Entity that represent a Test in the database
    /// </summary>
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public Sex Sex { get; set; }
    }

    public enum Sex
    {
        Male,
        Female
    }
}