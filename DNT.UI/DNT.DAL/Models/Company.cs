namespace DNT.DAL.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
        public string OIB { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
    }
}