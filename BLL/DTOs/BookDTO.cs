using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookDTO
    {
      
        public int Id { get; set; }    
        public string Title { get; set; }       
        public string Author { get; set; }     
        public string Genre { get; set; }    
        public decimal Price { get; set; }    
        public int Stock { get; set; }
        public DateTime Published { get; set; }
    }
}
