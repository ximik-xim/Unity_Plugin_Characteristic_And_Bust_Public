using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// обертка нужна что бы тупо убрать не нужный функцианал
/// </summary>
public class GetStorageBustDataFloat 
{
    public GetStorageBustDataFloat(StorageBustDataFloat data)
    {
        _storageBustDataFloat = data;
    }
    
    private StorageBustDataFloat _storageBustDataFloat;
    
    public void AddBust(KeyBustData key, BustDataFloat filter)
    {
        _storageBustDataFloat.AddBust(key, filter);
    }

    public void RemoveBust(KeyBustData key)
    {
        _storageBustDataFloat.RemoveBust(key);
    }
  
    public bool IsKeyBust(KeyBustData key)
    {
        return _storageBustDataFloat.IsKeyBust(key);
    }
}
