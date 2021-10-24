using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;
using XML.Models;

namespace XML.Controllers
{
    
    public class ValuesController : ApiController
    {

        List<Book> books = new List<Book>()
        {
            new Book(1,"Good Book", "A", "aa", new DateTime(), new DateTime()),
            new Book(2,"Good Bookdcv", "Addd", "daa", new DateTime(), new DateTime()),
            new Book(3,"Good Bssssook", "sssA", "asssa", new DateTime(), new DateTime()),
        };
       
        [HttpGet]
        [Route("books")]
        public XmlElement Get()
        {
            return SerializeToXmlElement(this.books);
        }


        [HttpGet]
        [Route("books/{id}")]
        // GET api/values/5
        public XmlElement Get(int id)
        {
            try
            {
                var book = this.books.First(b => b.id == id);
                return SerializeToXmlElement(book);
            }catch(Exception ex)
            {
                return SerializeToXmlElement(new Book());
            }
            
          
        }

        public static XmlElement SerializeToXmlElement(object o)
        {
            XmlDocument doc = new XmlDocument();

            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                new XmlSerializer(o.GetType()).Serialize(writer, o);
            }

            return doc.DocumentElement;
        }
    }
}
