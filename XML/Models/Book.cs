using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XML.Models
{
    [Serializable]
    public class Book
    {
        public int id { get;set;}
        public string author { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime? created { get; set; }
        public DateTime? edited { get; set; }

        public Book()
        {

        }
        public Book(int id, string author, string title, string content, DateTime? created, DateTime? edited)
        {
            this.id = id;
            this.author = author;
            this.title = title; 
            this.content = content;
            this.created = created;
            this.edited = edited;
        }
    }
}