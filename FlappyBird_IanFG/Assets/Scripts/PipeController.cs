using UnityEngine;

public class PipeController : MonoBehaviour
{

    //movement speed in units per second
    public float movementSpeed;

    public float xLimit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > xLimit)
        { 
            float nuevaY = Random.Range(7.04f, 1.5f);
            transform.position = new Vector3(-xLimit, nuevaY, -18.37f);
        }

        transform.position += new Vector3(+movementSpeed,0.0f,0.0f) * Time.deltaTime;


    }
}
