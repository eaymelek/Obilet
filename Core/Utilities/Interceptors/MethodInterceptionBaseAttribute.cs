using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    /// <summary>
    /// Represents a method interception base attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        /// <summary>
        /// Gets or sets the priority of the interception.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Intercepts the method.
        /// </summary>
        /// <param name="invocation"></param>
        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
