using System;
using System.Collections.Generic;
using System.Text;

namespace Pretriage
{
   public class SimpleMethod
    {
        public int GetSum(int a, int b)
        {
            return (a + b);
        }

        public int GetMultiplication(IList<int> IntList)
        {
            int sum = 1;

            foreach (int number in IntList)
            {
                sum *= number;
            }
            return sum;
        }

        public int GetCountObject(IList<int> objects)
        {
            return objects.Count;
        }
       
    }
}
