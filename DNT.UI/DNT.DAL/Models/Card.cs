using System;

namespace DNT.DAL.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Contract { get; set; }
        public string Date { get; set; }
        public Company Company{ get; set; }
        public User User { get; set; }
        public bool Active { get; set; }
    }
}
