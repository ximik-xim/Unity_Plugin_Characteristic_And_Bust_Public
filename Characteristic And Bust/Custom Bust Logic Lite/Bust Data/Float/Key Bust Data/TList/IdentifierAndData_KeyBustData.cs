using UnityEngine; 
using TListPlugin; 
[System.Serializable]
public class IdentifierAndData_KeyBustData : AbsIdentifierAndData<IndifNameSO_KeyBustData, string, KeyBustData>
{

 [SerializeField] 
 private KeyBustData _dataKey;


 public override KeyBustData GetKey()
 {
  return _dataKey;
 }
}
