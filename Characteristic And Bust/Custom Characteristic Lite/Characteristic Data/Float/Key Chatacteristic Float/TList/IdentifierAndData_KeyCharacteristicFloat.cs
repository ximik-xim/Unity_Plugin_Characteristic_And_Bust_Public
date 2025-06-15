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
 
#if UNITY_EDITOR
 public override string GetJsonSaveData()
 {
  return JsonUtility.ToJson(_dataKey);
 }

 public override void SetJsonData(string json)
 {
  _dataKey = JsonUtility.FromJson<KeyCharacteristicFloat>(json);
 }
#endif
}
