using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    internal class MyRequiredAttribute : MyValidatoinAttribute
    {
        public override bool IsValid(object obj)
        {
            return obj != null;
        }
    }
}
