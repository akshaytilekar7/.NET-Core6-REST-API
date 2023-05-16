/*

MVC provide best features
    -   [ApiController] : auto return bad request and Model validation
    -   Attribute routing
    -   Model validation
    -   Minimize controller size
    -   filter and appliy polices
    -   async and await
    -   reponse cache
    -   response compression : app.UseResponseCompression();
    -   content negotiotion 
    -   default exception handler
    -   ActionResult<T>
    -   controllerBase class

Minimize controller size
    -   replace duplication logic with filter
    -   avoid busniess logic inside controller
    -   avoid data access logic
    -   avoid try catch

    -   Large controller leads to Lack Cohesion, more dependacnies nad coupling
    -   production error handler [Route("/error")]
    

Filters and middleware
    -   repetitive code can moves to filter
    -   if it doesnt need MVC details, can used middleware
    -   Filter/Middlware == Consistent Policy
    -   Model validation is enable by [ApiController]


app.UseResponseCompression()
    -   services.AddResponseCompression(); (ConfigureServices method)
        app.UseResponseCompression(); (Configure Method)
    -   middleware is only working for Content-Type which presents MIME Types in HttpResponse 
        instead of writing a file stream to HttpResponse likes you are doing.
    -   which by default uses GZIP compression 
        -   which is used for the file compression 
        -   decompression for faster network transfer.
    -   Using GZIP Compression is the best approach to reduce the response size 
        and provide better speed for transferring the files over the network.

Mediator Pattern
    -   loose coupling by keeping object from reffering to each other complexity 
        and it lets you very their interaction independantly
    -   Defines specific interface
        IRequest<TResponse>
        IRequestHandler<TRequest,TResponse>
        -   Scan for types which implent this interface
        -   nO COMPILE TIME DEPENDANCIES
    -   calling _mediator.Send(someRequest)
        find handler for typeof(someRequest)
        invoke the handler
        return the TResponse result
        
A typical Api controller action
    -   Validate the incoming API model
    -   Map the incoming model to the business model
    -   Use an abstraction to persist the model (and do other work here)
    -   Map the business model back to the API model
    -   Return an appropriate HTTP result

bit of refactring 1.0
    X   Validate the incoming API model (as [ApiController] do this )
    X   Map the incoming model to the business model                        Move to service
    X   Use an abstraction to persist the model (and do other work here)    Move to service
    X   Map the business model back to the API model                        Move to service
    X   Return an appropriate HTTP result                                   Move to service
    
    
bit of refactring 2.0
    -   Call service; pass newSomething ; get back result DTO
    -   Return an appropriate HTTP result

bit of refactring 3.0
    -   (Call service; pass newSomething ; get back resultDTO).AsActionResult (); // using Ardalis.Result

bit of refactring 4.0
    -   Call _mediator.Send(newSomething); get back result DTO
    -   Return an appropriate HTTP result

REPR
    Request Response

Minimla API 

    Example normal API
        [HttpPost("/payments")]    
        public IActionResult Post( [FromBody] PaymentRequest? request)
        {
            // add payment
        }
    Minimal Api
        app.MapPost("/payments", PaymentRequest paymentRequest ) => {
        // add payment
        });

2nd example
    [HttpDelete ("/authors/{id}")]
    public ActionResult Delete(int id)
    {
        // perform delete 
        return NoContent();
    }

    app.MapDelete("/authors/{id}", (int id) =>
    {
        // perform delete
        return Results.NoContent
    });

For minimal api to achieve separation of concern 2 ways (MinimalApi folder inside project)
    1.  Cinsider using MinimalApi.Endpoint
    2.  using ExtensionMentd on app


*/ 