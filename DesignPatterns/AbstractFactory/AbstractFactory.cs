using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.AbstractFactory
{
    /// <summary>
    /// 抽象工厂
    /// </summary>
    public abstract class AbstractFactory
    {
        public virtual ElectronicProduct GetElectronicProduct(string name)
        {
            throw new NullReferenceException();
        }
        public virtual CarProduct GetCarProduct(string name)
        {
            throw new NullReferenceException();
        }
    }
    /// <summary>
    /// 抽象工厂生成器，抽象工厂的调用入口
    /// </summary>
    public class FactoryProducer
    {
        /// <summary>
        /// 根据名称获取子类工厂的实例
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static AbstractFactory GetFactory(string name)
        {
            if (name.ToLower() == "car")
                return new CarFactory();
            if (name.ToLower() == "electronic")
                return new ElectronicFactory();
            return null;
        }
    }


    #region 子类工厂 实现抽象工厂的方法
    public class CarFactory : AbstractFactory
    {
        public override CarProduct GetCarProduct(string name)
        {
            if (name.ToLower() == "motorbike")
                return new Motorbike();
            if (name.ToLower() == "xpandrally")
                return new XpandRally();
            throw new Exception("unknow product name");
        }
    }

    public class ElectronicFactory : AbstractFactory
    {
        public override ElectronicProduct GetElectronicProduct(string name)
        {
            if (name.ToLower() == "tv")
                return new TV();
            if (name.ToLower() == "mp4")
                return new MP4();
            if (name.ToLower() == "mp3")
                return new MP3();
            throw new Exception("unknow product name");
        }
    }

    #endregion

    #region 子类工厂的产品

    public abstract class CarProduct
    {
        public abstract void Run();
    }

    public class Motorbike : CarProduct
    {
        public override void Run()
        {
            Console.WriteLine("摩托车");
        }
    }

    public class XpandRally : CarProduct
    {
        public override void Run()
        {
            Console.WriteLine("拉力赛车");
        }
    }


    public abstract class ElectronicProduct
    {
        public abstract void Play();
    }

    public class TV : ElectronicProduct
    {
        public override void Play()
        {
            Console.WriteLine("TV play");
        }
    }

    public class MP4 : ElectronicProduct
    {
        public override void Play()
        {
            Console.WriteLine("MP4 play");
        }
    }

    public class MP3 : ElectronicProduct
    {
        public override void Play()
        {
            Console.WriteLine("MP3 play");
        }
    }

    #endregion


    public class AbstractFactoryTest
    {
        public static void Test()
        {
            //实例化造车工厂
            AbstractFactory carFactory = FactoryProducer.GetFactory("car");
            //获取摩托车实例
            var motorbike = carFactory.GetCarProduct("motorbike");
            //执行实例方法
            motorbike.Run();
            //实例化电子厂
            AbstractFactory electronicFactory = FactoryProducer.GetFactory("electronic");
            //获取tv实例
            var tv = electronicFactory.GetElectronicProduct("tv");
            tv.Play();

        }

    }
}
