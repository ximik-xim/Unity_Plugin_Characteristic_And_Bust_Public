using UnityEngine; 
using TListPlugin; 
[System.Serializable]
public class IdentifierAndData_KeyFilterBust : AbsIdentifierAndData<IndifNameSO_KeyFilterBust, string, KeyFilterBust>
{

 [SerializeField] 
 private KeyFilterBust _dataKey;


 public override KeyFilterBust GetKey()
 {
  return _dataKey;
 }
}
