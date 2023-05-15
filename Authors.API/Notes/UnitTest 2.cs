/*

Setting up Test and sharing test context
    -   constructor and dispose pattern
        -   call after each unit test
    -   class fixture
        -   context is clean up after running all test in one class
        -   use when creationa and clean up is expensive
    -   collection fixture
        -   same as class fixture but singe test context shared among test in several classes

    class fixture
        -   in a new class file
            public class EmployeeFixture
            {
                public Repo EmpRepo {get}
                public Service EmpService {get}

                ctor()
                    { 
                        EmpRepo = new();
                        EmpService = new();
                    }

                public void Dispose() 
                {
                }
            }


        to use fixture

        public class EmpoyeeTest : EmployeeFixture
        {
            EmployeeFixture _fixture;

            ctor(EmployeeFixture fixture)
            {
                _fixture = fixture;            
            }

            public void test()
            {
                // use _fixture
            }
        }
        

    





                    

*/ 