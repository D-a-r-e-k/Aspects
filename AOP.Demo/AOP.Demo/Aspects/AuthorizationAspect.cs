using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using PostSharp.Extensibility;

namespace AOP.Demo.Aspects
{
    [PSerializable]
    public class AuthorizationAspect : OnMethodBoundaryAspect
    {
        private List<string> WhiteList = new List<string>()
        {
            "Petras",
            "Jonas"
        };

        public override bool CompileTimeValidate(MethodBase method)
        {
            var args = method.GetParameters().ToList() ;

            if (args.Count == 3)
            {
                if (args[0].ParameterType == typeof(string) &&
                    args[1].ParameterType == typeof(string) &&
                    args[2].ParameterType == typeof(int))
                {
                    return true;
                }
            }

            Message.Write(method, SeverityType.Error, "ERROR1", $"Aspect not applicable to this method. {args[0].ParameterType}");
            return false;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!WhiteList.Contains(args.Arguments[0]))
            {
                throw new Exception("Username is not permitted");
            }
        }
    }
}
