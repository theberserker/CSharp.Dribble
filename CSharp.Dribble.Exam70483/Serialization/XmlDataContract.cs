using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Dribble.Exam70483.Serialization
{
    [DataContract]
    public class PersonDataContract
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        private bool isDirty = false;
    }

    public class XmlDataContract
    {
        public static void Do()
        {
            PersonDataContract p = new PersonDataContract
            {
                Id = 1,
                Name = "JohnDoe"
            };
            using (Stream stream = new FileStream("data.xml", FileMode.Create))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(PersonDataContract));
                ser.WriteObject(stream, p);
            }
            using (Stream stream = new FileStream("data.xml", FileMode.Open))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(PersonDataContract));
                PersonDataContract result = (PersonDataContract)ser.ReadObject(stream);
            }
        }

        public static void DoJson()
        {
            PersonDataContract p = new PersonDataContract
            {
                Id = 1,
                Name = "JohnDoe"
            };

            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PersonDataContract));
                ser.WriteObject(stream, p);

                stream.Position = 0;
                StreamReader streamReader = new StreamReader(stream);
                Console.WriteLine(streamReader.ReadToEnd()); // Displays {“Id”:1,”Name”:”John Doe”}
                stream.Position = 0;
                PersonDataContract result = (PersonDataContract)ser.ReadObject(stream);
            }
        }
    }
}
