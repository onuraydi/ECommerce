using ECommerce.Message.Dal.Entites;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Message.Dal.Context
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options) { }
        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
