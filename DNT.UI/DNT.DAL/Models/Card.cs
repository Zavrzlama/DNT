using System;

namespace DNT.DAL.Models
{
    public class Card
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string UID { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }
    }
}
