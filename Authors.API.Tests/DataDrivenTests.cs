using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Authors.API.Tests
{
    public class DataDrivenEmployeeServiceTests
    {
        [Theory]
        [InlineData("ABCD")]
        [InlineData("EFGH")]
        public void Simple_InlineData_Test(string name)
        {
            // Arrange 
            // Act
            // Assert
            Assert.Equal(4, name.Length);
        }

        public static IEnumerable<object[]> ExampleTestData_WithProperty
        {
            get
            {
                return new List<object[]>
                    {
                            new object[] { 100, true },
                            new object[] { 200, false }
                    };
            }
        }

        public static TheoryData<int, bool> StronglyTypedExampleTestData_WithProperty
        {
            get
            {
                return new TheoryData<int, bool>() {
                        { 100, true },
                        { 200, false }
                    };
            }
        }

        public static IEnumerable<object[]> ExampleTestData_WithMethod(int key)
        {
            var testData = new List<object[]>
                {
                        new object[] { 100, true },
                        new object[] { 50, false }
                };

            return testData.Take(key);
        }

        [Theory]
        //[ClassData(typeof(EmployeeServiceTestData))]
        [MemberData(nameof(DataDrivenEmployeeServiceTests.ExampleTestData_WithMethod), 1, MemberType = typeof(DataDrivenEmployeeServiceTests))]
        [MemberData(nameof(ExampleTestData_WithMethod), 50)]
        [ClassData(typeof(StronglyTypedEmployeeServiceTestData))]
        [MemberData(nameof(ExampleTestData_WithProperty))]
        [MemberData(nameof(StronglyTypedExampleTestData_WithProperty))]
        public async Task Test_EqualTo100_Sucess(int raiseGiven, bool expectedValueForMinimumRaiseGiven)
        {
            // Arrange  
            var passToService = raiseGiven;

            // Act
            var result = raiseGiven == 100;
            await Task.Run(() => System.Threading.Thread.Sleep(15));

            // Assert
            Assert.Equal(expectedValueForMinimumRaiseGiven, result);
        }

    }
}
