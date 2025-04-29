using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Отвечает за хранение всех бустов и расчет итогового значения с учетом всех бустов
/// - За то как будет производиться расчет отвечает абстракция AbsCalculatingBustFloat
/// </summary>
[System.Serializable]
public class StorageBustDataFloat 
{
    /// <summary>
    /// Сработает, если будет установлена другая ссылка на логику вычесления значений у буста
    /// Или если добавиться или удалиться данные буста
    /// </summary>  
    public event Action OnUpdateData;

    private Dictionary<string, BustDataFloat> _bustData = new Dictionary<string, BustDataFloat>();
    
    [SerializeField] 
    private AbsCalculatingBustFloat _absCalculatingBustFloat;
    
#if UNITY_EDITOR
    [SerializeField] 
    private bool _visibleData = true;

    [SerializeField] 
    private List<AbsKeyData<KeyBustData, BustDataFloat>> _listVisible = new List<AbsKeyData<KeyBustData, BustDataFloat>>();
#endif
    
    public void SetCalculatingBust(AbsCalculatingBustFloat filterSO)
    {
        _absCalculatingBustFloat = filterSO;
        OnUpdateData?.Invoke();
    }
    
    public float StartBust(float startValue)
    {
        List<AbsKeyData<string, BustDataFloat>> list = new List<AbsKeyData<string, BustDataFloat>>();
        foreach (var VARIABLE in _bustData)
        {
            list.Add(new AbsKeyData<string, BustDataFloat>(VARIABLE.Key, VARIABLE.Value));
        }

        return _absCalculatingBustFloat.StartCalculatingBust(startValue, list);

    }
    
    public void AddBust(KeyBustData key, BustDataFloat filter)
    {
        _bustData.Add(key.GetKey(), filter);
        
#if UNITY_EDITOR
        if (_visibleData == true)
        {
            AddKeyVisible(key, filter);
        }
#endif
        
        OnUpdateData?.Invoke();
    }

    public void RemoveBust(KeyBustData key)
    {
        _bustData.Remove(key.GetKey());
        
#if UNITY_EDITOR
        if (_visibleData == true)
        {
            RemoveKeyVisible(key);
        }
#endif
        
        OnUpdateData?.Invoke();
    }
  
    public bool IsKeyBust(KeyBustData key)
    {
        return _bustData.ContainsKey(key.GetKey());
    }
    
    
#if UNITY_EDITOR
    private AbsKeyData<KeyBustData, BustDataFloat> IsKeyVisible(KeyBustData key)
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

    private void AddKeyVisible(KeyBustData key, BustDataFloat characteristic)
    {
        var data = IsKeyVisible(key);
        if (data == null)
        {
            var newData = new AbsKeyData<KeyBustData, BustDataFloat>(key,characteristic);
            
            _listVisible.Add(newData);
        }
        
        
    }

    private void RemoveKeyVisible(KeyBustData key)
    {
        var data = IsKeyVisible(key);
        if (data != null)
        {
            _listVisible.Remove(data);
        }
    }
#endif

}
