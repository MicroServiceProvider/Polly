﻿using Polly.Caching;
using System;

namespace Polly
{
    public partial class Policy
    {
        /// <summary>
        /// <para>Builds a <see cref="Policy"/> that will function like a result cache for delegate executions returning a <typeparamref name="TResult"/>.</para>
        /// <para>Before executing a delegate, checks whether the <paramref name="cacheProvider"/> holds a value for the cache key specified by <see cref="M:Context.ExecutionKey"/>.
        /// If the <paramref name="cacheProvider"/> provides a value, returns that value and does not execute the governed delegate.  If the <paramref name="cacheProvider"/> does not provide a value, executes the governed delegate, stores the value with the <paramref name="cacheProvider"/>, then returns the value.
        /// </para>
        /// </summary>
        /// <returns>The policy instance.</returns>
        /// <exception cref="ArgumentNullException">cacheProvider</exception>
        public static CachePolicy<TResult> CacheAsync<TResult>(ICacheProviderAsync cacheProvider)
        {
            if (cacheProvider == null) throw new ArgumentNullException(nameof(cacheProvider));

            return CacheAsync<TResult>(cacheProvider.AsAsync<TResult>(), DefaultCacheKeyStrategy.Instance);
        }

        /// <summary>
        /// <para>Builds a <see cref="Policy"/> that will function like a result cache for delegate executions returning a <typeparamref name="TResult"/>.</para>
        /// <para>Before executing a delegate, checks whether the <paramref name="cacheProvider"/> holds a value for the cache key specified by <see cref="M:Context.ExecutionKey"/>.
        /// If the <paramref name="cacheProvider"/> provides a value, returns that value and does not execute the governed delegate.  If the <paramref name="cacheProvider"/> does not provide a value, executes the governed delegate, stores the value with the <paramref name="cacheProvider"/>, then returns the value.
        /// </para>
        /// </summary>
        /// <returns>The policy instance.</returns>
        /// <exception cref="ArgumentNullException">cacheProvider</exception>
        public static CachePolicy<TResult> CacheAsync<TResult>(ICacheProviderAsync<TResult> cacheProvider)
        {
            return CacheAsync<TResult>(cacheProvider, DefaultCacheKeyStrategy.Instance);
        }

        /// <summary>
        /// <para>Builds a <see cref="Policy" /> that will function like a result cache for delegate executions returning a <typeparamref name="TResult"/>.</para>
        /// <para>Before executing a delegate, checks whether the <paramref name="cacheProvider" /> holds a value for the cache key determined by applying the <paramref name="cacheKeyStrategy"/> to the execution <see cref="Context"/>.
        /// If the <paramref name="cacheProvider" /> provides a value, returns that value and does not execute the governed delegate.  If the <paramref name="cacheProvider" /> does not provide a value, executes the governed delegate, stores the value with the <paramref name="cacheProvider" />, then returns the value.
        /// </para>
        /// </summary>
        /// <param name="cacheProvider">The cache provider.</param>
        /// <param name="cacheKeyStrategy">The cache key strategy.</param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="ArgumentNullException">cacheKeyStrategy</exception>
        /// <exception cref="ArgumentNullException">cacheProvider</exception>
        public static CachePolicy<TResult> CacheAsync<TResult>(ICacheProviderAsync cacheProvider, ICacheKeyStrategy cacheKeyStrategy)
        {
            if (cacheProvider == null) throw new ArgumentNullException(nameof(cacheProvider));

            return CacheAsync<TResult>(cacheProvider.AsAsync<TResult>(), cacheKeyStrategy);
        }

        /// <summary>
        /// <para>Builds a <see cref="Policy" /> that will function like a result cache for delegate executions returning a <typeparamref name="TResult"/>.</para>
        /// <para>Before executing a delegate, checks whether the <paramref name="cacheProvider" /> holds a value for the cache key determined by applying the <paramref name="cacheKeyStrategy"/> to the execution <see cref="Context"/>.
        /// If the <paramref name="cacheProvider" /> provides a value, returns that value and does not execute the governed delegate.  If the <paramref name="cacheProvider" /> does not provide a value, executes the governed delegate, stores the value with the <paramref name="cacheProvider" />, then returns the value.
        /// </para>
        /// </summary>
        /// <param name="cacheProvider">The cache provider.</param>
        /// <param name="cacheKeyStrategy">The cache key strategy.</param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="ArgumentNullException">cacheKeyStrategy</exception>
        /// <exception cref="ArgumentNullException">cacheProvider</exception>
        public static CachePolicy<TResult> CacheAsync<TResult>(ICacheProviderAsync<TResult> cacheProvider, ICacheKeyStrategy cacheKeyStrategy)
        {
            if (cacheProvider == null) throw new ArgumentNullException(nameof(cacheProvider));
            if (cacheKeyStrategy == null) throw new ArgumentNullException(nameof(cacheKeyStrategy));

            return new CachePolicy<TResult>(cacheProvider, cacheKeyStrategy);
        }
    }
}