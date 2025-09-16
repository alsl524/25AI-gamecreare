using UnityEngine;

public class todtjdrl : MonoBehaviour
{
    public GameObject todtjd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    bool a = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (a)
        {
            Debug.Log("Spike : »ý¼º");
            GameObject spike = Instantiate(todtjd);
            spike.transform.position = transform.position;
            a = false;
        }
    }
}
