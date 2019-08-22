using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BuilderPattern
{
    public abstract class Builder
    {
        public abstract void BuildPart();
    }

    public class ConcreteBuilder : Builder
    {
        public override void BuildPart()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 指挥者
    /// </summary>
    public class Director
    {

    }

    /// <summary>
    /// 产品
    /// </summary>
    public abstract class Product
    {

    }
}
