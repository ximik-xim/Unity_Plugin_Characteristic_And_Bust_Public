using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Нужен для определенияэтапов сортировки фильтра(какой за каким филтр пойдет)
/// Тот ключ, что будет стоять више всех(первый в списке) тот и будет использоваться как стартовый фильтр
/// А дальше по порядку
/// </summary>
[CreateAssetMenu(menuName = "Bust/Filter/Stages Sorting")]
public class FilterStagesSortingSO : ScriptableObject
{

    /// <summary>
    /// Нужен если, нужно указать начальные и конечные фильтры, а остальные где то в промежутке
    /// (если не установлен, то остальные фильтры будут применены после тех, что уже указаны)
    /// </summary>
    [SerializeField] 
    private GetDataSO_KeyFilterBust _keyOtherData;
    
    [SerializeField] 
    private List<GetDataSO_KeyFilterBust> _stagesSorting;

    public int GetIdOtherData()
    {
        for (int i = 0; i < _stagesSorting.Count; i++)
        {
            if (_stagesSorting[i].GetData() == _keyOtherData.GetData())
            {
                return i;
            }
           
        }

        return _stagesSorting.Count;
    }

    public List<KeyFilterBust> GetStagesSorting()
    {
        List<KeyFilterBust> list = new List<KeyFilterBust>();

        foreach (var VARIABLE in _stagesSorting)
        {
            list.Add(VARIABLE.GetData());
        }

        return list;
    }
    
}
