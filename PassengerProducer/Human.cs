using System;
namespace PassengerProducer
{
    public class Human
    {
        public Human()
        {
        }

        public string ID { get; set; }

        /// <summary>
        /// 公斤
        /// </summary>
        /// <value>The weight.</value>
        public int Weight { get; set; }

        public static Human RandomGenerate()
        {
            Random random = new Random((int)DateTimeOffset.Now.ToFileTime());
            Human human = new Human()
            {
                Weight = random.Next(45, 80)
            };
            return human;
        }
    }
}
