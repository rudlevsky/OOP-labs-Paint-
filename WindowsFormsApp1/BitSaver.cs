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
    //[Serializable]
    [DataContract]
    class BitSaver //: ISerializable
    {
        [DataMember]
        byte[] saver;

        public void to_set(Bitmap perem)
        {
            ImageConverter converter = new ImageConverter();
            saver = (byte[])converter.ConvertTo(perem, typeof(byte[]));
        }

        public Bitmap to_get()
        {
            ImageConverter ic = new ImageConverter();
            Image img = (Image)ic.ConvertFrom(saver);
            Bitmap bitmap1 = new Bitmap(img);

           /* Bitmap bit;
            using (var ms = new MemoryStream(saver))
            {
                bit = new Bitmap(ms);
            }*/
            return bitmap1;
        }

      /*  public BitSaver() { }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("bitmap", saver, typeof(byte[]));
        }

        // The special constructor is used to deserialize values.
        public BitSaver(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            saver = (byte[])info.GetValue("bitmap", typeof(byte[]));
        }*/
    }
}
