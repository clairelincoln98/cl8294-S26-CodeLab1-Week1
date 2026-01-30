using UnityEngine;

public class COIN : MonoBehaviour
 {
 
     public float coinCount;
     private void OnCollisionEnter2D(Collision2D other)
     {
         if (other.gameObject.CompareTag("Player"))
         {
             Debug.Log("collider working");
             coinCount += 1;
             print(coinCount);
             Destroy(other.gameObject);
         }
     }
 }