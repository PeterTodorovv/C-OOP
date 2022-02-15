using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public interface IBuyer
    {
        public string Name { get; set; }
        public int Food { get; set; }
        void BuyFood();
    }
}
