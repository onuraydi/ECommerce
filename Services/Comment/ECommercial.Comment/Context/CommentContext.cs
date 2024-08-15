
using ECommercial.Comment.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ECommercial.Comment.Context
{
    public class CommentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost, 1442;Initial Catalog=ECommercialCommentDb;User=sa; Password=81A84y04o09e19*");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
