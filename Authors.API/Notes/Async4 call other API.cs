/*

Dealing with Asynchronous Service Integrations and Supporting Cancellation
    -   Integrating with an external service
    -   Dealing with multiple service calls
        - Asynchronously
        - Parallel
    -   Supporting task cancellation
    -   Gracefully handling exceptions
    

Maion things we need to do is: call api
      
    -   builder.Services.AddHttpClient();
    -   using _httpClientFactory from DO make calls
    -   course on it - using HttpClinet to consume APIs in .net

    -   Asynchronously integrating with an external service
    -   Processing multiple service calls asynchronously, one by one
    -   Processing multiple service calls asynchronously, after waiting for all of them to complete


    -   public async Task<IEnumerable<Models.External.AuthorCoverDto>> GetAuthorCoversProcessAfterWaitForAllAsync(int bookId)
        -   Used when we we have to do with something with all 5 api call
        -   so here we complted 5 api call then reverse resulkt list
        -   likewise we can use Task.WhenAll() things
    
Parallel Processing Vs. Asynchronous Processing
    -   Using async await all the way through
            - Threads potentially get freed up
            - Scalability is improved

    -   Parrallism : At least two threads are executing simultaneously
        -   Example Parallel.ForEach(bookCoverUrls, bookCoverUrl => httpClient.GetAsync(bookCoverUrl));
            -   this code is not asynchorous (it is synchrouns) sue to this
            -   Threads are blocked
            -   Negative impact on performance due to thread exhaustion
            -   Code like this should not be used on a server

    -   We can use wait and waitAll
        
            var bookCoverTasks = new List<Task<HttpResponseMessage>>();
            foreach (var bookCoverUrl in bookCoverUrls)
            {
                bookCoverTasks.Add(httpClient.GetAsync(bookCoverUrl));
            };
            Task.WaitAll(bookCoverTasks.ToArray());
        
            -   wait and waitAll will blocked the current thread
            -   Negative impact on performance due to thread exhaustion
            -   Code like this should not be used on a server

    -   ao ALWAYS USE ASYNC AWAIT FOR BETTER PERFORMANCE and SCALABLITY

CancellationTokenSource
    -   Frees IO bound work - use in API leval
    -   Frees up CPU work (computation logic) (from client side when task is used in api method which contain computation logic)
    -   An object which manages cancellation tokens and sends cancellation notifications to the individual cancellation tokens
    -   Supporting cancellation when the consumer navigates away
    -   Listening to multiple cancellation tokens

Cancellation token
    A lightweight value type passed to one or more listeners, typically as a method parameter

To conclude
    Execute multiple tasks asynchronously, not in parallel
    - async await
    - await WhenAll(…), await WhenAny(…)
    
    CancellationTokenSource and cancellation tokens
    - Tokens that are action parameters will receive a notification when the consumer navigates away

for more detail read code comment from GetAuthorCoversProcessOneByOneAsync ans respective controller




*/ 