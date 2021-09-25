using BAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Factory
{
    public class BusinessFactory
    {
        public static IIntegerParserBusiness GetObject()
        {
            return new IntegerParserBusiness();
        }
    }
}
