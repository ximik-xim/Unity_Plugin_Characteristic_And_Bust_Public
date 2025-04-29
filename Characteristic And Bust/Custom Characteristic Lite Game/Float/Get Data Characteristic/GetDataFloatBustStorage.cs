using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// При этой реализации, буду брать данные из логики буста
/// </summary>
public class GetDataFloatBustStorage : AbsGetDataFloat
{
    public override event Action OnInit;
    private bool _init = false;
    public override bool Init => _init;

    [SerializeField]
    private List<GetDataSO_KeyCharacteristicFloat> _keyCharacteristic;

    [SerializeField] 
    private StorageBustFloat _bustCharacteristic;

    private List<AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>> _data = new List<AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>>();

    public override void StartGetData()
    {
        if (_bustCharacteristic.Init == false)
        {
            _bustCharacteristic.OnInit += OnInitBustStorage;
            return;
        }

        InitBustStorage();
    }
    
    private void OnInitBustStorage()
    {
        _bustCharacteristic.OnInit -= OnInitBustStorage;
        InitBustStorage();
    }
    
    private void InitBustStorage()
    {
        _data.Clear();
        
        foreach (var VARIABLE in _keyCharacteristic)
        {
            _data.Add(new AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>(VARIABLE.GetData(),_bustCharacteristic.GetCharacteristicData(VARIABLE.GetData())));
        }

        _init = true;
        OnInit?.Invoke();

    }

    public override List<AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>> GetCharacteristicsData()
    {
        return _data;
    }
    
}
