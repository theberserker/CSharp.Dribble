using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using static System.Console;

namespace CSharp.Dribble.Exam70483.Serialization
{
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    [Serializable]
    public class Order
    {
        [XmlAttribute]
        public int ID { get; set; }
        [XmlIgnore]
        public bool IsDirty { get; set; }
        [XmlArray("Lines")]
        [XmlArrayItem("OrderLine")]
        public List<OrderLine> OrderLines { get; set; }
    }
    [Serializable]
    public class VIPOrder : Order
    {
        public string Description { get; set; }
    }

    [Serializable]
    public class OrderLine
    {
        [XmlAttribute]
        public int ID { get; set; }
        [XmlAttribute]
        public int Amount { get; set; }
        [XmlElement("OrderedProduct")]
        public Product Product { get; set; }
    }
    [Serializable]
    public class Product
    {
        [XmlAttribute]
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    public class ObjectInheritanceToXmlAndBack
    {
        public static void Do()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Order), new Type[] { typeof(VIPOrder) });
            string xml;
            using (StringWriter stringWriter = new StringWriter())
            {
                Order order = CreateOrder();
                serializer.Serialize(stringWriter, order);
                xml = stringWriter.ToString();

                WriteLine(xml);
            }

            using (StringReader stringReader = new StringReader(xml))
            {
                Order o = (Order)serializer.Deserialize(stringReader);
                // Use the order
            }
        }

        private static Order CreateOrder()
        {
            Product p1 = new Product { ID = 1, Description = "p2", Price = 9 };
            Product p2 = new Product { ID = 2, Description = "p3", Price = 6 };
            Order order = new VIPOrder
            {
                ID = 4,
                Description = "OrderforJohn Doe.Usethenicegiftwrap",
                OrderLines = new List<OrderLine>
             {
                new OrderLine{ID=5,Amount=1,Product=p1},
                new OrderLine{ID=6,Amount=10,Product=p2},
             }
            };
            return order;
        }

    }
}
