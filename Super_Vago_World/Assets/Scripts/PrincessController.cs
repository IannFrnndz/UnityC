using UnityEngine;

using UnityEngine.SceneManagement;

public class PrincessController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public string winSceneName = "WinScene";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Busca el PlayerController2D en el jugador
            var player = collision.gameObject.GetComponent<PlayerController2D>();
            if (player != null)
            {
                SceneManager.LoadScene(winSceneName);
            }
        }
    }
}
