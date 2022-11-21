using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    // Variable de velocidad
    public float speed = 0.01f;

    public float Force = 5f;

    public bool isJumping = false;

    public int points = 0;

    // Variable que hace referencia al audio source
    private AudioSource audioSource;

    private Rigidbody rb;

    // Variable para almacenar sonido de salto
    public AudioClip jumpSound;

    // Variable para almacenar sonido de moneda
    public AudioClip moneySound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        
    }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed, 0, 0);
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, speed);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -speed);
        }

    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            transform.Translate(0, Force, 0);
            isJumping = true;

            // Reproducir sonido de salto
            audioSource.clip = jumpSound;
            audioSource.Play();
        }
    }

    // Method detects collision
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with object: " + collision.gameObject.name);

        audioSource.clip = moneySound;
        audioSource.Play();
        points ++;
        if (collision.gameObject.name != "Plane")
        {
            Destroy(collision.gameObject);
        }
        
    }
    
    // Method detects collision exit
    public void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit collision with " + collision.gameObject.name);
    }

    // Method detects collision stay
    public void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay collision with " + collision.gameObject.name);
    }
}
