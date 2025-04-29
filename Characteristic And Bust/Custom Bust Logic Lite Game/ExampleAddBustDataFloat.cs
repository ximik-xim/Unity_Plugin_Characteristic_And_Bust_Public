using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleAddBustDataFloat : MonoBehaviour
{
   [SerializeField] 
   private StorageBustFloat _storageBust;

   [SerializeField]
   private GetDataSO_KeyCharacteristicFloat _keyCharacteristic;
   
   [SerializeField] 
   private GetDataSO_KeyBustData _keyBust;
   
   [SerializeField]
   private BustDataFloat _bustData;

   private void Awake()
   {
      if (_storageBust.Init == false)
      {
         _storageBust.OnInit += OnInitBustStorage;
         return;
      }

      InitBustStorage();
   }
    
   private void OnInitBustStorage()
   {
      _storageBust.OnInit -= OnInitBustStorage;
      InitBustStorage();
   }

   private void InitBustStorage()
   {
      var bustData = _storageBust.GetBustData(_keyCharacteristic.GetData());
      bustData.GetBustLogic.AddBust(_keyBust.GetData(), _bustData);
   }

   private void OnEnable()
   {
      if (_storageBust.Init == true) 
      {
         var bustData = _storageBust.GetBustData(_keyCharacteristic.GetData());
         if (bustData.GetBustLogic.IsKeyBust(_keyBust.GetData()) == false) 
         {
            bustData.GetBustLogic.AddBust(_keyBust.GetData(), _bustData);   
         }
      }
   }

   private void OnDisable()
   {
      if (_storageBust.Init == true) 
      {
         var bustData = _storageBust.GetBustData(_keyCharacteristic.GetData());
         if (bustData.GetBustLogic.IsKeyBust(_keyBust.GetData()) == true) 
         {
            bustData.GetBustLogic.RemoveBust(_keyBust.GetData());   
         }
      }
   }
}
