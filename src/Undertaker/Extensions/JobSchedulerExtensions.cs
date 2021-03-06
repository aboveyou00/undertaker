﻿using JetBrains.Annotations;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Undertaker.Extensions
{
    public static class JobSchedulerExtensions
    {
        [MustUseReturnValue]
        public static IJobBuilder After(this IJobScheduler scheduler, DateTime dateTime)
        {
            return scheduler.BuildJob().After(dateTime);
        }
        [MustUseReturnValue]
        public static IJobBuilder After(this IJobScheduler scheduler, IJob job)
        {
            return scheduler.BuildJob().After(job);
        }

        public static Task<IJob> EnqueueAsync<T>(this IJobScheduler scheduler, Expression<Action<T>> job)
        {
            return scheduler.BuildJob().EnqueueAsync(job);
        }
        public static Task<IJob> EnqueueAsync<T>(this IJobScheduler scheduler, Expression<Func<T, Task>> job)
        {
            return scheduler.BuildJob().EnqueueAsync(job);
        }
        public static Task<IJob> EnqueueAsync(this IJobScheduler scheduler, Expression<Action> job)
        {
            return scheduler.BuildJob().EnqueueAsync(job);
        }
        public static Task<IJob> EnqueueAsync(this IJobScheduler scheduler, Expression<Func<Task>> job)
        {
            return scheduler.BuildJob().EnqueueAsync(job);
        }
    }
}
