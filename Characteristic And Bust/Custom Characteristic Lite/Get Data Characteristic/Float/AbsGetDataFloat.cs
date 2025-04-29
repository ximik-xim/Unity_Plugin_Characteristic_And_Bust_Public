using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AbsGetDataFloat : MonoBehaviour
{
    public abstract event Action OnInit;

    public abstract bool Init { get; }

    public abstract void StartGetData();

    public abstract List<AbsKeyData<KeyCharacteristicFloat, GetCharacteristicDataFloat>> GetCharacteristicsData();
}
