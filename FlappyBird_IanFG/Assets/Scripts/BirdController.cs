using UnityEngine;

public class BirdController : MonoBehaviour
{

    public Rigidbody rb;

    public float gravityForce;

    public float jumpForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hola soy el Start");

        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        //Dare una fuerza de gravedad

        rb.AddForce(Vector3.down * gravityForce * Time.deltaTime, ForceMode.Force);


        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //Darle una fuerza, direccion UP
            //Debug.Log("Hola soy el Update");
        }
    }
}