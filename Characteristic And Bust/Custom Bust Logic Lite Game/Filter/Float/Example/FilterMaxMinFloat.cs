using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterMaxMinFloat : AbsFilterDataFloat
{
    [SerializeField] 
    private float _min = 0;
    
    [SerializeField] 
    private float _max = 9999;
    
    public override float StartFilter(float data)
    {
        if (data < _min) 
        {
            data = _min;
        }

        if (data > _max)
        {
            data = _max;
        }

        return data;
    }
}
