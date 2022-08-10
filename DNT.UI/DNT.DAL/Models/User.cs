using System.Collections.Generic;

namespace DNT.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string OIB { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public IList<Card> Cards { get; set; }
        public Company Company { get; set; }
    }
}
