using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SpaChatApp.Data
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string User { get; set; }
        public string TextMessage { get; set; }
    }
}
