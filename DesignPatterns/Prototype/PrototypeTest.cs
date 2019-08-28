using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Prototype
{
    public class PrototypeTest
    {
        public static void Test()
        {
            //如果不用克隆
            {
                Product product = new Product();
                product.Name = "cpu";

                Product copy = product;
                copy.Name = "memory";

                Console.WriteLine(product.Name);
                Console.WriteLine(copy.Name);
            }
            //用克隆
            {
                Product product = new Product();
                product.Name = "cpu";

                Product copy = product.Clone() as Product;
                copy.Name = "memory";
                Console.WriteLine(product.Name);
                Console.WriteLine(copy.Name);
            }


        }

        /// <summary>
        /// 支持克隆，将创建具有相同值的类的新实例
        /// </summary>
        public class Product : ICloneable
        {
            public string Name { get; set; }

            public object Clone()
            {
                return new Product
                {
                    Name = this.Name,
                };
            }
        }
    }
}
