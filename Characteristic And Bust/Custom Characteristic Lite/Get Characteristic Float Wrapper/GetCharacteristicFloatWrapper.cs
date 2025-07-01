using System;
using UnityEngine;

/// <summary>
/// Нужен для упрощения доступа к какой то характеристики
/// (допустим нескольким скриптам понадобилась одна и таже характеристика,
/// и что бы у всех не прописывать одно и тоже, можно исп. этот класс) 
/// </summary>
public class GetCharacteristicFloatWrapper : MonoBehaviour
{
    [SerializeField]
    private GetDataSO_KeyCharacteristicFloat _keyCharacteristic;
    
    [SerializeField] 
    private AbsGetStorageCharacteristicFloat _characteristicStorage;

    public event Action OnInit;
    public bool IsInit => _isInit;
    private bool _isInit = false;
    private void Awake()
    {
        if (_characteristicStorage.IsInit == false)
        {
            _characteristicStorage.OnInit += OnInitStorageCharact;
            return;
        }

        InitStorageCharact();
    }

    private void OnInitStorageCharact()
    {
        _characteristicStorage.OnInit -= OnInitStorageCharact;
        InitStorageCharact();
    }
    
    private void InitStorageCharact()
    {
        _isInit = true;
        OnInit?.Invoke();
    }

    public KeyCharacteristicFloat GetKeyCharacteristic()
    {
        return _keyCharacteristic.GetData();
    }
    
    public GetCharacteristicDataFloat GetCharacteristic()
    {
        return _characteristicStorage.GetData(_keyCharacteristic.GetData());
    }
}
