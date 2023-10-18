using Contracts.Models.SQL;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Models
{
    public class Messages
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }

    public interface IMessagesService
    {
        void Add(Messages message);
    }

    public class MessagesService : IMessagesService
    {
        private readonly DataBaseContext _context;
        public MessagesService(DataBaseContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public void Add(Messages data)
        {
            _context.Messages.Add(data);
            _context.SaveChanges();
        }
    }
}
