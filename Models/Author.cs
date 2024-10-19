namespace Deac_Renata_Lab02.Models
{
    public class Author
    {
        public int ID { get; set; } // Cheie primară
  
        public string FirstName { get; set; } // Prenumele autorului
     
        public string LastName { get; set; } // Numele de familie al autorului

        public ICollection<Book>? Books { get; set; } // Proprietate de navigare
    }

}
