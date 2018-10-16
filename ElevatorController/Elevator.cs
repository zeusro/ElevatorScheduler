using System;
using System.Collections.Generic;
using PassengerProducer;

namespace ElevatorController
{
    using System.Linq;

    /// <summary>
    /// 电梯,电梯需要内部维护自身的状态信息
    /// </summary>
    public class Elevator
    {

        /// <summary>
        /// 最大负重
        /// </summary>
        /// <value>The max load.</value>
        public int MaxLoad { get; set; }

        /// <summary>
        /// 当前负重
        /// </summary>
        /// <value>The current load.</value>
        public int CurrentLoad { get; set; }

        public int CurrentFloor { get; set; }

        //public int EachLayerTimeSpan { get; set; }

        //public int EachPersonStayTimeSpan { get; set; }

        //public int Get 

        public List<int> TargetFloor { get; set; }

        public Direction Direction { get; set; }

        public State CurrentState { get; set; }

        public DateTime Start { get; set; }

        ///// <summary>
        ///// 可选
        ///// </summary>
        ///// <value>The execute strategy logs.</value>
        //public List<ExecuteStrategy> ExecuteStrategyLogs { set; get; }


        public Elevator(int maxLoad, int currentFloor)
        {
            CurrentState = State.STOP;
            MaxLoad = maxLoad;
            CurrentFloor = currentFloor;
            TargetFloor = new List<int>();
            Start = DateTime.Now;
            //ExecuteStrategyLogs = new List<ExecuteStrategy>();
        }

        public OrderState Schedule(PassengerInfo passengerInfo)
        {
            if (passengerInfo == null)
            {
                throw new ArgumentException("passengerInfo");
            }
            if ((CurrentState & State.Overload) == State.Overload)
            {
                //超载了,拒绝任何指令
                return OrderState.DENY;
            }
            if (CurrentState == State.UP)
            {
                TargetFloor.AddRange(passengerInfo.EndFloor.Where(o => o > CurrentFloor));
            }
            if (CurrentState == State.DOWN)
            {
                TargetFloor.AddRange(passengerInfo.EndFloor.Where(o => o < CurrentFloor));
            }

            //todo:过滤无效指令
            //todo:预测到达时间
            //todo:需要另外一个线程维护电梯的状态变化,时间,当前楼层,目标楼层,状态
            TargetFloor = TargetFloor.Distinct().ToList();
            return OrderState.ACCEPT; ;
        }

        public object getCurrentState()
        {

            return null;
        }

    }
}
