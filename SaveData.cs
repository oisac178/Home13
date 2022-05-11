using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        static object obj = new object();
        static readonly string path = @"clients.mydata";
        public string Path => path;
        
        public delegate void OptionDataProcessing(string Data);
        //public List<Client> TackMethod(string path)
        //{
        //    int id = Thread.CurrentThread.ManagedThreadId;
        //    List<Client> people;
        //    lock (obj)
        //    {
        //        Console.WriteLine("Загрузка :" + path + $"Поток id {id}");
        //        people = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(path));
        //    }
        //}
        public List<Client> TaskMethod(object p)
        {
            string path = (string)p;
            lock (obj)
            {
                Console.WriteLine("Загрузка :" + path);
                List<Client> people = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(path));
                return people;
            }
        }
        
        public List<Client> ClientsFromJSON()
        {
            List<Client> people = new List<Client>();
            Console.WriteLine("Загрузка базы ...");
            //if (!File.Exists(path))
            //{
            //    throw new FileNotFoundException(path);
            //}
            //Thread thread1 = new Thread(() => ThreadMethod("")); thread1.Start(@"clients2.mydata");
            //Thread thread2 = new Thread(() => ThreadMethod("")); thread2.Start(@"clients3.mydata");
            //Thread thread3 = new Thread(() => ThreadMethod("")); thread3.Start(@"clients4.mydata");
            //Thread thread4 = new Thread(() => ThreadMethod("")); thread4.Start(@"clients5.mydata");
            //Thread thread5 = new Thread(() => ThreadMethod("")); thread5.Start(@"clients6.mydata");
            //Thread thread6 = new Thread(() => ThreadMethod("")); thread6.Start(@"clients7.mydata");
            //ThreadMethod(@"clients.mydata");
            //List<Client> people = ThreadMethod("");
            Task<List<Client>> task1 = Task<List<Client>>.Factory.StartNew(TaskMethod, @"clients.mydata");
            Task<List<Client>> task2 = Task<List<Client>>.Factory.StartNew(TaskMethod, @"clients2.mydata");
            Task<List<Client>> task3 = Task<List<Client>>.Factory.StartNew(TaskMethod, @"clients3.mydata");
            Task<List<Client>> task4 = Task<List<Client>>.Factory.StartNew(TaskMethod, @"clients4.mydata");
            Task<List<Client>> task5 = Task<List<Client>>.Factory.StartNew(TaskMethod, @"clients5.mydata");
            Task<List<Client>> task6 = Task<List<Client>>.Factory.StartNew(TaskMethod, @"clients6.mydata");
            Task<List<Client>> task7 = Task<List<Client>>.Factory.StartNew(TaskMethod, @"clients7.mydata");
            task1.Wait();
            people.AddRange(task1.Result);
            task2.Wait();
            people.AddRange(task2.Result);
            task3.Wait();
            people.AddRange(task3.Result);
            task4.Wait();
            people.AddRange(task4.Result);
            task5.Wait();
            people.AddRange(task5.Result);
            task6.Wait();
            people.AddRange(task6.Result);
            task7.Wait();
            people.AddRange(task7.Result);
            
            task1.Dispose();
            task2.Dispose();
            task3.Dispose();
            task4.Dispose();
            task5.Dispose();
            task6.Dispose();
            task7.Dispose();

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
