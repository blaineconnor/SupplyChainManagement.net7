using ArxOne.MrAdvice.Advice;
using Serilog;
using System.Diagnostics;

namespace SCM.Application.Behaviors
{
    public class PerformanceBehavior : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            context.Proceed();

            watch.Stop();

            var totalDuration = watch.Elapsed.TotalSeconds;

            Log.Information($"{context.TargetName} metodu {totalDuration} saniyede tamamlandı.");
        }
    }
}
