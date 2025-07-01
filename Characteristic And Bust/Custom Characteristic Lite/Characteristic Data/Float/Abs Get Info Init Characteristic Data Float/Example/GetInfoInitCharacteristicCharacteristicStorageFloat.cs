using System;
using UnityEngine;

public class GetInfoInitCharacteristicCharacteristicStorageFloat : AbsGetStorageCharacteristicFloat
{
   [SerializeField]
   private CharacteristicStorageFloat _characteristicStorageFloat;

   public override event Action OnInit
   {
      add
      {
         _characteristicStorageFloat.OnInit += value;
      }

      remove
      {
         _characteristicStorageFloat.OnInit -= value;
      }
   }

   public override bool IsInit => _characteristicStorageFloat.Init;
   public override GetCharacteristicDataFloat GetData(KeyCharacteristicFloat key)
   {
      return _characteristicStorageFloat.GetCharacteristicData(key);
   }
}
