using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    internal abstract class MyValidatoinAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
