using System;
using UnityEngine;

public class GetInfoDKOInitCharacteristicCharacteristicStorageFloat : AbsGetInfoInitCharacteristicDataFloat
{
   [SerializeField] 
   private GetDKOPatch _patchDKO;

   public override event Action OnInit
   {
      add
      {
         _patchDKO.OnInit += value;
      }

      remove
      {
         _patchDKO.OnInit -= value;
      }
   }

   public override bool IsInit => _patchDKO.Init;
   public override GetCharacteristicDataFloat GetData(KeyCharacteristicFloat key)
   {
      var data = (DKODataInfoT<CharacteristicStorageFloat>)_patchDKO.GetDKO();
      return data.Data.GetCharacteristicData(key);
   }
}
