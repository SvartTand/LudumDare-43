using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour {

    [SerializeField] private float power;
    [SerializeField] private float torque;


    private Rigidbody rb;
    private float distToGround;
	// Use this for initialization
	void Start () {
        distToGround = transform.position.y;
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (IsGrounded())
        {
            Debug.Log("HERE");
            rb.AddForce(transform.forward * power * Input.GetAxis("Vertical"));
            rb.AddTorque(transform.up * torque * Input.GetAxis("Horizontal"));
        }
	}

    private bool IsGrounded()
    {
        if(transform.position.y <= distToGround)
        {
            return true;
        }
        return false;
    }
}
