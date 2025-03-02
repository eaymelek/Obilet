using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    /// <summary>
    /// Represents a method interception.
    /// </summary>
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        /// <summary>
        /// Called before the method is executed.
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnBefore(IInvocation invocation) { }

        /// <summary>
        /// Called after the method is executed.
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnAfter(IInvocation invocation) { }

        /// <summary>
        /// Called when an exception is thrown.
        /// </summary>
        /// <param name="invocation"></param>
        /// <param name="e"></param>
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }

        /// <summary>
        /// Called when the method is executed successfully.
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnSuccess(IInvocation invocation) { }

        /// <summary>
        /// Intercepts the method.
        /// </summary>
        /// <param name="invocation"></param>
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
