using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Publiser pb = new Publiser();
            EventReader1 er1 = new EventReader1(pb);
            EventReader2 er2 = new EventReader2(pb);
            pb.LaunchEvnet();
            Console.ReadLine();
        }

        /// <summary>
        /// 事件发布者
        /// </summary>
        public class Publiser
        {
            //定义一个提供处理事件的委托
            public delegate void EventDelegate(string evnetInfo);
            //定义一个事件
            public event EventDelegate myEvent;

            public Publiser()
            {

            }

            public void LaunchEvnet()
            {
                if (this.myEvent != null)
                {
                    Console.WriteLine("Event launch");
                    this.myEvent("event happening!");
                }
            }
        }
        
        /// <summary>
        /// 事件订阅者1
        /// </summary>
        public class EventReader1
        {
            public EventReader1(Publiser pb)
            {
                pb.myEvent += new Publiser.EventDelegate(OnEvent);
            }

            public void OnEvent(string eventInfo)
            {
                Console.WriteLine("EventReader1:" + eventInfo);
            }
        }

        /// <summary>
        /// 事件订阅者2
        /// </summary>
        public class EventReader2
        {
            public EventReader2(Publiser pb)
            {
                pb.myEvent += new Publiser.EventDelegate(OnEvent);
            }

            public void OnEvent(string eventInfo)
            {
                Console.WriteLine("EventReader2:" + eventInfo);
            }
        }
    }
}
