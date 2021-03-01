using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    class MyRangeAttribute : MyValidationAttribute
    {
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public int minValue { get; set; }
        public int maxValue { get; set; }
        public override bool IsValid(object obj)
        {
            var value = Convert.ToInt32(obj);

            if (value >= minValue && value <= maxValue)
            {
                return true;
            }
            return false;

        }
    }
}
