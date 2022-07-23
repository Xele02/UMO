using System;
using System.Collections.Generic;
using System.Text;

namespace VGMToolbox.util
{
    public class CalculatingOffsetDescription : OffsetDescription
    {
        public const string OFFSET_VARIABLE_STRING = "$V";
        
        public string CalculationString { set; get; }
    }
}