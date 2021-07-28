using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    //Variables
    public float speed = 150.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controller = GetComponent<CharacterController>();
        //if(controller.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if(Input.GetButton("Jump")){
                moveDirection.y = jumpSpeed;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        //}
    }
}
