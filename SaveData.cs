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

        public List<Client> ClientsFromJSON()
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            List<Client> people = JsonConvert.DeserializeObject<List<Client>>(Json);
            return people;
        }

        public void ClientsToJSON(List<Client> clients)
        {
            string json = JsonConvert.SerializeObject(clients);
            File.WriteAllText(path, json);
        }
    }
}
