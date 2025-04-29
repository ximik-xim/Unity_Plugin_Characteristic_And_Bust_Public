using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AbsCharacteristicData<TypeValue>
{
    public event Action OnUpdateValue;

    [SerializeField]
    private TypeValue _value;
    
    public TypeValue GetValue()
    {
        return _value;
    }
    
    public void SetValue(TypeValue value)
    {
        _value = value;
        OnUpdateValue?.Invoke();
    }
}
