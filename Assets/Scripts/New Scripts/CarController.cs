using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public class AxleInfo {
    public WheelCollider LeftWheel;
    public WheelCollider RightWheel;
    public bool Accelerate;
    public bool Steering;
}

public class CarController : MonoBehaviour {
    public List<AxleInfo> Axles; 
    public float MaxTorque = 200;
    public float MaxSteering = 30;

   // public TextMeshProUGUI CarSpeedDashUI;
    public WheelCollider ChosenWheel;
    public Rigidbody Car;


    void Start()
    {
        MaxTorque = 200;
        MaxSteering = 30;
        //CarSpeedDashUI = GameObject.Find("CarSpeed").GetComponent<TextMeshProUGUI>();
    }

    // NOTE: Finds the corresponding visual wheel and correctly applies the transform

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0) {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }


    // NOTE: Update runs once per frame. FixedUpdate can run once, zero, or several times per frame, depending on how many physics frames per second are set in the time settings 
    public void FixedUpdate()
    {
        float motor = MaxTorque * Input.GetAxis("Vertical");

        //Slow down if foot is off accelerator (W key)
        if(ChosenWheel.rpm > 0 && (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) ){
            Car.velocity -= 0.1f * Car.velocity;
        }
        if(Car.velocity.magnitude < 20 && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)){
            Car.velocity += 0.005f * Car.velocity;
        }
        float steering = MaxSteering * Input.GetAxis("Horizontal");
        //CarSpeedDashUI.text = ChosenWheel.rpm.ToString();

        foreach (AxleInfo axleInfo in Axles) {
            if (axleInfo.Steering) {
                axleInfo.LeftWheel.steerAngle = steering;
                axleInfo.RightWheel.steerAngle = steering;
            }
            if (axleInfo.Accelerate) {
                axleInfo.LeftWheel.motorTorque = motor;
                axleInfo.RightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.LeftWheel);
            ApplyLocalPositionToVisuals(axleInfo.RightWheel);
        }
    }
}