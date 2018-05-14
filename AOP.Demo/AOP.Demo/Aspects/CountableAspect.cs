using AOP.Demo.Logic;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Demo.Aspects
{
    [IntroduceInterface(typeof(ICountable))]
    [PSerializable]
    public class CountableAspect : InstanceLevelAspect, ICountable
    {
        private int _count;

        public void Dec()
        {
            if (_count > 0)
                _count--;
        }

        public int GetCount()
        {
            return _count;
        }

        public void Inc()
        {
            _count++;
        }
    }
}
