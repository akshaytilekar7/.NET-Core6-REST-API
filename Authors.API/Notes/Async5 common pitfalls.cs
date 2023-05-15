/*

Additional Return Types and Avoiding Common Pitfalls
    

Additional Async Return Types
    -   Any type that has an accessible GetAwaiter() method
    -   Returned object must implement System.Runtime.CompilerServices.ICriticalNotifyCompletion
    -   Task and Task<T> are reference types
            -   Unwanted memory allocation in
            -   performance-critical paths Thanks to GetAwaiter(), a value type can be created instead
            - ValueTask<T>
    -   ValueTask<T>
        -   A struct that wraps a Task<T> and a result of type T

Additional return type is good or bad
    -   When the async method runs  asynchronously, it's bad for performance
    -   When the async method runs  synchronously it's good for performance

Legacy code, like a long-running algorithm, is computational-bound code
    -   This can be offloaded to a background thread
    -   using async await, Can run concurrently

Pitfall #1: Wrapping synchronous code with
    -   Task.Run()
        -   ASP.NET CORE IS NOT OPTIMIZED FOR Task.Run()
        -   Creates an unoptimized thread
        -   Causes overhead
        -   On the server decreases scalability
        -   It's intended for use on the client (e.g.: to keep the UI responsive)

Pitfall #2: Blocking Async code
    -   Task.Wait() and Task.Result() BLOCK THE CALLING THREAD
        -   Thread isn't returned to the thread pool
        -   Blocking async code hurts scalability
    -   instead of            :  await _repo.GetEmployees() 
        to make syncronus use :        _repo.GetEmployees().Result; // return actual result not task any more
        one more way -        :        _repo.GetEmployees().Wait();

ASP.NET Core doesn't have a synchronization context (the old ASP.NET does)
    -    Improves performance
    -    Makes it easier to write async code

ConfigureAwait(false)
    -   Avoids deadlocks in the old, full .NET framework
    -   Not necessary anymore in ASP.NET Core
    -   await MyMethodAsync().ConfigureAwait(false);
    -   await httpClient.GetAsync("UriToResource").ConfigureAwait(false);

Pitfall #3: Modifying Shared State
    -   Different threads might manipulate the same state at the same time
        -   Correctness cannot be guaranteed

Notable additional return types
    - GetAwaiter()
    - IAsyncEnumerable<T>
    Don't use Task.Run() on the server
        -   Hurts scalability
    Don't block async code
        -   Hurts scalability
    Don't modify shared state
        -   State can't be guaranteed



Rask.Run DOnt use at all
    Example
        private Task<int> GetBookPages_BadCode(Guid id)
        {
            return Task.Run(() =>
            {
                var pageCalculator = new Books.Legacy.ComplicatedPageCalculator();
                return pageCalculator.CalculateBookPages(id);
            });
        }

call from other method -  var amountOfPages = await GetBookPages_BadCode(id);
*/ 