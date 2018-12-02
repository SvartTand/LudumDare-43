using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {

    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    private Rigidbody rb;

    public float maxSpeed;
    public float boost;
    public float torque;
    public float breaks;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = 0;
        Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude <= maxSpeed)
        {
            motor = maxMotorTorque * Input.GetAxis("Vertical");
            rb.AddForce(transform.forward * boost * Input.GetAxis("Vertical"));
        }
        else
        {
            
        }
        if (Input.GetKey(KeyCode.E))
        {
            //rb.AddForce(transform.forward * boost);
        }

            if (Input.GetKey(KeyCode.Space))
        {
            rb.drag = breaks;
        }
        else
        {
            rb.drag = 0;
        }

        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        rb.AddTorque(transform.up * Input.GetAxis("Horizontal") * torque);

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;

            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
        
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}

