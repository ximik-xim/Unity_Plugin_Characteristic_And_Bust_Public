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
 
#if UNITY_EDITOR
 public override string GetJsonSaveData()
 {
  return JsonUtility.ToJson(_dataKey);
 }

 public override void SetJsonData(string json)
 {
  _dataKey = JsonUtility.FromJson<KeyFilterBust>(json);
 }
#endif
}
