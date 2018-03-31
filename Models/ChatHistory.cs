using System.ComponentModel.DataAnnotations;

namespace SignalR_Chat_Demo.Models
{
    public class ChatHistory : BaseEntity
    {
        [MaxLength(200)]
        public string UserName { get; set; }
        [MaxLength(2000)]
        public string Message { get; set; }

    }
}
