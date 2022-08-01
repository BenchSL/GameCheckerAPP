using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace GameCheckerWpf.Threads
{
    public static class WPFExtensions
    {
        public static System.ComponentModel.ISynchronizeInvoke ISynchronizeInvoke
            (this System.Windows.Threading.DispatcherObject dispatcher)
        {
            return new DispatcherSynchronizeInvoke(dispatcher.Dispatcher);
        }
    }

        class DispatcherSynchronizeInvoke : System.ComponentModel.ISynchronizeInvoke
        {
            private readonly Dispatcher dispatcher;

            public DispatcherSynchronizeInvoke(Dispatcher dispatcher)
            {
                this.dispatcher = dispatcher;
            }

            public IAsyncResult BeginInvoke(Delegate method, object[] args)
            {
                return new DispatcherAsyncResult(
                    this.dispatcher.BeginInvoke(method, DispatcherPriority.Normal, args));
            }

            public object EndInvoke(IAsyncResult result)
            {
                DispatcherAsyncResult dispatcherResult = result as DispatcherAsyncResult;
                dispatcherResult.Operation.Wait();
                return dispatcherResult.Operation.Result;
            }

            public object Invoke(Delegate method, object[] args)
            {
                return dispatcher.Invoke(method, DispatcherPriority.Normal, args);
            }

            public bool InvokeRequired => !this.dispatcher.CheckAccess();

            private class DispatcherAsyncResult : IAsyncResult
            {
                private readonly IAsyncResult result;

                public DispatcherAsyncResult(DispatcherOperation operation)
                {
                    this.Operation = operation;
                    this.result = operation.Task;
                }

                public DispatcherOperation Operation { get; }

                public bool IsCompleted => this.result.IsCompleted;
                WaitHandle IAsyncResult.AsyncWaitHandle => this.result.AsyncWaitHandle;
                public object AsyncState => this.result.AsyncState;
                public bool CompletedSynchronously => this.result.CompletedSynchronously;
            }
        }
    
}
