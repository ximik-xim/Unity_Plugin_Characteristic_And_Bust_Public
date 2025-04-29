using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsFilterData<Type> : MonoBehaviour
{
    public abstract Type StartFilter(Type data);
}
