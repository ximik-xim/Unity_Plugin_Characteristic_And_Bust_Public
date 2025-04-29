using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
/// <summary>
/// Отвечает за поэтапную логику расчета значения
/// с учетом
/// - бустов
/// - фильтров
/// </summary>
[System.Serializable]
public class StorageBustLogicFloat
{
    public StorageBustLogicFloat(GetCharacteristicDataFloat baseValue, AbsCalculatingBustFloat calculatingBustLogic, FilterStagesSortingSO filterStagesSortingLogic)
    {
        _baseValue = baseValue;
        _bustLogic = new StorageBustDataFloat();
        _filterLogic = new BustFilterStorageFloat();

        _getBustLogic = new GetStorageBustDataFloat(_bustLogic);
        _getFilterLogic = new GetBustFilterStorageFloat(_filterLogic);
        
        _finishValue = new CharacteristicDataFloat();
        _finishGetValue = new GetCharacteristicDataFloat(_finishValue);
        
        _bustLogic.SetCalculatingBust(calculatingBustLogic);
        _filterLogic.SetFilterSO(filterStagesSortingLogic);

        _baseValue.OnUpdateValue += OnUpdateDataBaseValue;
        _bustLogic.OnUpdateData += OnUpdateDataBustLogic;
        _filterLogic.OnUpdateData += OnUpdateDataFilterLogic;
        
        StatLogic();
    }

    private void OnUpdateDataBaseValue()
    {
        StatLogic();
    }

    private void OnUpdateDataFilterLogic()
    {
        StatLogic();
    }

    private void OnUpdateDataBustLogic()
    {
        StatLogic();
    }

    private void StatLogic()
    {
        float value = _baseValue.GetValue();

        value = _bustLogic.StartBust(value);
        value = _filterLogic.StartFilter(value);

        _finishValue.SetValue(value);
    }

    private GetCharacteristicDataFloat _baseValue;

    private CharacteristicDataFloat _finishValue;
    private GetCharacteristicDataFloat _finishGetValue;
    
    [SerializeField] 
    private StorageBustDataFloat _bustLogic;
    
    [SerializeField]
    private BustFilterStorageFloat _filterLogic;

    /// <summary>
    /// Нужен что ограничить функционал
    /// </summary>
    private GetStorageBustDataFloat _getBustLogic;
    public GetStorageBustDataFloat GetBustLogic => _getBustLogic;
    
    /// <summary>
    /// Нужен что ограничить функционал
    /// </summary>
    private GetBustFilterStorageFloat _getFilterLogic;
    public GetBustFilterStorageFloat GetFilterLogic => _getFilterLogic;
    
    public GetCharacteristicDataFloat GetBustCharacteristic()
    {
        return _finishGetValue;
    }
}
