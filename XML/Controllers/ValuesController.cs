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
            new Book(1,"Book 1", "Author 1", "Each morning when you wake up, play a few pump up songs before you start your day to get you going. You can listen to productivity music on Spotify to help you get going. By getting your mind in the right mindset, you can inch closer to motivating yourself. ", new DateTime(), new DateTime()),
            new Book(2,"Book 2", "Author 2", "Each morning when you wake up, play a few pump up songs before you start your day to get you going. You can listen to productivity music on Spotify to help you get going. By getting your mind in the right mindset, you can inch closer to motivating yourself. " ,new DateTime(), new DateTime()),
            new Book(3,"Book 3", "Author 3", "Each morning when you wake up, play a few pump up songs before you start your day to get you going. You can listen to productivity music on Spotify to help you get going. By getting your mind in the right mindset, you can inch closer to motivating yourself. ", new DateTime(), new DateTime()),
             new Book(4,"Book 4", "Author 4", "Each morning when you wake up, play a few pump up songs before you start your day to get you going. You can listen to productivity music on Spotify to help you get going. By getting your mind in the right mindset, you can inch closer to motivating yourself. ", new DateTime(), new DateTime()),
            new Book(5,"Book 5", "Author 5", "Each morning when you wake up, play a few pump up songs before you start your day to get you going. You can listen to productivity music on Spotify to help you get going. By getting your mind in the right mindset, you can inch closer to motivating yourself. " ,new DateTime(), new DateTime()),
            new Book(6,"Book 6", "Author 6", "Each morning when you wake up, play a few pump up songs before you start your day to get you going. You can listen to productivity music on Spotify to help you get going. By getting your mind in the right mindset, you can inch closer to motivating yourself. ", new DateTime(), new DateTime()),
             new Book(7,"Book 7", "Author 7", "Each morning when you wake up, play a few pump up songs before you start your day to get you going. You can listen to productivity music on Spotify to help you get going. By getting your mind in the right mindset, you can inch closer to motivating yourself. ", new DateTime(), new DateTime()),
            new Book(8,"Book 8", "Author 8", "Each morning when you wake up, play a few pump up songs before you start your day to get you going. You can listen to productivity music on Spotify to help you get going. By getting your mind in the right mindset, you can inch closer to motivating yourself. " ,new DateTime(), new DateTime()),

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
