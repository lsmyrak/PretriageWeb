using System;
using System.Collections.Generic;
using System.Text;

namespace Pretriage.Tests.DataTests
{
  public static class GetListNumbers
    {
        public static IList<object[]> GetListNumber()
        {
            return new List<object[]> 
            {
                new object[]
                { new List<int>
                    { 1,2,3,4,5,6,1,2,3},
                    4320
                },
                new object[]
                { new List<int>
                    { 2,2,3,4,5,6,1,2,3},
                    8640
                },

            };
        }
    }
}
