using System;
using UnityEngine;

/// <summary>
/// Припер, который выводит в консоль изменение данных характеристики
/// </summary>
public class ExampleDebugValueCharacteristicFloat : MonoBehaviour
{
    [SerializeField]
    private GetCharacteristicFloatWrapper _getCharacteristicFloat;
    private GetCharacteristicDataFloat _characteristic;
    private void Awake()
    {
        if (_getCharacteristicFloat.IsInit == false)
        {
            _getCharacteristicFloat.OnInit += OnInitStorageCharact;
            return;
        }

        InitStorageCharact();
    }

    private void OnInitStorageCharact()
    {
        _getCharacteristicFloat.OnInit -= OnInitStorageCharact;
        InitStorageCharact();
    }
    
    private void InitStorageCharact()
    {
        _characteristic = _getCharacteristicFloat.GetCharacteristic();
        Debug.Log($"Текущее значение характеристики {_getCharacteristicFloat.GetKeyCharacteristic().GetKey()} равно = {_characteristic.GetValue()} ");

        _characteristic.OnUpdateValue += OnUpdateValueCharacteristic;
    }

    private void OnUpdateValueCharacteristic()
    {
        Debug.Log($"Обновление значения характеристики {_getCharacteristicFloat.GetKeyCharacteristic().GetKey()} теперь значение = {_characteristic.GetValue()} ");
    }

    private void OnDestroy()
    {
        if (_characteristic != null)
        {
            _characteristic.OnUpdateValue -= OnUpdateValueCharacteristic;
        }
    }
}
