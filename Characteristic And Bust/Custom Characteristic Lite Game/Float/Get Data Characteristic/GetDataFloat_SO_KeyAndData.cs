using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// При этой реализации, буду брать данные из SO где уже проставлены ключи и данные
/// </summary>
public class GetDataFloat_SO_KeyAndData : AbsGetDataFloat
{
    public override event Action OnInit;
    public override bool Init => true;

    [SerializeField] 
    private SO_KeyAndData _data;
    
    public override void StartGetData()
    {
        
    }

    public override List<AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>> GetCharacteristicsData()
    {
        return _data.GetData();
    }
}
