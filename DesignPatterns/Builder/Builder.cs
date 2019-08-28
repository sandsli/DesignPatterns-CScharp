using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder
{
    public class BuilderTest
    {
        /***
        * 抽象的建造者只关心对象有哪些步骤，
        * 具体的建造者只关心如何实现每一个具体的步骤，
        * 指挥者只关心构建的顺序，
        * 三方各司其职，很好的隔离了构建对象的步骤和顺序，
        * 一但指挥者和建造者确定了，开发者只需要关心如何实现和更新具体步骤就行了，
        */
        public static void Test()
        {
            Builder builder1 = new ConcreteBuilder();
            Director director = new Director(builder1);
            director.Consttruct();
            var product = builder1.GetResult();
            product.Show();
        }


        /// <summary>
        /// 抽象的建造者,定义了建造者的执行步骤
        /// </summary>
        public abstract class Builder
        {
            /// <summary>
            /// 构建的步骤
            /// </summary>
            public abstract void BuidPart1();
            public abstract void BuidPart2();
            public abstract void BuidPart3();

            /// <summary>
            /// 构建完成后的
            /// </summary>
            /// <returns></returns>
            public abstract Product GetResult();
        }
        /// <summary>
        /// 具体的建造者
        /// </summary>
        public class ConcreteBuilder : Builder
        {
            Product product;

            public ConcreteBuilder()
            {
                product = new Product();
            }
            /// <summary>
            /// 具体实现构建产品的步骤
            /// </summary>
            public override void BuidPart1()
            {
                product.AddPart("步骤1");
            }

            public override void BuidPart2()
            {
                product.AddPart("步骤2");
            }

            public override void BuidPart3()
            {
                product.AddPart("步骤3");
            }

            /// <summary>
            /// 返回构建完成的产品
            /// </summary>
            /// <returns></returns>
            public override Product GetResult()
            {
                return product;
            }
        }

        /// <summary>
        /// 产品
        /// </summary>
        public class Product
        {
            public List<string> parts;

            public Product()
            {
                this.parts = new List<string>();
            }

            /// <summary>
            /// 安装零件
            /// </summary>
            /// <param name="part"></param>
            public void AddPart(string part)
            {
                this.parts.Add(part);
            }

            /// <summary>
            /// 展示产品
            /// </summary>
            public void Show()
            {
                this.parts.ForEach(p => Console.WriteLine(p));
            }
        }



        /// <summary>
        /// 指挥者 指挥某个建造者按照一定的顺序组装产品
        /// </summary>
        public class Director
        {
            Builder builder;

            /// <summary>
            /// 和 builder是 聚合关系，builder是观察者的一个组成部分
            /// </summary>
            /// <param name="builder"></param>
            public Director(Builder builder)
            {
                this.builder = builder;
            }

            /// <summary>
            /// 指挥者开始建造
            /// </summary>
            public void Consttruct()
            {
                //定义建造者的建造顺序
                builder.BuidPart1();
                builder.BuidPart3();
                builder.BuidPart2();
            }
        }


       
    }

}
