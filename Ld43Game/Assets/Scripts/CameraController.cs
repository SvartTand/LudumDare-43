using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    private bool shake;

    private float shakeDuration = 0;
    private float shakeAmount = 0.7f;
    private float decreaseFactor = 1;

    private Vector3 originalPos;

    //public Texture2D cursorTexture;


    void Start()
    {
        offsetPosition = transform.position - target.position;
        //Cursor.SetCursor(cursorTexture,Vector2.zero,CursorMode.Auto);
    }

    private void Update()
    {
        Refresh();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shake(0.9f, 0.1f, 1);
        }

        if (shake)
        {
            ShakeUpdate();
        }
        
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }

    private void ShakeUpdate()
    {
        originalPos = transform.localPosition;
        if(shakeDuration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = false;
        }

    }

    public void Shake(float amount, float duration, float decrese)
    {
        shake = true;
        shakeAmount = amount;
        shakeDuration = duration;
        decreaseFactor = decrese;
    }


}
