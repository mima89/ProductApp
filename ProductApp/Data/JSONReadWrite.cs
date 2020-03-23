using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProductApp.Data
{
    public class JSONReadWrite
    {
        public string Read(string filename, string location)
        {
            string jsonResult = "";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, location, filename);

            using (StreamReader streamReader = new StreamReader(path))
            {
                jsonResult = streamReader.ReadToEnd();
            }

            return jsonResult;
        }

        public void Write(string filename, string location, string jsonString)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, location, filename);

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
               streamWriter.Write(jsonString);
            }
        }
    }
}