using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetListFilterDataFloatMono : AbsGetListFilterDataFloat
{
    [SerializeField] 
    private List<AbsKeyData<GetDataSO_KeyFilterBust, AbsFilterDataFloat>> _listFilter;
    
    public override List<AbsKeyData<KeyFilterBust, AbsFilterDataFloat>> GetDataFilters()
    {
        List<AbsKeyData<KeyFilterBust, AbsFilterDataFloat>> list = new List<AbsKeyData<KeyFilterBust, AbsFilterDataFloat>>();

        foreach (var VARIABLE in _listFilter)
        {
            list.Add(new AbsKeyData<KeyFilterBust, AbsFilterDataFloat>(VARIABLE.Key.GetData(), VARIABLE.Data));
        }

        return list;
    }
}
