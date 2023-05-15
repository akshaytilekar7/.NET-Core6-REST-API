/*

Async Streaming
    -   result return in small block instead on once  
    -   IAsyncEnumerable<T> enables straming
    -   transmitting or receivng data over network as a steady, continuous flow instead of all at once
    -   useful for vidio/audio but also for large set of data ex - json can also return like this

How this work
    -   Iteration over colletion is enable by 
        System.Collection.IEnumberable
        -   which return System.Collection.IEnumerator
    -   IEnumerator proved functionalty like current, MoveNext() 
        -   can create custom also.

    -   compile generate code for Foreat iteration
 
        IEnumerator<int> enumerator = collection.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var item = enumerator.Current;
            Console.WriteLine(item.ToString());
        }

    -   Iterator methods are methods that create a source for iteration ie, create something that can be iterated over
    -   Ex, method yield returns every even element from source list
       
        public static IEnumerable<T> ReturnEvenElements<T>(this IEnumerable<T> source)
        {
            int index = 0;
            foreach (T item in source)
            {
                if (index % 2 == 0)
                    yield return item;
            index++;
            }
        }
    -   await can be used inside foreach statement
    -   so we have iterators and they also support async operators, so combining ASYNC ITERATORS
        other word, YIELD keyword with async and await

    -   foreach loop synchronus (wihout await keyword)
        iteration
                 operation
                          iteration
                                   operation                        
        - iteration run then operation, iteration run then operation and so on 

    -  foreach loop Asynchronus (With await keyword)
       -    which allow to start next iteration sooner beacuse thread is being freed 
       -    2nd iteration can start before prev operation has fully completed
        -   Note - thing we are iterating over which is colletion in our case, is still in sync one by one
        iteration
                 operation
                      iteration
                               operation                        
    - iteration run then operation, iteration run then operation and so on 
    -   if we make collection also async then it like below
         iteration
                  operation
            iteration
                     operation   
    -   which improve scalablity and supprt asyn straming
    -   under the hood, compilter transform async iterators into state machines
    
Supporting Streaming with IAsyncEnumerable<T>
    IAsyncEnumerable<T>
        - Provides the ability to iterate over a set of values asynchronously
    Since ASP.NET Core 6 System.Text.Json supports streaming, which, combined with
    IAsyncEnumerable<T>, can result in objects being streamed to the consumer
    

*/ 