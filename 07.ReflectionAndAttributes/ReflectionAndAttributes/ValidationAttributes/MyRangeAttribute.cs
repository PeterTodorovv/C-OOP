using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    internal class MyRangeAttribute : MyValidatoinAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            return true;
        }
    }
}
