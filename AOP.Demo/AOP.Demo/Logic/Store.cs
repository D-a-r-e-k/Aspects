using AOP.Demo.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Demo.Logic
{
    [CountableAspect]
    public class Store
    {
        private int _state = 2;

        [CachingAspect]
        public int GetModifiedState(int x)
        {
            Console.WriteLine("I visited " + nameof(GetModifiedState));

            return _state + x;
        }
    }
}
