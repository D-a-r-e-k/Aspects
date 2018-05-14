using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Demo.Aspects
{
    [PSerializable]
    public class CachingAspect : OnMethodBoundaryAspect
    {
        private int _expirationTime = 1;

        public override bool CompileTimeValidate(MethodBase method)
        {
            var args = method.GetParameters().ToList();

            if (args.Count == 1 && ((MethodInfo)method).ReturnType != typeof(void))
            {
                return true;
            }

            Message.Write(method, SeverityType.Error, "ERROR1", $"Aspect not applicable to this method. {args[0].ParameterType}");
            return false;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var cache = MemoryCache.Default;

            var item = cache.Get($"{args.Instance.GetHashCode()}.{args.Method.Name}.{args.Arguments[0]}");
            if (item != null)
            {
                args.ReturnValue = item;
                args.FlowBehavior = FlowBehavior.Return;
            }
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
     //       obj = new SomeClass(); ....
     //CacheItemPolicy policy = new CacheItemPolicy();
     //       //update
     //       policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(1);
     //       cache.Set("CACHE_KEY", obj, policy);

            base.OnSuccess(args);
        }
    }
}
