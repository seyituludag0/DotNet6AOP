using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private readonly LoggerServiceBase _loggerServiceBase;
        public ExceptionLogAspect(Type loggerType)
        {
            if (typeof(LoggerServiceBase).IsAssignableFrom(loggerType) == false)
            {
                throw new System.Exception("WrongLoggingTypeException");
            }
            _loggerServiceBase = (LoggerServiceBase)ServiceTool.ServiceProvider.GetService(loggerType);


        }
        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            _loggerServiceBase.Error(GetLogDetail(invocation, e));
        }

        private string GetLogDetail(IInvocation invocation, System.Exception e)
        {
            List<LogParameter> parameters = invocation.Arguments.Select((p, i) => new LogParameter
            {
                Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                Type = invocation.Arguments[i].GetType().ToString(),
                Value = invocation.Arguments[i]
            }).ToList();
            LogDetailWithException logDetailWithException = new()
            {
                MethodName = invocation.GetConcreteMethod().Name,
                LogParameters = parameters,
                ExceptionMessage = e.Message
            };
            return JsonConvert.SerializeObject(logDetailWithException);
        }
    }
}
