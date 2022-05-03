using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Home13
{
    public interface ILoad
    {
        List<Client> ClientsFromJSON();
        void ClientsToJSON(List<Client> clients);
        string Path { get; }
    }

    public class SaveData : ILoad
    {
        
        foreach (var path in GetMyFiles.files)
            string pathIn = path;
        //static readonly string path = @"clients.json";
        public string Path => path;

        public delegate void OptionDataProcessing(string Data);
        
        public List<string> GetMyFiles()
        {
            List<string> files = new List<string>();
            FileHelper.GetAllFiles(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "*.mydata", files);            
            return files;
        }

        public List<Client> ClientsFromJSON()
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            
            List<Client> people = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(path));
            return people;
        }

        public void ClientsToJSON(List<Client> clients)
        {
            string json = JsonConvert.SerializeObject(clients);
            File.WriteAllText(path, json);
        }

        private OptionDataProcessing process;

        public void SetProcess(OptionDataProcessing Option)
        {
            this.process = Option;
        }       
    }
}
