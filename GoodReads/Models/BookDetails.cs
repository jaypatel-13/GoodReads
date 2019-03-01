using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoodReads.Models
{
    public class BookDetails
    {
        public int BookId { get; set;}
        [Key]
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Imagepath { get; set; }
        public string Filepath { get; set; }
       
    }
}