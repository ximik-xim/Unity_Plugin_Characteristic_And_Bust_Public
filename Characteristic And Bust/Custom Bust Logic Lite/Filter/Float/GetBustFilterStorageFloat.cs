
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBustFilterStorageFloat 
{
    public GetBustFilterStorageFloat(BustFilterStorageFloat data)
    {
        _storageFilterDataFloat = data;
    }
    
    private BustFilterStorageFloat _storageFilterDataFloat;
    
    public void AddFilter(KeyFilterBust key, AbsFilterDataFloat filter)
    {
        _storageFilterDataFloat.AddFilter(key, filter);
    }

    public void RemoveFilter(KeyFilterBust key)
    {
        _storageFilterDataFloat.RemoveFilter(key);
    }
  
    public bool IsKeyFilter(KeyFilterBust key)
    {
        return _storageFilterDataFloat.IsKeyFilter(key);
    }
}
