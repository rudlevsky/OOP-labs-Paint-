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

        public void to_Serialize(string file_name, List<BitSaver> lenta)
        {
            DataContractJsonSerializer format = new DataContractJsonSerializer(typeof(List<BitSaver>));
            FileStream fs = new FileStream(file_name, FileMode.Create);
            format.WriteObject(fs, lenta);
            fs.Close();
        }

        public List<BitSaver> Deserialize(string file_name)
        {
            DataContractJsonSerializer format = new DataContractJsonSerializer(typeof(List<BitSaver>));
            using (FileStream fs = new FileStream(file_name, FileMode.Open))
            {

                return (List<BitSaver>)format.ReadObject(fs);
            }
        }

    }
}
