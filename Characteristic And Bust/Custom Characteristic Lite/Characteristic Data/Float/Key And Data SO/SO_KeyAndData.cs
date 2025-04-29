using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Characteristic/Float/SO Characteristic Key And Data")]
public class SO_KeyAndData : ScriptableObject
{ 
    [SerializeField] 
    private List<AbsKeyData<GetDataSO_KeyCharacteristicFloat, InspectorCharacteristicDataFloat>> _listChatacteristicKeyData;

    public List<AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>> GetData()
    {
        var list = new List<AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>>();
        foreach (var VARIABLE in _listChatacteristicKeyData)
        {
            list.Add(new AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>(VARIABLE.Key.GetData(), VARIABLE.Data.GetData()));
        }

        return list;
    }

}
