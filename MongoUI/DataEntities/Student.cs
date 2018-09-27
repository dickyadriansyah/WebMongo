using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataEntities
{
    public class Student
    {
        public string id { get; set; }
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
