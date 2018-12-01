using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactrerControllerScript : Player{


    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;

    private Vector3 dest;
    private bool moving;
    private CharacterController controller;
    private Vector3 moveDirection;
    private float distance;

	void Start () {
        controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
            // We are grounded, so recalculate
            // move direction directly from axes

        if (moving)
        {
            distance = Vector3.Distance(dest, transform.position);
            
            moveDirection = transform.TransformDirection(dest);
            Debug.Log(moveDirection + ", " + dest);
            moveDirection = dest * speed;
        }else{
            moveDirection = Vector3.zero;
        }

           
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
        if(distance < Vector3.Distance(dest, transform.position))
        {
            moving = false;
        }
    }

    override
    public void Move(Vector3 dest)
    {
        Debug.Log(dest);
        this.dest = dest;
        moving = true;
    }
}
