using System.ComponentModel.DataAnnotations;

namespace Deac_Renata_Lab02.Models
{
    public class Author
    {
        public int ID { get; set; } // Cheie primară
  
        public string FirstName { get; set; } // Prenumele autorului
     
        public string LastName { get; set; } // Numele de familie al autorului

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }


        public ICollection<Book>? Books { get; set; } // Proprietate de navigare
    }

}
