using UnityEngine;

public class ObstaclesMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            transform.Translate(Vector3.left * 5 * Time.deltaTime);
            if (transform.position.x < -10f)
                Destroy(gameObject);
    }
}
