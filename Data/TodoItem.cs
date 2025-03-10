using Microsoft.EntityFrameworkCore;

namespace aspnet_webapi_efcore6.Data
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public long UserId { get; set; }

        //Mark navigational props virtual in case of Lazy loading
        //public virtual User? User { get; set; }
        public virtual User? User { get; set; }
    }
}