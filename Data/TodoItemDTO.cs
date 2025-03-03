using Microsoft.EntityFrameworkCore;

namespace aspnet_webapi_efcore6.Data
{
    public class TodoItemDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public int UserId { get; set; }
    }
}