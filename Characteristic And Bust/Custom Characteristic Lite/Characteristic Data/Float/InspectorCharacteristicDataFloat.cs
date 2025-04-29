using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Отвечает за то, что бы при изменении переменной в инспекторе, если находимся в PlayMode, что бы сработал event 
/// </summary>
[System.Serializable]
public class InspectorCharacteristicDataFloat 
{
    [SerializeField] 
    [OnChangedCall(nameof(OnValueChange))]
    private CharacteristicDataFloat _characteristicData;

    private GetCharacteristicDataFloat _dataKey;
 
    /// <summary>
    /// Тут задумка в том, что бы вызывать event на обновление значений, если значение в SO было изменено через инспектор во время игры(как у MonoBehaviour)
    /// </summary>
    private void OnValueChange()
    {
        if (Application.isPlaying == true)
        {
            if (_dataKey == null)
            {
                _dataKey = new GetCharacteristicDataFloat(_characteristicData);
            }

            _characteristicData.SetValue(_characteristicData.GetValue());
        }
   
    }

    public GetCharacteristicDataFloat GetData()
    {
        if (_dataKey == null)
        {
            _dataKey = new GetCharacteristicDataFloat(_characteristicData);
        }
  
        return _dataKey;
    }
}
