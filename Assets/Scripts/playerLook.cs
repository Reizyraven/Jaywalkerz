using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLook : MonoBehaviour
{
    //Variables 
    public float xRotation;
    public float invertXRotation;
    public float yRotation;
    public float xCurrRotation;
    public float yCurrRotation;
    public Camera Camera;   
    public GameObject Player;
    public float mouseSensitivity;
    public float xRotationVelocity;
    public float yRotationVelocity; 
    public float smooth;
    public string invertYString;
    public Vector3 CurrentPosition; 
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        smooth = 0.1f;
        mouseSensitivity = 0.08f;
        //gameOver = GameObject.Find("Global").GetComponent<globalFunction>().gameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position != CurrentPosition){
    mouseMovement();
}
CurrentPosition  = Player.transform.position;
    }

    void mouseMovement(){
        xRotation += Input.GetAxis("Vertical") * mouseSensitivity;
        yRotation += Input.GetAxis("Horizontal") * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -20, 20);
        xCurrRotation = Mathf.SmoothDamp(xCurrRotation, invertXRotation, ref xRotationVelocity, smooth);
        yCurrRotation = Mathf.SmoothDamp(yCurrRotation, yRotation, ref yRotationVelocity, smooth);

        Camera.transform.rotation = Quaternion.Euler(xCurrRotation,yCurrRotation,0f);
        Player.transform.rotation = Quaternion.Euler(0f,yCurrRotation,0f);
    } 
}
