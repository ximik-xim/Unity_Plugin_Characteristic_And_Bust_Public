using System;
using UnityEngine;

/// <summary>
/// Нужен для того что бы получить данные об характеристики из разных источников
/// (обобщение будет морочно делать)
/// </summary>
public abstract class AbsGetInfoInitCharacteristicDataFloat : MonoBehaviour
{
    public abstract event Action OnInit;
    public abstract bool IsInit { get; }
    
    public abstract GetCharacteristicDataFloat GetData(KeyCharacteristicFloat key);
}
