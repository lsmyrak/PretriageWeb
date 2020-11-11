using FluentAssertions;
using Pretriage.Entitis.Model;
using Pretriage.Tests.DataTests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Pretriage.Tests
{
    public class ConfigServiceTests
    {
        //[Fact]
        
        //public void WhenGetConfigListViewModel_ShouldConfigListModelView()
        //{
        //    //Given
          
        //    //When

        //    //Then

        //}

        [Theory]

        [InlineData(2, 2,4)]
        [InlineData(3, 3,6)]
        [InlineData(4, 4,8)]
        public void WhenGetSuma_ShouldSum(int a, int b,int result)
        {
            // Ginven
            

            //When

            var method = new SimpleMethod();
            var sum = method.GetSum(a, b);
            //Then

            Assert.Equal(result, sum);                       
        }

        [Theory]
        [MemberData(nameof(GetListNumbers.GetListNumber), MemberType = typeof(GetListNumbers))]
        public void WhenGetMultiplication_ShouldMultiplication(IList<int> list,int expectedValue)
        {
            //When
            var method = new SimpleMethod();
            var actualValue = method.GetMultiplication(list);
            //Then   
            actualValue.Should().BeOfType(typeof(int));
            actualValue.Should().Be(expectedValue);
        }
    }
}
