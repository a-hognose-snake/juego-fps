using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    // Variable de velocidad
    public float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, 0.5f, 0);
        }
    }

    // Method detects collision
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with object: " + collision.gameObject.name);
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
