using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElevatorController;
using Newtonsoft.Json;
using PassengerProducer;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            //实际上,电梯存储了2部分数据
            //第一部分,电梯里面的人按的楼层
            //第二部分,电梯需要接收来自总控制台的调度
            Producer producer = new Producer(1, 30);
            producer.Start();
            Console.WriteLine("电梯开始运作");
            int maxLoad = 1000;
            //另外一个线程随时同步电梯的状态
            List<Elevator> elevators = new List<Elevator>(){
                new Elevator(maxLoad, 1),
                new Elevator(maxLoad, 1),
                new Elevator(maxLoad, 1)
            };
            while (true)
            {
                PassengerInfo tempPassengerInfo;
                while (!producer.Passenger.TryDequeue(out tempPassengerInfo))
                {
                    //Console.WriteLine("继续等待");
                    Thread.SpinWait(1000);
                }
                //tempPassengerInfo.
                //todo:调度现有电梯,指派任务
            }

            //Console.ReadLine();

            //人员的进出
            //电梯的运行
        }
    }
}
