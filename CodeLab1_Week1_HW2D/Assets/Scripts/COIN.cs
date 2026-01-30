using UnityEngine;

public class COIN : MonoBehaviour
 {
 
     public float coinCount;
     private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject.CompareTag("Player"))
         {
             Debug.Log("collider working");
             coinCount += 1;
             print(coinCount);
         }
     }
 }