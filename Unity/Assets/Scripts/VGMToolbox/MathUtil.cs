using System;

namespace VGMToolbox.util
{
    public class MathUtil
    {
        // public static string Evaluate(string expression)
        // {
        //     object results = null;
        //     string outputValue;

        //     try
        //     {
        //         results = JSUtil.Util.Eval(expression);
        //         outputValue = Convert.ToString((long)Convert.ToUInt64(results), 10);
        //     }
        //     catch (Exception ex)
        //     {
        //         outputValue = null;
        //     }

        //     return outputValue;
        // }

        public static long RoundUpToByteAlignment(long valueToRound, long byteAlignment)
        {
            long roundedValue = -1;

            roundedValue = (valueToRound + byteAlignment - 1) / byteAlignment * byteAlignment;

            return roundedValue;
        }

        public static ulong RoundUpToByteAlignment(ulong valueToRound, ulong byteAlignment)
        {
            ulong roundedValue;

            roundedValue = (valueToRound + byteAlignment - 1) / byteAlignment * byteAlignment;

            return roundedValue;
        }
    }

}