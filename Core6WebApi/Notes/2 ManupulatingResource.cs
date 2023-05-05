/*

Method Safty and Idempotency
    -   method is consider safe when it doesnt change the resource representation
    -   method os idempotent when it can be called multiple times with same result
            
                Method Safty and Idempotency
    GET            YES              YES
    OPTIONS        YES              YES
    HEAD           YES              YES
    POST           NO               NO
    DELETE         NO               YES
    PUT            NO               YES
    PATCH          NO               NO
   
BINDING SOURCE ATTRIBUTE
    FromBody
    FromQuery
    FromHeader
    FromRoute

    FromForm
    FromService
    
    this works automaticaly beacuse, following rule are there 
        FromBody - inferred for complex object
        FroRoute - inferred for any parameter name matching parameter in route template
        FromQuery - inferred for any action parameter


PATCH - paritial updates
    -  allow sengind change set via JsonPatchDocument
    -  operations - ADD, REMOVE, REPLACE, COPY, MOVE, TEST 
    -  TEST - test value at target location value is equal to specified property
    -  syntax
            [
             { 
                op: replace,
                path: /baz, 
                value: boo 
             },
             { 
                op: add, 
                path: /hello, 
                value: [world] 
             },
             { 
                op: remove, 
                path: /foo 
             }
            ]
    -   controller method fun(int id, JsonPatchDocument<Employee> patchDocument)
        {
            var dtoFromDB = repo.GetById(id);
            patchDocument.ApplyTo(dtoFromDB);
        }
    
    -   when wen call from JS, ContentType : application/json-patch+json 
        application/json will also fine for .NET Core
    -   use newtonsoft json for jsonPatch coz Syste.Text.Json is not as advance 
    -   builder.Service.AddController(configure => {
        
        })
        .AddXmlDataContractSerilizeFromatter()
        .AddNewtonSoftJson(setupAction => {
            setupAction.SerilizeSettings.ContractResolver = new CamelCasePropertyNameContractResolver();
        });

        Note - now all sudden outout formatter is set to XML instead of JSON due to .AddNewton()...
             - to avoid this issue. add AddNewton 1st then add AddXmlData    -   
*/
