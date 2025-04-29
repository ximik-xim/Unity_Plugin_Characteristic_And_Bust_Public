using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCalculatingBustFloat : AbsCalculatingBustFloat
{
    public override float StartCalculatingBust(float baseValue, List<AbsKeyData<string, BustDataFloat>> data)
    {
        foreach (var VARIABLE in data)
        {
            BustDataFloat dataBust = VARIABLE.Data;

            if (dataBust.TypeAction == TypeActionBustFloat.Summation)
            {
                baseValue += dataBust.Value;
            }

            if (dataBust.TypeAction == TypeActionBustFloat.Subtraction)
            {
                baseValue -= dataBust.Value;
            }
        }

        return baseValue;
    }
}
