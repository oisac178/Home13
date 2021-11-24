using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Home13
{
    public class SaveData
    {
        static readonly string path = @"clients.json";

        public Clients ClientsFromJSON()
        {
            string json = File.ReadAllText(path);
            var people = JsonConvert.DeserializeObject<Clients>(json);
            return people;
        }

        public void ClientsToJSON(Clients clients)
        {
            string json = JsonConvert.SerializeObject(clients);
            File.WriteAllText(path, json);
        }
    }
}
