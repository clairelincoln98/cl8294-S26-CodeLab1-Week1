using UnityEditor;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
public GameObject enemy;

public float enemyNumber;

public float launchItemTimer; //time that has passed
public float launchItemTimerMax; //timer max that timer will count up to
public float launchItemTimerInit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        launchItemTimer = launchItemTimerInit;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (launchItemTimer > 0)
        {
            launchItemTimer -= Time.deltaTime; //adds time to the timer between enemy launches
            
        }
        else
        {
            for (var i = 0; i < enemyNumber; i++) //for loop that runs through the number of enemies and creates one
            {
                Instantiate(enemy, new Vector3(Random.Range(2, 10), Random.Range(-4, 4), 0), Quaternion.identity); //creates enemy at a random position that doesn't collide w player
            }

            for (var i = 0; i < enemyNumber; i++)
            {
                Instantiate(enemy, new Vector3(Random.Range(-10, -2), Random.Range(-4, 4), 0), Quaternion.identity);
            }
            launchItemTimer = launchItemTimerMax; //timer is reset
        }
    }
}
