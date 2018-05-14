using log4net;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Diagnostics;

namespace AOP.Demo.Aspects
{
    [PSerializable]
    public class InspectionAspect : OnMethodBoundaryAspect
    {
        public DateTime Start { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            Start = DateTime.Now;

            var logger = LogManager.GetLogger(typeof(InspectionAspect));
            logger.Info(args.Method.Name);
            logger.Info(DateTime.Now.ToString("h:mm:ss tt"));
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {

            var logger = LogManager.GetLogger(typeof(InspectionAspect));
            logger.Info(args.Method.Name);
            logger.Info(DateTime.Now.ToString("h:mm:ss tt"));
            logger.Info(DateTime.Now - Start);
        }
    }
}
