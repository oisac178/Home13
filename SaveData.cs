﻿using System;
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
    }
   
    public class SaveData : ILoad
    {
        static readonly string path = @"clients.json";
        private string json;

        public string Path => path;

        public List<Client> ClientsFromJSON()
        {
            if (File.Exists(path))
            {
                json = File.ReadAllText(path);
            }

            List<Client> people = JsonConvert.DeserializeObject<List<Client>>(json);
            return people;
        }

        public void ClientsToJSON(List<Client> clients)
        {
            string json = JsonConvert.SerializeObject(clients);
            File.WriteAllText(path, json);
        }
    }
}
