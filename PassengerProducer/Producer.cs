using System;

namespace PassengerProducer
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class Producer
    {

        public int ThreadNumber { get; set; }

        public int MaxFloor { get; set; }

        public ConcurrentQueue<PassengerInfo> Passenger { get; private set; }

        public Producer(int threadNumber, int maxFloor)
        {
            Passenger = new ConcurrentQueue<PassengerInfo>();
            ThreadNumber = threadNumber;
            MaxFloor = maxFloor;
        }

        public void Start()
        {
            var task1 = Task.Factory.StartNew(() =>
           {
               Console.WriteLine("开始随机创建乘客");
               //Console.WriteLine("task1");
               for (int ctr = 0; ctr < ThreadNumber; ctr++)
               {
                   int taskNo = ctr;
                   Task.Factory.StartNew((x) =>
                   {
                       while (true)
                       {
                           Random random = new Random((int)DateTimeOffset.Now.ToFileTime());
                           //Thread.SpinWait(random.Next(1000, 3000));
                           Thread.SpinWait(random.Next(3000, 18000));
                           PassengerInfo passengerInfo = PassengerInfo.RandomGenerate(MaxFloor);
                           //Console.WriteLine("加入{0}", JsonConvert.SerializeObject(passengerInfo));                           
                           Passenger.Enqueue(passengerInfo);
                       }
                   },
                   taskNo, TaskCreationOptions.AttachedToParent);
               }
           });
            //task1.Wait();
            //task2.Wait();
            //Console.WriteLine("Parent task completed.");
        }

    }
}

