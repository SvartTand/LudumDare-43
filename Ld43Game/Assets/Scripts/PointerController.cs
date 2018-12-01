using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour {

    [SerializeField] private Camera cam;

    public Player selectedPlayer;
    private bool mouseOnPlayer;

    void Start()
    {
 
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    mouseOnPlayer = true;
                    selectedPlayer = hit.collider.gameObject.GetComponent<Player>();
                    Debug.Log("pressed");
                }
            }


        }

        if (Input.GetMouseButtonUp(0))
        {
            if (mouseOnPlayer)
            {
                mouseOnPlayer = false;
                RaycastHit hit;
                var ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 movement = transform.position - hit.point;
                    movement.y = 0;
                    selectedPlayer.Move(hit.point);
                }
            }

        }



    }
}
