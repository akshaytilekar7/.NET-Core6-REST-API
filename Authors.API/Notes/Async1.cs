/*

websurge.west-wind.com

Advantage of Asynchronous Code
    -   Performance is not the key benefit
    -   The key benefit of writing async server-side code is increased scalability

Scalability
    -   The capability of a system, network, or process to handle a growing
        amount of work, or its potential to be enlarged to accommodate that growth
    -   Horizontal - where we add mmore server and REST is stateless so dont have any effect
    -   Verticle 
        -   Adding Memory, cpu power
        -   Write API in such a way that resourse utilization is improved ie, ASYNC code
        -   async code improve verticle scalablity on server side

How 
    -   Sync Request
        -   handle request required thread from thread pool API call can be DB/NETWORK ie I/O call
        -   Thread will be block until IO call finished, so thread is not available to handle other request
        -   One thread is per request, which is handle full request
        -   for another API call we need 2nd thread, after some time API call has to wait until thread is available
        -   at this time client is experincing slow down and that 2 thread is just wating for data, they are not doing anything
    
    -   Async
        -   handle request required thread from thread pool API call can be DB/NETWORK ie I/O call
        -   this time its handle asyncronously instead of blocking thread during IO call, thread is return to thread pool
        -   when IO call finishes at that time it require thread, meantime threads which is return can process other request
        -   one request can handle by differnet thread and one thread can handle different request
        

IO bound work 
        -   will my code waiting for a task to be completed before continuing?
        -   File sys, DB operation and network calls    
        -   server side and client side
    
Computational bound work (CPU)
        -   will my code is performing expensive computation?
        -   expensive business algorithm
        -   client side
        -   Dont use async on server side for Computational bound work


in context of Request to API
Thread 
    -   basic unit of CPU utilization
    -   set of woek that has to be executed
    -   lightweight process
Mutithreading
    -   one single CPU / single core in multi core CPU - can execute multiple thread concurrently
    -   in API context - web server provide with thread pool, and distribute thread amongs request so they can execute concurrently
Concurrency 
    -   condition that exist when 2 thread are making progress
    -   in API context - web server can handle multiple request in the same time frame
    -   that does NOT mean they are running simultenioulsy (त्याच वेळी / existing or occurring at the same time/ exactly coincident.)
        thats where parallisim come into picture
Parallelism  
    -   2 thread are runnign simultenioulsy (त्याच वेळी)
    -   in PAI context - achive using server which has multicore processor (in that case 2 thread run simulteniously)
    -   this cant possible for one core

    
*/ 