using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsGetCharacteristicValue<TypeValue>
{
 public abstract event Action OnUpdateValue;

 public abstract TypeValue GetValue();
}
