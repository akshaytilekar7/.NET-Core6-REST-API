using Xunit;

namespace Core6WebApi.Tests
{
    public class StronglyTypedEmployeeServiceTestData : TheoryData<int, bool>
    {
        public StronglyTypedEmployeeServiceTestData()
        {
            Add(100, true);
            Add(200, false);
        }
    }
}
