using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsCalculatingBustFloat : MonoBehaviour
{
    public abstract float StartCalculatingBust(float baseValue, List<AbsKeyData<string, BustDataFloat>> data);
}
