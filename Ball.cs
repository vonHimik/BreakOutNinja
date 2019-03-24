using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 600f;
    public AudioClip hitSound;
    public AudioClip powerUpSound;
    public AudioClip powerDownSound;
    public AudioClip slopeSmashSound;
    public AudioSource audioSource;
    public GameObject multiple;
    public GameObject multiple2;

    private Rigidbody rb;
    private bool ballInPlay;
    private Camera camera;

    // Use this for initialization
    void Awake ()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (ballInPlay)
        {
            if (collision.gameObject.name == "NinjaPlatform(Clone)")
            {
                rb.AddForce(new Vector3(0, 200f, 0));

                Invoke("CameraUP", 0.1f);
                Invoke("CameraLEFT", 0.2f);
                Invoke("CameraRIGHT", 0.3f);
                Invoke("CameraDOWN", 0.4f);
                Invoke("CameraNORMAL", 0.5f);
            }

            if(collision.gameObject.tag == "Smash")
            {
                audioSource.PlayOneShot(hitSound);
            }

            if (collision.gameObject.tag == "PowerUp")
            {
                audioSource.PlayOneShot(powerUpSound);
                gameObject.transform.localScale = new Vector3(20, 20, 20);
            }

            if (collision.gameObject.tag == "PowerUp2")
            {
                audioSource.PlayOneShot(powerUpSound);
                Instantiate(multiple, transform.position, Quaternion.identity);
                multiple.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(300, 500), transform.position, 1);
                Instantiate(multiple2, transform.position, Quaternion.identity);
                multiple2.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(300, 500), new Vector3(0, transform.position.y - 3, 0), 5);

            }

            if (collision.gameObject.tag == "PowerDown")
            {
                audioSource.PlayOneShot(powerDownSound);
                gameObject.transform.localScale = new Vector3(4, 8, 10);
            }

            if (collision.gameObject.tag == "PowerDown2")
            {
                audioSource.PlayOneShot(powerDownSound);
                Destroy(gameObject);
                GM.instance.LoseLife();

            }

            if (collision.gameObject.tag == "PowerDown3")
            {
                audioSource.PlayOneShot(powerDownSound);
                rb.mass = 0.3f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (ballInPlay)
        {
            if (other.gameObject.tag == "Slope")
            {
                audioSource.PlayOneShot(slopeSmashSound);
            }
        }
    }

    void CameraUP()
    {
        camera.transform.position = new Vector3(0.0f, 0.10f, -23.1f);
    }

    void CameraDOWN()
    {
        camera.transform.position = new Vector3(0.0f, 0.0f, -23.1f);
    }

    void CameraLEFT()
    {
        camera.transform.position = new Vector3(-0.5f, 0.5f, -23.1f);
    }

    void CameraRIGHT()
    {
        camera.transform.position = new Vector3(0.5f, 0.5f, -23.1f);
    }

    void CameraNORMAL()
    {
        camera.transform.position = new Vector3(0.0f, 0.5f, -23.1f);
    }
}
