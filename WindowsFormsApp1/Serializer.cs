using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WindowsFormsApp1
{
    public class Serializer
    {
        // singleton
        private Serializer() { }
        private static Serializer obj = null;

        public static Serializer get()
        {
            if (obj == null)
            {
                obj = new Serializer();
            }
            return obj;
        }
        // singleton

        private Type[] types = new Type[]             // types for serialization
{
            typeof(Pens),
            typeof(Line),
            typeof(Ellipse),
            typeof(Square),
            typeof(Triangle),
            typeof(Figures)
};

        // mathod for serialization
        public void to_Serialize(string file_name, List<Figures> flenta)
        {
            DataContractJsonSerializer format = new DataContractJsonSerializer(typeof(List<Figures>), types);
            using (FileStream fs = new FileStream(file_name, FileMode.Create))
            {
                format.WriteObject(fs, flenta);
            }
        }

        // method for deserialization
        public List<Figures> Deserialize(string file_name)
        {
            DataContractJsonSerializer format = new DataContractJsonSerializer(typeof(List<Figures>), types);
            using (FileStream fs = new FileStream(file_name, FileMode.Open))
            {
                return (List<Figures>)format.ReadObject(fs);
            }
        }

    }
}
