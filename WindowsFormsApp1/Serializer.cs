using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace WindowsFormsApp1
{
    class Serializer
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

        // mathod for serialization
        public void to_Serialize(string file_name, List<Figures> flenta, Type[] types)
        {
            DataContractJsonSerializer format = new DataContractJsonSerializer(typeof(List<Figures>), types);
            using (FileStream fs = new FileStream(file_name, FileMode.Create))
            {
                format.WriteObject(fs, flenta);
            }
        }

        // method for deserialization
        public List<Figures> Deserialize(string file_name, Type[] types)
        {
            DataContractJsonSerializer format = new DataContractJsonSerializer(typeof(List<Figures>), types);
            using (FileStream fs = new FileStream(file_name, FileMode.Open))
            {
                return (List<Figures>)format.ReadObject(fs);
            }
        }

    }
}
