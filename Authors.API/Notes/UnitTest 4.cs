/*

Unit test should be isolated from component of system such as DB file and repo
    ensuring this we can sure that test is fail due our business logic not due to external factors
    pass and fail its cause of code under test

    
    Test Isolation 
        Test Doubles
            -   Fake    :   working implmentation which not suitable for production, in memory db
            -   Dummy   :   test doubles that never access or used
            -   Stub    :   pass fake data to sys under test
            -   Spy     :   
            -   Mock    :   test doubles that implment expected behaviour
                        :   Mock is for Virtual method


    Controller unit test
        -   thin or fat contoller method 
        -   deal with - ModelState HttpContext HtppClient  

    in test project cmd promt
        -   dotnet test : return 0 success or 1 for fail

Test Runner (xunit.runner.visualstudio)
    -   program (3rd party plugin) responsible for lookign one/more assemblies 
        with tests in them
        and activating the test frameworks that find those assemblies
    -   test frameworks : code that has detailed knowledge of how to discover and run unit tests

    
Running test in parallisim
    -   parallisim in test runner
        -   can support running differnet test assemblies in parallel
    -   parallisim in test framework
        -   running test in  within a single assembly in parallel
*/ 