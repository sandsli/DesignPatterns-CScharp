using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    public class SingletonTest
    {
        public static void Test()
        {
            var tasks = new List<Task>();
            for (int i = 0; i < 20; i++)
            {
                tasks.Add(new Task(() =>
                {
                    Singleton singleton = Singleton.Instance();
                    singleton.GetData();
                }));
            }
            //并发执行20个任务
            tasks.AsParallel().ForAll(p => p.Start());
        }


        //private class Singleton
        //{
        //    /// <summary>
        //    /// 静态实例，利用静态字段把实例缓存起来
        //    /// </summary>
        //    private static Singleton singleton;

        //    /// <summary>
        //    /// 返回对象的唯一实例
        //    /// </summary>
        //    /// <returns></returns>
        //    public static Singleton Instance()
        //    {
        //        if (singleton == null)
        //        {
        //            Console.WriteLine("实例化对象");
        //            singleton = new Singleton();
        //        }
        //        return singleton;
        //    }

        //    public void GetData()
        //    {
        //        Console.WriteLine("调用了getdata()");
        //    }
        //}

        private class Singleton
        {
            /// <summary>
            /// 静态实例，利用静态字段把实例缓存起来
            /// </summary>
            private static Singleton singleton;

            private static object lockObj = new object();
            /// <summary>
            /// 返回对象的唯一实例
            /// </summary>
            /// <returns></returns>
            public static Singleton Instance()
            {
                if (singleton == null)
                {
                    lock (lockObj)
                    {
                        if (singleton == null)
                        {
                            Console.WriteLine("实例化对象");
                            singleton = new Singleton();
                        }
                    }
                }
                return singleton;
            }

            public void GetData()
            {
                Console.WriteLine("调用了getdata()");
            }
        }
    }
}
