using System;
using UnityEngine;


/// <summary>
/// Получение абстракции(любого места котор. может вернут характеристику) через Patch DKO
/// </summary>
public class GetAbsStorageCharacteristicInPatch : AbsGetStorageCharacteristicFloat
{
   [SerializeField] 
   private GetDKOPatch _patchGetStorageCharacteristicFloat;
   
   public override event Action OnInit
   {
      add
      {
         _patchGetStorageCharacteristicFloat.OnInit += value;
      }

      remove
      {
         _patchGetStorageCharacteristicFloat.OnInit -= value;
      }
   }
   public override bool IsInit => _patchGetStorageCharacteristicFloat.Init;

   public override GetCharacteristicDataFloat GetData(KeyCharacteristicFloat key)
   {
      var data = (DKODataInfoT<AbsGetStorageCharacteristicFloat>)_patchGetStorageCharacteristicFloat.GetDKO();
      return data.Data.GetData(key);
   }
}
