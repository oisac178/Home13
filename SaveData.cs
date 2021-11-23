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
        string path = @"clients.json";
        Clients people = new Clients();
        people.ClientsFromJSON(path);
    

    public void ClientsFromJSON(string Path)
        {
            string json = File.ReadAllText(Path);
            people = JsonConvert.DeserializeObject<ObservableCollection<Clients>>(json);
        }
    }
    public void ClientsToJSON(string Path)
    {
        string json = JsonConvert.SerializeObject(people);
        File.WriteAllText(Path, json);
    }
}
