using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHandler : MonoBehaviour {

    public Camera cam;
    public Transform player;
    private LineRenderer lRenderer;

    private Color c1 = Color.red;
    private Color c2 = new Color(1, 1, 1, 0);

    public void Start()
    {
        lRenderer = gameObject.AddComponent<LineRenderer>();
        lRenderer.SetWidth(0.2f, 0.2f);
        lRenderer.enabled = false;

        lRenderer.material = new Material(Shader.Find("Sprites/Default"));
        //_lineRenderer.SetColors(c1, c2);
        lRenderer.startColor = c1;
        lRenderer.endColor = c2;


    }

    private Vector3 _initialPosition;
    private Vector3 _currentPosition;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _initialPosition = player.position;
            lRenderer.SetPosition(0, _initialPosition);
            lRenderer.SetVertexCount(1);
            lRenderer.enabled = true;
        }
        else if (Input.GetMouseButton(0))
        {


            _currentPosition = GetCurrentMousePosition().GetValueOrDefault();
            _currentPosition.y = player.position.y;
            lRenderer.SetVertexCount(2);
            lRenderer.SetPosition(1, _currentPosition);
            lRenderer.SetPosition(0, player.position);

            c1.g = c1.g + Vector3.Distance(lRenderer.GetPosition(1), lRenderer.GetPosition(0)) * 6;
            lRenderer.startColor = c1;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            lRenderer.enabled = false;
            var releasePosition = GetCurrentMousePosition().GetValueOrDefault();
            var direction = releasePosition - _initialPosition;
            direction.y = 0;
            Debug.Log("Process direction " + direction);
        }
    }

    private Vector3? GetCurrentMousePosition()
    {
        RaycastHit hit;
        var ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;

        }



        return null;
    }
}
