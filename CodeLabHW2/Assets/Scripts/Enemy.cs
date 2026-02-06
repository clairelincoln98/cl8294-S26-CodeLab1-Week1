using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyForce;
    private Rigidbody rb;
    
    public Vector3 newPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyForce = Random.Range(-5f, 5f);
       
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.AddForce(Vector3.right * enemyForce);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
