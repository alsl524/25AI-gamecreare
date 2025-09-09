using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    float start_poinr = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start_poinr++;
        transform.position = new Vector3(start_poinr, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        start_poinr = start_poinr - 0.05f;
        transform.position = new Vector3(start_poinr, transform.position.y, transform.position.z);
    }
}
