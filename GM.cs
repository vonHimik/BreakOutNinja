using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    //public int lives;
    public int bricks = 20;
    //public int score;
    //public int level;
    public float resetDelay = 1f;
    public Text livesText;
    public Text scoreText;
    public Text levelText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject platform;
    public GameObject deathPaticles;
    public static GM instance = null;
    public AudioClip winSound;
    public AudioClip endSound;
    public AudioSource audioSource;

    private GameObject clonePlatform;
    private GameObject gD;
    private GameData gDScript;


    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        Setup();
	}

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        gD = GameObject.Find("GameData");
        gDScript = gD.GetComponent<GameData>();
    }

    void Update()
    {
        livesText.text = "Lives: " + gDScript.lives;
        scoreText.text = "Score: " + gDScript.score;
        levelText.text = "Level: " + gDScript.level;
    }

    public void Setup()
    {
        clonePlatform = Instantiate(platform, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if(bricks < 1)
        {
            //level++;
            gDScript.level++;
            youWon.SetActive(true);
            Time.timeScale = .25f;
            //Invoke("Reset", resetDelay);
            Invoke("NextLevel", resetDelay);
            audioSource.PlayOneShot(winSound);
        }

        if(gDScript.lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
            audioSource.PlayOneShot(endSound);
        }
    }

    void Reset()
    {
        Time.timeScale = 1f;
        gDScript.lives = 4;
        gDScript.score = 0;
        gDScript.level = 1;
        Application.LoadLevel("Level1");
    }

    void NextLevel()
    {
        Time.timeScale = 1f;

        gDScript.lives = 4;

        if (Application.loadedLevelName == "Level1")
        {
            Application.LoadLevel("Level2");
        }

        if (Application.loadedLevelName == "Level2")
        {
            Application.LoadLevel("Level3");
        }
    }

    public void LoseLife()
    {
        //lives--;
        //livesText.text = "Lives: " + lives;
        gDScript.lives--;
        Instantiate(deathPaticles, clonePlatform.transform.position, Quaternion.identity);
        Destroy(clonePlatform);
        Invoke("SetupPlatform", resetDelay);
        CheckGameOver();
    }

    void SetupPlatform()
    {
        clonePlatform = Instantiate(platform, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }

    public void ScoreUp()
    {
        //score++;
        gDScript.score++;
    }
}
