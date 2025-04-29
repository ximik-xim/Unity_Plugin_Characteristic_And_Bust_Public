using UnityEngine; 
using TListPlugin; 
[System.Serializable]
public class IdentifierAndData_KeyCharacteristicFloat : AbsIdentifierAndData<IndifNameSO_KeyCharacteristicFloat, string, KeyCharacteristicFloat>
{

 [SerializeField] 
 private KeyCharacteristicFloat _dataKey;


 public override KeyCharacteristicFloat GetKey()
 {
  return _dataKey;
 }
}
