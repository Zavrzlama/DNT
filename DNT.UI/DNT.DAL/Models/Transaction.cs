using System;

namespace DNT.DAL.Models
{
    public class Transaction
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Card { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int NumberOfBags { get; set; }
        public bool Vault { get; set; }
    }
}
