using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class PlayerInventory : MonoBehaviour
{
   public int numberOfSeeds {get ; set;}

   public Text textoSemente;

   void Start()
   {
       atualizaSemente();
   }

   public void SeedCollected()
   {
       numberOfSeeds++;
       atualizaSemente();
   }

   public int GetNumSeeds()
   {
       return numberOfSeeds;
   }

   public void ReduceSeeds (int amount)
   {
       numberOfSeeds -= amount;
       atualizaSemente();
   }

   void atualizaSemente()
   {
       textoSemente.text = numberOfSeeds.ToString();
   }
}
