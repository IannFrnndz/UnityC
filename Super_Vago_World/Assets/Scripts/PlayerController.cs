using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Detección de suelo")]
    public Transform groundCheck;      // Empty en los pies del personaje
    public float checkRadius = 0.1f;   // Radio para detectar suelo
    public LayerMask groundLayer;      // Capa del suelo

    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform respawnPoint;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Detectar si estamos en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Movimiento horizontal
        float moveInput = Input.GetAxisRaw("Horizontal"); // -1 a 1
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // Gizmos para ver el GroundCheck en Scene
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }

    public void Respawn()
    {
        rb.linearVelocity = Vector2.zero; // detener movimiento
        transform.position = respawnPoint.position;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Princess"))
    //    {
    //        // Busca el PlayerController2D en el jugador
    //        var player = collision.gameObject.GetComponent<PlayerController2D>();
    //        if (player != null)
    //        {
    //            player.Respawn();
    //        }
    //    }
    //}



}
