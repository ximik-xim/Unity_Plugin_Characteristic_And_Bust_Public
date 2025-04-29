
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ParametersBustData
{
    [SerializeField]
    private AbsCalculatingBustFloat _calculatingBustLogic;
    [SerializeField]
    private FilterStagesSortingSO _filterStagesSortingLogic;

    public AbsCalculatingBustFloat CalculatingBustLogic => _calculatingBustLogic;
    public FilterStagesSortingSO FilterStagesSortingLogic => _filterStagesSortingLogic;
    
    [SerializeField]
    private List<AbsGetListBustDataFloat> _listBustData;
    [SerializeField] 
    private List<AbsGetListFilterDataFloat> _listFilterDataFloats;

    public List<AbsGetListFilterDataFloat> ListFilterDataFloats => _listFilterDataFloats;
    [SerializeField] 
    public List<AbsGetListBustDataFloat> ListBustData => _listBustData;

}
