using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Отвечает за хранение всех фильтров и расчет итогового значения с учетом всех фильтров
/// - За то в какой очереди будут применяться фильтры отвечает SO FilterStagesSortingSO
/// </summary>
[System.Serializable]
public class BustFilterStorageFloat
{
  /// <summary>
  /// Сработает, если будет установлена другая ссылка на фильтр
  /// Или если добавиться или удалиться сам фильтр
  /// </summary>  
  public event Action OnUpdateData;
    
  private Dictionary<string, AbsFilterDataFloat> _storageFilter = new Dictionary<string, AbsFilterDataFloat>();

  [SerializeField]
  private FilterStagesSortingSO _filterStagesSortingSo;

#if UNITY_EDITOR
  [SerializeField] 
  private bool _visibleData = true;

  [SerializeField] 
  private List<AbsKeyData<KeyFilterBust, AbsFilterDataFloat>> _listVisible = new List<AbsKeyData<KeyFilterBust, AbsFilterDataFloat>>();
#endif
  
  public void SetFilterSO(FilterStagesSortingSO filterSO)
  {
    _filterStagesSortingSo = filterSO;
    OnUpdateData?.Invoke();
  }


  public float StartFilter(float startValue)
  {
      return FilteringValues(startValue);
  }


  private float FilteringValues(float startValue)
  {
    List<KeyFilterBust> sortingData = _filterStagesSortingSo.GetStagesSorting();
    int indexOther = _filterStagesSortingSo.GetIdOtherData();
    List<string> stagesSortingKey = new List<string>();
    
    foreach (var VARIABLE in sortingData)
    {
        stagesSortingKey.Add(VARIABLE.GetKey());
    }

    float valueFilter = startValue;
    for (int i = 0; i < indexOther; i++)
    {  
       var key= stagesSortingKey[i];
       if (_storageFilter.ContainsKey(key) == true)
       {
          valueFilter = _storageFilter[key].StartFilter(valueFilter);
       }
    }

    foreach (var VARIABLE in _storageFilter)
    {
        if (stagesSortingKey.Contains(VARIABLE.Key) == false) 
        {
            valueFilter = VARIABLE.Value.StartFilter(valueFilter);
        }
    }

    for (int i = indexOther + 1; i < stagesSortingKey.Count; i++) 
    {
        var key= stagesSortingKey[i];
        if (_storageFilter.ContainsKey(key) == true)
        {
            valueFilter = _storageFilter[key].StartFilter(valueFilter);
        }
    }

    return valueFilter;
  }
  
  public void AddFilter(KeyFilterBust key, AbsFilterDataFloat filter)
  {
      _storageFilter.Add(key.GetKey(), filter);
      
#if UNITY_EDITOR
      if (_visibleData == true)
      {
          AddKeyVisible(key, filter);
      }
#endif
      
      OnUpdateData?.Invoke();
  }


  public void RemoveFilter(KeyFilterBust key)
  {
      _storageFilter.Remove(key.GetKey());
      
#if UNITY_EDITOR
      if (_visibleData == true)
      {
          RemoveKeyVisible(key);
      }
#endif
      
      OnUpdateData?.Invoke();
  }
  
  public bool IsKeyFilter(KeyFilterBust key)
  {
      return _storageFilter.ContainsKey(key.GetKey());
  }
  
#if UNITY_EDITOR
  private AbsKeyData<KeyFilterBust, AbsFilterDataFloat> IsKeyVisible(KeyFilterBust key)
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

  private void AddKeyVisible(KeyFilterBust key, AbsFilterDataFloat characteristic)
  {
      var data = IsKeyVisible(key);
      if (data == null)
      {
          var newData = new AbsKeyData<KeyFilterBust, AbsFilterDataFloat>(key,characteristic);
            
          _listVisible.Add(newData);
      }
        
        
  }

  private void RemoveKeyVisible(KeyFilterBust key)
  {
      var data = IsKeyVisible(key);
      if (data != null)
      {
          _listVisible.Remove(data);
      }
  }
#endif
  
}
