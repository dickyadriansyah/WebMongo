using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataEntities
{
    public class Student
    {

        [XmlIgnore]
        public ObjectId id { get; set; }
        //[BsonElement("StudentID")]
        public int StudentID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string status { get; set; }
    }
}
