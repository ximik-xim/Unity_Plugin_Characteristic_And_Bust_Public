using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AbsGetCharacteristicData<CharacteristicData, TypeValue> : AbsGetCharacteristicValue<TypeValue> where CharacteristicData : AbsCharacteristicData<TypeValue>
{
    public AbsGetCharacteristicData(CharacteristicData getInfoCharacteristic)
    {
        _characteristicInfo = getInfoCharacteristic;
    }

    [SerializeField]
    private CharacteristicData _characteristicInfo;
    
    public override event Action OnUpdateValue
    {
        add
        {
            _characteristicInfo.OnUpdateValue += value;
        }
        remove
        {
            _characteristicInfo.OnUpdateValue -= value;
        }
    }
    
    public override TypeValue GetValue()
    {
        return _characteristicInfo.GetValue();
    }
}