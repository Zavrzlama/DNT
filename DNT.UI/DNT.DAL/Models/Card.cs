namespace DNT.DAL.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string UID { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }
    }
}
