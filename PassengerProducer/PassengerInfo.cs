using System;
using System.Collections.Generic;

namespace PassengerProducer
{
    public class PassengerInfo
    {
        public int StartFloor { get; private set; }

        public List<int> EndFloor { get; private set; }

        public Direction Direction { get; private set; }

        public DateTime Date { get; private set; }

        public PassengerInfo()
        {
            Date = DateTime.Now;
        }


        public static bool ValidateEndFloor(int startFloor, int endFloor)
        {
            return startFloor != endFloor;
        }

        public static PassengerInfo RandomGenerate(int maxFloor)
        {
            Random random = new Random((int)DateTimeOffset.Now.ToFileTime());

            int startFloor = random.Next(1, maxFloor + 1);
            List<int> endFloors = new List<int>();
            Direction direction;
            //80%的概率产生只有一个目的地,并且方向不按错
            int percentage1 = random.Next(1, 6);
            if (percentage1 <= 4)
            {
                int endFloor = random.Next(1, maxFloor + 1);
                while (!ValidateEndFloor(startFloor, endFloor))
                {
                    endFloor = random.Next(1, maxFloor + 1);
                }
                endFloors.Add(endFloor);
                if (endFloor < startFloor)
                {
                    direction = Direction.DOWN;
                }
                else
                {
                    direction = Direction.UP;
                }
            }
            else
            {
                for (int i = 0; i < random.Next(1, maxFloor); i++)
                {
                    int endFloor = random.Next(1, maxFloor + 1);
                    while (!ValidateEndFloor(startFloor, endFloor))
                    {
                        endFloor = random.Next(1, maxFloor + 1);
                    }
                    endFloors.Add(endFloor);
                }
                //方向乱按
                int percentage2 = random.Next(0, 2);
                if (percentage1 == 0)
                {
                    direction = Direction.DOWN;
                }else
                {
                    direction = Direction.UP;
                }
            }
            return new PassengerInfo()
            {
                StartFloor = startFloor,
                EndFloor = endFloors,
                Direction = direction,
            };
        }
    }
}
