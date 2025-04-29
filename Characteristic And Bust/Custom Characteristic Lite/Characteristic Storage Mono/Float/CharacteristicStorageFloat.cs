using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Хранит в себе список всех характеристик по ключу
/// </summary>
public class CharacteristicStorageFloat : MonoBehaviour
{
    public  event Action OnInit;
    private bool _init = false;
    public bool Init => _init;
    
    [SerializeField] 
    private List<AbsGetDataFloat> _listGetInfoCharacteristic = new List<AbsGetDataFloat>();
    
    private List<AbsGetDataFloat> _bufferInitCharacteristic = new List<AbsGetDataFloat>();

    private Dictionary<string, GetCharacteristicDataFloat> _dataCharacteristic = new Dictionary<string, GetCharacteristicDataFloat>();
    
#if UNITY_EDITOR
    [SerializeField] 
    private bool _visibleData;

    [SerializeField] 
    private List<AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>> _listVisible = new List<AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>>();
#endif
    
    private void Awake()
    {
        foreach (var VARIABLE in _listGetInfoCharacteristic)
        {
            if (VARIABLE.Init == false)
            {
                _bufferInitCharacteristic.Add(VARIABLE);
                VARIABLE.OnInit += OnCheckInit;
                VARIABLE.StartGetData();
            }
        }
        
        if (_bufferInitCharacteristic.Count < 0)
        {
            InsertData();
        }
    }

    private void OnCheckInit()
    {
        int targetCount = _bufferInitCharacteristic.Count;
        for (int i = 0; i < targetCount; i++)
        {
            if (_bufferInitCharacteristic[i].Init == true)
            {
                _bufferInitCharacteristic[i].OnInit -= OnCheckInit;
                _bufferInitCharacteristic.RemoveAt(i);
                i--;
                targetCount--;
            }
        }
        
        if (_bufferInitCharacteristic.Count > 0)
        {
            return;
        }

        InsertData();
    }

    private void InsertData()
    {
        foreach (var VARIABLE in _listGetInfoCharacteristic)
        {
            foreach (var VARIABLE2 in VARIABLE.GetCharacteristicsData())
            {
                _dataCharacteristic.Add(VARIABLE2.Key.GetKey(), VARIABLE2.Data);
                
#if UNITY_EDITOR
                if (_visibleData == true)
                {
                    AddKeyVisible(VARIABLE2.Key,VARIABLE2.Data);
                }
#endif
                
            }
        }
        
        _init = true;
        OnInit?.Invoke();
    }

    public GetCharacteristicDataFloat GetCharacteristicData(KeyCharacteristicFloat key)
    {
        return _dataCharacteristic[key.GetKey()];
    }
    
    
#if UNITY_EDITOR
    private AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat> IsKeyVisible(KeyCharacteristicFloat key)
    {
        foreach (var VARIABLE in _listVisible)
        {
            if (VARIABLE.Key == key)
            {
                return VARIABLE;
            }     
        }

        return null;
    }

    private void AddKeyVisible(KeyCharacteristicFloat key, GetCharacteristicDataFloat characteristic)
    {
        var data = IsKeyVisible(key);
        if (data == null)
        {
            var newData = new AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>(key,characteristic);
            
            _listVisible.Add(newData);
        }
        
        
    }

    private void RemoveKeyVisible(KeyCharacteristicFloat key)
    {
        var data = IsKeyVisible(key);
        if (data != null)
        {
            _listVisible.Remove(data);
        }
    }
#endif
}
