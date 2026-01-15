using TMPro;
using UnityEditor;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    public Rigidbody rb;

    public float gravityForce;

    public float jumpForce;

    public GameObject pauseMenuGO;

    public int score;

    private TMP_Text scoreText;

    public GameObject scoreTextGO;

    public GameObject gameOverTextGO;

    private TMP_Text scoreTextFinal;

    private bool pauseUISwitch = false;

    public AudioSource sFXGameOver;

    public AudioSource sFXJump;

    public AudioSource sFXGame;

    bool isPause = false;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Hola soy el Start");

        rb = GetComponent<Rigidbody>();

        pauseMenuGO.SetActive(false);

        scoreText = scoreTextGO.GetComponent<TMP_Text>();
        scoreTextFinal = gameOverTextGO.GetComponent<TMP_Text>();

        scoreText.text = " ";

        //sFXGameOver = GetComponent<AudioSource>();
        //sFXJump = GetComponent<AudioSource>();

        sFXGame.Play();


    }


    // Update is called once per frame
    void Update()
    {
        //Dare una fuerza de gravedad

        rb.AddForce(Vector3.down * gravityForce * Time.deltaTime, ForceMode.Force);


        if ((Input.GetKeyDown(KeyCode.Space) == true || Input.GetMouseButtonDown(0)  ) && isPause == false)
        {

            
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            sFXJump.Play();
            //Darle una fuerza, direccion UP
            //Debug.Log("Hola soy el Update");
        }

        //if(Time.timeScale == 0.0f && Input.GetKeyDown(KeyCode.R) == true)
        //{
        //    Time.timeScale = 1.0f;
        //    UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        //}

        scoreText.text = "" + score;

        


        if (Input.GetKeyDown(KeyCode.Escape) == true && pauseUISwitch == true )
        {

            PauseMenu(true);
            pauseUISwitch = false;

          

        }

        else if (Input.GetKeyDown(KeyCode.Escape) == true && pauseUISwitch == false && Time.timeScale == 1.0f)
        {
            PauseMenu(false);

            pauseUISwitch = true;
        }

    }

    public void setData(int contadorFuera)
    {
        this.score = contadorFuera;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pipe" )
        {
            Debug.Log("Game Over");
            Time.timeScale = 0.0f;
            PauseMenu(false);
            sFXGameOver.Play();
            sFXGame.Stop();
        }


        Debug.Log("Chocaste con " + collision.gameObject.name);
    }

    public void PauseMenu(bool activate)
    {
        

        if (activate == false)
        {
            Time.timeScale = 0.0f;
            scoreTextGO.SetActive(false);
            pauseMenuGO.SetActive(true);
            isPause = true;
        }
        else
        {
           Time.timeScale = 1.0f;
            scoreTextGO.SetActive(true);
            pauseMenuGO.SetActive(false);
            isPause = false;
        }

        //pauseMenuGO.SetActive(true);
        //Time.timeScale = 0.0f;

        scoreTextFinal.text = ""+  score;

    }

    public void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Puntos: " + score);

        score++;

    }

   

    public void Restart()
    {
        Time.timeScale = 1.0f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    
}