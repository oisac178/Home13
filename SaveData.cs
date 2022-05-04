using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        static object obj = new object();
        static readonly string path;
        public string Path => path;

        public delegate void OptionDataProcessing(string Data);

        public List<Client> ThreadMethod(string path)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            List<Client> people;
            lock (obj)
            {
                Console.WriteLine("Загрузка :" + path + $"Поток id {id}");
                people = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(path));
            }
            return people;
        }
        
        public List<Client> ClientsFromJSON()
        {
            //if (!File.Exists(path))
            //{
            //    throw new FileNotFoundException(path);
            //}
            Thread thread1 = new Thread(ThreadMethod); thread1.Start(@"clients2.mydata");
            Thread thread2 = new Thread(ThreadMethod); thread2.Start(@"clients3.mydata");
            Thread thread3 = new Thread(ThreadMethod); thread3.Start(@"clients4.mydata");
            Thread thread4 = new Thread(ThreadMethod); thread4.Start(@"clients5.mydata");
            Thread thread5 = new Thread(ThreadMethod); thread5.Start(@"clients6.mydata");
            Thread thread6 = new Thread(ThreadMethod); thread6.Start(@"clients7.mydata");
            ThreadMethod(@"clients.mydata");
            return ThreadMethod.people;
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
