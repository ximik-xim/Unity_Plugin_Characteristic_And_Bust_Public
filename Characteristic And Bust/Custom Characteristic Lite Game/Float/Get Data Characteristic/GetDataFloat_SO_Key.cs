using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// При этой реализации, заполняем список характеристик через инспектор в отдельном GM
/// </summary>
public class GetDataFloat_SO_Key : AbsGetDataFloat
{
    public override event Action OnInit;
    public override bool Init => true;
    
    [SerializeField] 
    private List<AbsKeyData<GetDataSO_KeyCharacteristicFloat, InspectorCharacteristicDataFloat>> _listChatacteristicKeyData;
    
    public override void StartGetData()
    {
        
    }

    public override List<AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>> GetCharacteristicsData()
    {
        return GetData();
    }
    
    private List<AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>> GetData()
    {
        var list = new List<AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>>();
        foreach (var VARIABLE in _listChatacteristicKeyData)
        {
            list.Add(new AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>(VARIABLE.Key.GetData(), VARIABLE.Data.GetData()));
        }

        return list;
    }




}
