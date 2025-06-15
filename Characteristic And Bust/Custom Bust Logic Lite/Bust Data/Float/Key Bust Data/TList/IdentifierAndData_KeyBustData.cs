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
 
#if UNITY_EDITOR
 public override string GetJsonSaveData()
 {
  return JsonUtility.ToJson(_dataKey);
 }

 public override void SetJsonData(string json)
 {
  _dataKey = JsonUtility.FromJson<KeyBustData>(json);
 }
#endif
}
