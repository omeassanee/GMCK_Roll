using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    CharacterController cc;
    float vertical;
    float horizontal;
    Vector3 crouchScale;
    Vector3 normalScale;
    Vector3 velocity;
    public float standingHeight = 2f;
    public float crouchingHeight = 1.25f;
    public float speed;
    public float gravityStrength;  
    
    void Start()
    {
        cc = GetComponent<CharacterController>();      
        Cursor.lockState = CursorLockMode.Locked;
        normalScale = Vector3.one;
        crouchScale = new Vector3(1f, crouchingHeight, 1f); 
    }

    void Update()
    {
        movement();  
    }

    void movement()
    {
        //Normal movement    
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 playerVec = transform.right * horizontal + transform.forward * vertical;
        cc.Move(playerVec * speed * Time.deltaTime);

        //Gravity
        velocity.y += gravityStrength * Time.deltaTime;  
        cc.Move(velocity * Time.deltaTime);

        //Crouching
        if (Input.GetKey(KeyCode.LeftControl))
        {                       
            transform.localScale = crouchScale;
        }
        else
        {            
            transform.localScale = normalScale;
        }        
    }
}
