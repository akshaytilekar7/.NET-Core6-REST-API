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
*/ 