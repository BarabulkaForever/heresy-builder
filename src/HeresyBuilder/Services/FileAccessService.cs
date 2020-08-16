using HeresyBuilder.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeresyBuilder.Services
{
    public class FileAccessService
    {
        public List<World> GetHomeworlds()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var heresyBuilderPath = Path.Combine(path, "HeresyBuilder");
            var homeworldsPath = Path.Combine(heresyBuilderPath, "homeworlds");
            DirectoryInfo directory = new DirectoryInfo(homeworldsPath);
            FileInfo[] Files = directory.GetFiles("*.json"); //Getting Text files
            List<World> backgrounds = new List<World>();

            foreach (FileInfo file in Files)
            {
                string str = "";
                using (StreamReader sr = file.OpenText())
                {
                    string stringBuffer = "";
                    while ((stringBuffer = sr.ReadLine()) != null)
                    {
                        str += stringBuffer;
                    }
                }
                var newBackgrounds = JsonConvert.DeserializeObject<List<World>>(str);
                backgrounds.AddRange(newBackgrounds);
            }

            return backgrounds;
        }
    }
}
