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
        static readonly string path = @"clients.json";
        public string Path => path;

        public delegate void OptionDataProcessing(string Data);
        
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
