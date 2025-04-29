using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BustDataFloat 
{
    public BustDataFloat()
    {
        
    }

    public BustDataFloat(TypeActionBustFloat typeAction, float value)
    {
        _typeAction = typeAction;
        _value = value;
    }
    
    [SerializeField]
    private TypeActionBustFloat _typeAction;

    [SerializeField]
    private float _value;

    public TypeActionBustFloat TypeAction => _typeAction;

    public float Value => _value;
}

public enum TypeActionBustFloat
{
    Summation,
    Subtraction
}