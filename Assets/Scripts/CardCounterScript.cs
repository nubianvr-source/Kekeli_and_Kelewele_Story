using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardCounterScript : MonoBehaviour
{
   public TMP_Text cardCountNumber;

   private void Update()
   {
      SetCardCountNumber();
   }

   private void SetCardCountNumber()
   {
      cardCountNumber.text = GameManager.instance.GetTurnedCardsCount().ToString();
   }
}
