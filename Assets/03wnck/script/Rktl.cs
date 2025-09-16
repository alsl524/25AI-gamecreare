using UnityEngine;

public class TriangleMove : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3 (transform.position.x - 0.05f, transform.position.y, transform.position.z);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("tkrwprl"))
            {
            Destroy(gameObject);
            Debug.Log("Spike : ¼Ò¸ê");
        } 
    }
}
