using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;

namespace Naninovel.Async.CompilerServices
{
    public struct AsyncUniTaskVoidMethodBuilder
    {
        private Action moveNext;

        // 1. Static Create method.
        [DebuggerHidden]
        public static AsyncUniTaskVoidMethodBuilder Create ()
        {
            var builder = new AsyncUniTaskVoidMethodBuilder();
            return builder;
        }

        // 2. TaskLike Task property(void)
        public UniTaskVoid Task => default;

        // 3. SetException
        [DebuggerHidden]
        public void SetException (Exception exception)
        {
            UniTaskScheduler.PublishUnobservedTaskException(exception);
        }

        // 4. SetResult
        [DebuggerHidden]
        public void SetResult ()
        {
            // do nothing
        }

        // 5. AwaitOnCompleted
        [DebuggerHidden]
        public void AwaitOnCompleted<TAwaiter, TStateMachine> (ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
            if (moveNext == null)
            {
                var runner = new MoveNextRunner<TStateMachine>();
                moveNext = runner.Run;
                runner.StateMachine = stateMachine; // set after create delegate.
            }

            awaiter.OnCompleted(moveNext);
        }

        // 6. AwaitUnsafeOnCompleted
        [DebuggerHidden]
        [SecuritySafeCritical]
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine> (ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
            if (moveNext == null)
            {
                var runner = new MoveNextRunner<TStateMachine>();
                moveNext = runner.Run;
                runner.StateMachine = stateMachine; // set after create delegate.
            }

            awaiter.UnsafeOnCompleted(moveNext);
        }

        // 7. Start
        [DebuggerHidden]
        public void Start<TStateMachine> (ref TStateMachine stateMachine)
            where TStateMachine : IAsyncStateMachine
        {
            stateMachine.MoveNext();
        }

        // 8. SetStateMachine
        [DebuggerHidden]
        public void SetStateMachine (IAsyncStateMachine stateMachine) { }

        #if UNITY_EDITOR
        // Important for IDE debugger.
        private object debuggingId;
        private object ObjectIdForDebugger => debuggingId ??= new();
        #endif
    }
}
