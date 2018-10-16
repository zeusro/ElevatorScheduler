using System;
namespace ElevatorController
{
    /// <summary>
    /// 电梯的状态
    /// </summary>
    [Flags]
    public enum State
    {
        UP = 1,
        DOWN = 2,
        STOP = 4,
        Overload = 8,
    }
}
