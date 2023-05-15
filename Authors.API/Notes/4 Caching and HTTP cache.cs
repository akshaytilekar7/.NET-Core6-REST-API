/*

Caching
    -   All about imroving performance (otherwise its useless)
    -   Goas is to elimate the need of send request in many cases and 
        to eliminate to send full response 

    -   elimate number of request 
        -   reduce network round trip
        -   expiration machenism

    -   eliminate to send full response 
        -   reduce network bandwidth
        -   validation mechanism
    -   Cache is separate component
        -   Accept request from consumer to API
        -   receive response from API and store them if they are deemed cacheable
        -   so cache - is middleman of request-response communcation

    -   3 Types of Cahce
        -   Client / browser cache
            -   live in client (browser / mobile)
            -   so they are private
        -   Gateway Cache
            -   server side 
            -   shared cahce
        -   Proxy (use by large comapies ex - ISP)
            -   lives on network 
            -   shared cache

    -   state is mentain to cache or not 
        -   Cache-Control:max-age=120 (sec)
        -   [ResponseCahce] Attribute
        -   only his does not cache anything , we need to some extra code
        -   Cache store 
            -   Response cache middleware
            -   [ResponseCahce(duration=120)]
                -   this will add new header name Cache-Control:public,max-age=120
            -   To Add cache store
                -   builder.Service.AddResponseCaching();
                -   add call to app.UseResposeCaching()  before app.useAuth() and Routing
                -   if we hit api within 120 sec we can see new header called Age : valueInSecDone
        Cache Profile
            -   to apply same rule fro different resource (api method)
            -   builder.Service.AddController(config => {
                    config.CacheProfile.Add("240Cache", new () { Duration = 240 });
                });
            -   add this new policy to contoller leval 
            -   [ResponseCahce(CacheProfileName = "240Cache")] on controller

        Expiration model
            -   tells how long response is considered as fresh
            -   Expire header is also there, but haveing some issues
                -   Expires : Thu, 12 Huly 2022 11.00.55 GMT
                -   clocks must be sync and offers little more control 
                -   prefer 
Http Cache
    -   Cache Types
    -   Expiration and validation model 
    -   Cache-Control header
       
Response caching middleware


    Validation
        -   validation is require to check fresness of the data
        -    
 
*/
