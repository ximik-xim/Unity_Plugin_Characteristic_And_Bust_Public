using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Хранилеще с переменными в которых учтены бусты
/// Отвечает за всю логику бустов
/// </summary>
public class StorageBustFloat : MonoBehaviour
{
    public  event Action OnInit;
    private bool _init = false;
    public bool Init => _init;

    [SerializeField] 
    private ParametersBustData _defatulParametrs;
    
    [SerializeField] 
    private List<AbsGetDataFloat> _listGetInfoCharacteristic = new List<AbsGetDataFloat>();
    
    private List<AbsGetDataFloat> _bufferInitCharacteristic = new List<AbsGetDataFloat>();


    private Dictionary<string, StorageBustLogicFloat> _bustCharacteristicData = new Dictionary<string, StorageBustLogicFloat>();
#if UNITY_EDITOR
    [SerializeField] 
    private bool _visibleData;

    [SerializeField] 
    private List<AbsKeyData<KeyCharacteristicFloat, StorageBustLogicFloat>> _listVisibleBustCharacteristic = new List<AbsKeyData<KeyCharacteristicFloat, StorageBustLogicFloat>>();
#endif
    
    /// <summary>
    /// Список исключений. Если какому то ключу нужны не дефотные параметры, а какие нибудь особенные
    /// </summary>
    [SerializeField]
    private List<AbsKeyData<GetDataSO_KeyCharacteristicFloat, ParametersBustData>> _exceptionParametrsBust = new List<AbsKeyData<GetDataSO_KeyCharacteristicFloat, ParametersBustData>>();
    private Dictionary<string, ParametersBustData> _exceptionData = new Dictionary<string, ParametersBustData>();
    
    private void Awake()
    {
        bool complited = false;
        foreach (var VARIABLE in _listGetInfoCharacteristic)
        {
            
            if (VARIABLE.Init == false)
            {
                _bufferInitCharacteristic.Add(VARIABLE);
                VARIABLE.OnInit += OnCheckInit;
            }
        }

        OnCheckInit();
    }

    private void OnCheckInit()
    {
        int targetCount = _bufferInitCharacteristic.Count;
        for (int i = 0; i < targetCount; i++)
        {
            if (_bufferInitCharacteristic[i].Init == true)
            {
                _bufferInitCharacteristic.RemoveAt(i);
                i--;
                targetCount--;
            }
        }
        
        if (_bufferInitCharacteristic.Count > 0)
        {
            return;
        }

        InsertDataExceptionData();
        
    }
    
    private void InsertDataExceptionData()
    {
        foreach (var VARIABLE in _exceptionParametrsBust)
        {
            _exceptionData.Add(VARIABLE.Key.GetData().GetKey(), VARIABLE.Data);
        }
        
        InsertDataBustCharacteristicData();
    }

    private void InsertDataBustCharacteristicData()
    {
        foreach (var VARIABLE in _listGetInfoCharacteristic)
        {
            foreach (var VARIABLE2 in VARIABLE.GetCharacteristicsData())
            {
                StorageBustLogicFloat data = null;
                
                if (_exceptionData.ContainsKey(VARIABLE2.Key.GetKey()) == true)
                {
                    data = new StorageBustLogicFloat(VARIABLE2.Data, _exceptionData[VARIABLE2.Key.GetKey()].CalculatingBustLogic, _exceptionData[VARIABLE2.Key.GetKey()].FilterStagesSortingLogic);
                    
                    foreach (var VARIABLE3 in _exceptionData[VARIABLE2.Key.GetKey()].ListBustData)
                    {
                        foreach (var VARIABLE4 in VARIABLE3.GetDataBusts())
                        {
                            data.GetBustLogic.AddBust(VARIABLE4.Key, VARIABLE4.Data);
                        }
                    }
                    
                    foreach (var VARIABLE3 in _exceptionData[VARIABLE2.Key.GetKey()].ListFilterDataFloats)
                    {
                        foreach (var VARIABLE4 in VARIABLE3.GetDataFilters())
                        {
                            data.GetFilterLogic.AddFilter(VARIABLE4.Key, VARIABLE4.Data);
                        }
                    }
                }
                else
                {
                    data = new StorageBustLogicFloat(VARIABLE2.Data, _defatulParametrs.CalculatingBustLogic, _defatulParametrs.FilterStagesSortingLogic);
                    
                    foreach (var VARIABLE3 in _defatulParametrs.ListBustData)
                    {
                        foreach (var VARIABLE4 in VARIABLE3.GetDataBusts())
                        {
                            data.GetBustLogic.AddBust(VARIABLE4.Key, VARIABLE4.Data);
                        }
                    }
                    
                    foreach (var VARIABLE3 in _defatulParametrs.ListFilterDataFloats)
                    {
                        foreach (var VARIABLE4 in VARIABLE3.GetDataFilters())
                        {
                            data.GetFilterLogic.AddFilter(VARIABLE4.Key, VARIABLE4.Data);
                        }
                    }
                    
                }

                _bustCharacteristicData.Add(VARIABLE2.Key.GetKey(), data);
#if UNITY_EDITOR
                if (_visibleData == true)
                {
                    AddKeyVisible(VARIABLE2.Key, data);
                }
#endif
            }
        }

        _init = true;
        OnInit?.Invoke();
    }
    
    public GetCharacteristicDataFloat GetCharacteristicData(KeyCharacteristicFloat key)
    {
        return _bustCharacteristicData[key.GetKey()].GetBustCharacteristic();
    }
    
    public StorageBustLogicFloat GetBustData(KeyCharacteristicFloat key)
    {
        return _bustCharacteristicData[key.GetKey()];
    }
    
#if UNITY_EDITOR
    private AbsKeyData<KeyCharacteristicFloat, StorageBustLogicFloat> IsKeyVisible(KeyCharacteristicFloat key)
    {
        foreach (var VARIABLE in _listVisibleBustCharacteristic)
        {
            if (VARIABLE.Key == key)
            {
                return VARIABLE;
            }     
        }

        return null;
    }

    private void AddKeyVisible(KeyCharacteristicFloat key, StorageBustLogicFloat characteristic)
    {
        var data = IsKeyVisible(key);
        if (data == null)
        {
            var newData = new AbsKeyData<KeyCharacteristicFloat, StorageBustLogicFloat>(key,characteristic);
            
            _listVisibleBustCharacteristic.Add(newData);
        }
        
        
    }

    private void RemoveKeyVisible(KeyCharacteristicFloat key)
    {
        var data = IsKeyVisible(key);
        if (data != null)
        {
            _listVisibleBustCharacteristic.Remove(data);
        }
    }
#endif
}
