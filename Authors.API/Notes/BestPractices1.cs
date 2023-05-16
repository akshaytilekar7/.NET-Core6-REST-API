/*

REST 
    -   REpresentation State Transfer
    -   REST is all about STATE not behaviour
    -   architecture style for building distributed system based on HYPERMEDIA and designed around RESOURCE

Hypermedia
    -   Hypermedia, an extension of the term hypertext, is a nonlinear medium
        of information [data] that includes graphics, audio, video, plain text and hyperlinks."

    -   The information is non-linear because it may contain any number of hyperlinks 
        that may be used to navigate the information in any sequence.

Resources
    -   Any kind of object, data, or service that can be accessed by a client
    -   A resource has an identifier, which is a URI that uniquely identifies that resource
    -   Any information that can be named can be a resource: a document or image, a temporal service, a collection of other resources, a non-virtual
        object (example: a person), and so on
    -   REST uses a resource identifier (URI) to identify the particular resource involved in an interaction between components."
    -   REST components communicate by transferring a representation of a resource...

Representation
    -   REST components perform actions on a resource by using a representation to capture the current or intended state of that resource
        and transferring that representation between components
    -   A representation is a sequence of bytes, plus representation metadata to describe those bytes

Designing URIs for Resources
    -   Use Nouns for URIs
        -   ok: /customer
        -   Avoid: /addcustomer
    -   Use Plurals not Single	
        -   OK: /authors
        -   Avoid: /book
    -   Append an identifier to specify an individual resource
        -   OK: /authors/1

Follow the Principle of Least Astonishment
    -   Avoid surprising consumers of your API
    -   Keep it simple
    -   Keep it consistent

Avoid Exposing Internal Details
    -   Database table scemna
    -   Persistent document format
    -   Business Doamin entites


HTTP (Hypertext transfer protocol)
    -   Idepotence and Safty are major attribute that separate HTTP method
    -   Idepotence
        -  Always SAME result when request multiple time (GET/PUT/DELETE/PATCH/HEAD)
        -   POST is NOT
    -   Method Safty  (GET, HEAD)
        -   GET and HEAD method should not modified a data, only retrivel

Status code 
    -   first digit signifies class of response
    -   100: informational
    -   200: Successful
    -   300: Redirection
    -   400: Client Error
    -   500: Server Error

GET
    -   200 OK
    -   301 Moved permanantly
    -   302 Found
    -   304 Not Modified
    -   404 Not Found
    -   429 Too may request

POST
    -   200 OK
    -   201 Created
    -   202 Accepted
    -   204 No Content
    -   303 See other
    -   400 Bad request
    -   429 Too many request

PUT/PATCH
    -   200 OK
    -   201 Created
    -   202 Accepted
    -   204 No Content
    -   400 Bad request
    -   404 Not Found
    -   429 Too many request

POST
    -   200 OK
    -   202 Accepted
    -   204 No Content
    -   404 Not found
    -   429 Too many request

Security/Permission
    -   401 Unauthorized
    -   403 Forbidden
    -   404 Not Content

Error and Unhandle Exception
    -   500 Insternal server error

Always Avoid 2xx for error response

Response Type
    -   Specific Type, Customer, List<Employee>
        -   primitive types
        -   complex types 
        -   collection : List and Dictionary
        -   IEnumberable, IAsyncEnumberable
        -   PROS
            -   Swagger supprt without attribute
            -   Simple
        -   Cons
            -   Cant directly retuen other responce code and types
    -   IActionResult
        -   provide with Helper method
            -   Ok()
            -   NotFound()
            -   BadRequrst()
        -   PROS
            -   Work with built in helper methid
            -   consistent return type for method
        -   CONS
            -   Not Strongly Types
            -   Require attribute infomation to swagger response
            -   Atrribute on controller method
                [ProductResponseType(StatusCodes.Status201Created, Type = typeof(AuthoreDto))]
    -   IActionResult<T>
            -   Can return specific types
            -   provide with Helper method
            -   PROS
                -   Strongly Typed
                -   can return object as well as helper
                -   can return any statsu code
                -   No need of [ProductResponseType] attribute ?? Need to check

Minimal API Response
    -   IResult
        -   Results.Json
        -   Results.Ok
        -   Results.Text
        -   Results.Bytes...
        -   Results.NotContent
        -   Results.BadRequest
        -   Results.Problem
    -   Object
    -   Raw data (string / Json)


*/ 