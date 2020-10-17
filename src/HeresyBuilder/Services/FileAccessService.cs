using HeresyBuilder.Models;
using HeresyBuilder.Singleton;
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
        private static string appPrefix = "HeresyBuilder";

        private static string charactersPrefix = "characters";


        public List<World> GetHomeworlds()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var heresyBuilderPath = Path.Combine(path, appPrefix);
            var homeworldsPath = Path.Combine(heresyBuilderPath, "homeworlds");
            DirectoryInfo directory = new DirectoryInfo(homeworldsPath);
            FileInfo[] Files = directory.GetFiles("*.json"); //Getting Text files
            List<World> homeworlds = new List<World>();

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
                var newHomeworld = JsonConvert.DeserializeObject<List<World>>(str);
                homeworlds.AddRange(newHomeworld);
            }

            return homeworlds;
        }

        public List<Background> GetBackgrounds()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var heresyBuilderPath = Path.Combine(path, appPrefix);
            var backgroundsPath = Path.Combine(heresyBuilderPath, "background");
            DirectoryInfo directory = new DirectoryInfo(backgroundsPath);
            FileInfo[] Files = directory.GetFiles("*.json"); //Getting Text files
            List<Background> backgrounds = new List<Background>();

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
                var newBackground = JsonConvert.DeserializeObject<List<Background>>(str);
                backgrounds.AddRange(newBackground);
            }

            return backgrounds;
        }

        public List<Role> GetRoles()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var heresyBuilderPath = Path.Combine(path, appPrefix);
            var rolesPath = Path.Combine(heresyBuilderPath, "role");
            DirectoryInfo directory = new DirectoryInfo(rolesPath);
            FileInfo[] Files = directory.GetFiles("*.json"); //Getting Text files
            List<Role> roles = new List<Role>();

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
                var newRole = JsonConvert.DeserializeObject<List<Role>>(str);
                roles.AddRange(newRole);
            }

            return roles;
        }

        public void SaveCharacter()
        {
            var character = CurrentCharacterCreationData.Instance.ToCharacter();
            var characterJson = JsonConvert.SerializeObject(character);

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var heresyBuilderPath = Path.Combine(path, appPrefix);
            var charactersPath = Path.Combine(heresyBuilderPath, charactersPrefix);
            Directory.CreateDirectory(charactersPath);
            var characterPath = Path.Combine(charactersPath, character.Name);
            Directory.CreateDirectory(characterPath);
            var characterJsonPath = Path.Combine(characterPath, character.Name + ".json");
            File.WriteAllText(characterJsonPath, characterJson);
        }
    }
}
