using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace tictacGame
{
    public static class MySerilize
    {
        static public void saveResult(List<Statistic> list, string fileName) {
            /*XmlSerializer ser = new XmlSerializer(typeof(List<Statistic>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                ser.Serialize(fs, list);
            }*/

            string json = JsonConvert.SerializeObject(list);
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                fs.Write(System.Text.Encoding.Default.GetBytes(json), 0, json.Length);
            }
        }

        static public List<Statistic> readResult(string fileName)
        {
            List<Statistic> list = new List<Statistic>();
            /*XmlSerializer ser = new XmlSerializer(typeof(List<Statistic>));
            using (StreamReader sr = new StreamReader(fileName))
            {
                list = (List<Statistic>)ser.Deserialize(sr);
            }*/
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    list = JsonConvert.DeserializeObject<List<Statistic>>(sr.ReadToEnd());
                }
            }
            catch  { }
            return list;
        }
    }
}
