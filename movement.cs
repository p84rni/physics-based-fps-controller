using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    //p84rni's fps controller
    //please don't steal and pass this off as your own        thank you! <3

    public float Sensitivity = 100f;
    public float Speed = 20f;
    public float JumpForce = 20f;
    public Transform Camera;
    Rigidbody rb;
    float xRotation = 0f;
    bool jumped = false;


    void Start()
    {
        Cursor.lockState= CursorLockMode.Locked;
        //You can unlock the cursor with left alt
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
         if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.lockState= CursorLockMode.None;
            
        }
         if (Input.GetKey(KeyCode.Space) && jumped == false)
        {
            
            rb.AddForce(transform.up * JumpForce);
            jumped = true;
            
        }
         if (Input.GetKey(KeyCode.W))
        {
          
            rb.AddForce(transform.forward * Speed);
        }
         if (Input.GetKey(KeyCode.S))
        {
           
            rb.AddForce(transform.forward * -Speed);
        }
         if (Input.GetKey(KeyCode.A))
        {
          
            rb.AddForce(transform.right * -Speed);
        }
         if (Input.GetKey(KeyCode.D))
        {
           
            rb.AddForce(transform.right * Speed);
        }

        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        Camera.localRotation = Quaternion.Euler(xRotation, 0f , 0f);


    }
    void OnCollisionEnter(){
        jumped = false;
    }
}
