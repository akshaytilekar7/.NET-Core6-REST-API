/*

Unit Test Types (Test the only behaviours you coded yourself)
    unit test
        -   test method small piece of behaviour 
        -   fast and low complexity
    integration test
        -   test 2 component are work together, broder than unit test
        -   can test full request, but no compulsion
        -   medium complexity and slow as compared to unit test, less isolated
    functional test
        -   test full request and response cycle
        -   selium, postman
        -   high complexity and slow


    Unit Test
        -   good to test - logoc algo ,rule and behaviour
        -   bad to test -  Data access, UI and sys interaction
        -   unit test name - MethodToTest_Scenario_ExpectedBehaviour
    
    Framework
        -   MSTest
        -   NUnit
        -   Xunit

        MsTest and Nunit - they are not desinged or not coded with .net core in mind
        Xunit   -   built with .Net + cleaner code + improve test isolation
                -   in fact, asp.net core is itself is tested with Xunit

    inteline
        -   unit test should only contain one assert so we can easily come to know what exactly fails
            but practically we can assert same behavious in one unit test

Assert on Exception

        -   Assert("Akshay Tilekar", "Akshay TILEKAR", ignoreCase : true); // return true
        -   await Assert.ThrowAsync<EmployeeInvalidException>(
                async ()=> await employeeService.GetEmployees()
            );
            Note :- IF WE MISS AWAIT KEYWORD BEFORE ASSERT.THROW... TEST WILL PASS THOUGH FOR ASSERT IS FAILING 
                    because when Assert is Async, here its ThrowAsync, we need to await it
                    if we miss await keyword then resulting task is not return to XUnit, so we cant act on it and test pass

            ThrowsAny(async)<T>  =  take derived version into consideration
            Throws(async)<T>  =  exact match is required

Assert on Event and Type
        -   Assert.IsType<ExternalEmpoyee>(emp);
        -   Assert.IsAssignableFrom<Empoyee>(emp);

Asserting on private method
        -   test thr public method

[ApiController]
        -   attribute return bad request when modelState is invalid 


genral idead of unit teting
    -   only test method
    -   unit tes do not test following (Integration test tests this)
        -   Routing
        -   Filter
        -   DI
        -   Middleware
        -   Model Binding
        -   Model validation

   





                    

*/ 