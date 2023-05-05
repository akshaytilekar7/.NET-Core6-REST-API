/*
 ASP.NET Core 6 Web API Deep Dive

MVC
    -   loose coupling and separation of concern
    -   its not full application architecture, used in user interface as part of defination
    -   but how API can mapto MVC -> API is also user interface 
    -   In MVC, controller is used to as to create RESTful API
    -   using MVC doesnt mean that you are using REST API, once you implement REST CONSTRAINT then MVC can be REST


REST Architecture (invented by Roy Thomas Fielding)
    -   in general we thinnk that REST is all about HTTP + building API and returnign JSON from http request, but this is WEB API not REST
    -   REST is much broder than that, its REPRESENTATIONAL STATE TRANSFER
    -   REST is not STANDARD its architectureal style
    -   REST is not STANDARD in its own
    -   STANDARD are use to implement REST arc style
    -   REST is principle and protocol agnostic - JSON, HTTP is not part of rest (threotically)
    
    -   REST is style intended to evoke how well designed application behaves
    -   Example, reading online newspaper
        -   browser (HTTP client) pointed to URI
        -   browser send HTTP request to URI, then server send HTTP response (HTML CSS) back to browser and shows web page 
        -   ie at last browser which is HTTP client, has change state and same goes on
        -   in shaore REST -> CLIENT CHANGES STATE depending on representation of the resource you are accessing
    
REST
    -   6 contraint (5 obligatory constraint +  1 optional constraint)
    -   Contraint - is a design decision that have +ve and -ve impact
        -   1. Uniform Interface 
            -   API and consumer share one single technical interface : URI, http method and http media types (payload req ,res , body , header)
            -   it has 4 sub constraint
                a.  identification of resource 
                b.  manupulation of resource thr representation (representation + media type) must be sufficient to edit and delte rewource if they have permissions
                c.  self descriptive message 
                d.  HETEOAS - hypermedia as the engine of app state
                        -   link are nothing but hypertext and hypermedia is genralization of hypertext, means it adds other types like music, image
                        -   Hypermedia Drives how to consume and use the API
                        -   allow self documentation - how can delte,where to find it and many more
        -   2. Client Server 
                - client and server can evolve separatly ie, client can be psotman browser console .. develop api without knowing Postman , comsole browser 
        -   3. Statelessness 
                - state is contain within the request
        -   4. Layered System 
                - REST restrict knowledge to single layer which is outer facing one 
        -   5. Cacheble 
                - each resonse must explicity state if its can be cached or not
                - we have cache control header and other cache related header like Etag , last modifed date, expires
        -   6. Code on demand (optional)
                - server can extend client functionality (generally in web) ie send JS code to server 
                        
        -   implement all constant then API can be said REST ow not
        

REST Richerdson Maturity Model
    -   level 0 to 
    -   leval 0 and 1 are west of time
    -   leval 2 : correct HTTP verb and correct status code are used
    -   leval 3 : Hypermidia if we implement it -> which leads to REST ful api
    
Resource Naming convention
    -   URI should be NOUN (things) not an action
    -   api/getauthors -> api/authors
    -   api/authors/{authorId}
    -   api/employess
    -   api/employess/{employeeId}
    -   Represent Hirarchy when naming resources : api/authors/{authorId}/courses and api/authors/{authorId}/courses/{courseId}
    
Status code
    -   100 informational - 
    -   200 Sucess 
            -   200 ok
            -   201 created
            -   204 not content (use for delete) not return anything
    -   300 Redirection
    -   400 client mistake
            -   400 bad request 
            -   401 unauthorized
            -   403 forbidden
            -   404 Not found - requested resource does not exist
            -   405 not allowed  post for get 
            -   406 not acceptable , related to media type requested json where xml only supported
            -   409 conflict
            -   422 validation error
    -   500 - internal server error


    Errors and Fault
    Errors 
        -   400 status code
        -   not related to api availbility
    Fault
        -   500 status code, api failes to return response to VALID request
        -   its related to api availbility
        
Handling Faults
        -   when we get exception it doirectly shoen up in web with stack trace which is not good sue to security reason
        -   We can use Exception Handler, 
                app.UseExceptionHandler(appBuilder =>
                    appBuilder.Run(aynch context => {
                    context.Resonse.StatusCode  = 500;
                    context.Resonse.WriteAsync("fail")
                    })
                );

Payload Content Negotioan
    -   process of selecting best representation for response when there are multiple representation available
    -   Media Types are passed via 'accept header' of request and value can be application/json or application/xml
        - Output Accept Header
        - input Content Type heder

HEAD verb
    -   same as GET but API shoudlent return response body, can be uused to obtain info on resource
    -   No Body but have headers
Routing
    -   matches a requrest URI to an action of controller
    -   once we send HTTP req to MVC, framework parses URI to action of controller. sont ny enpoint mapping  app.MapController()
 
 */ 