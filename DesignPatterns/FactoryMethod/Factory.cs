using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.FactoryMethod
{
    public class Factory
    {
        /// <summary>
        /// 通过名称决定实例化哪种子类对象
        /// </summary>
        /// <param name="name">对象名称</param>
        /// <returns></returns>
        public Product GetProduct(string name)
        {
            if (name.ToLower() == "tv")
                return new TV();
            if (name.ToLower() == "mp4")
                return new MP4();
            if (name.ToLower() == "mp3")
                return new MP3();
            throw new Exception("unknow product name");
        }

        public static void Test()
        {
            var factory = new Factory();
            var tv = factory.GetProduct("tv");
            tv.Play();
            var mp4 = factory.GetProduct("mp4");
            mp4.Play();
        }
    }

    public abstract class Product
    {
        public abstract void Play();
    }

    public class TV : Product
    {
        public override void Play()
        {
            Console.WriteLine("TV play");
        }
    }

    public class MP4 : Product
    {
        public override void Play()
        {
            Console.WriteLine("MP4 play");
        }
    }

    public class MP3 : Product
    {
        public override void Play()
        {
            Console.WriteLine("MP3 play");
        }
    }
}
