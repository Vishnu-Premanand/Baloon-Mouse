using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
   [SerializeField]private Transform target;
   [SerializeField]private float force;
   [SerializeField]private float rotation_Speed;

    public bool useMouse;

   [SerializeField]private Vector2 offset;
   private SpriteRenderer spriteRenderer;

   private Rigidbody2D baloon_Rigidbody;

   private void Start() {
    spriteRenderer=GetComponent<SpriteRenderer>();
    baloon_Rigidbody=target.gameObject.GetComponent<Rigidbody2D>();
    spriteRenderer.enabled=false;
   }
   private void Update() {

        if (useMouse)
        {
            MouseControls();
        }
        if (!useMouse)
        {
            TouchControl();
        }

   }

    private void TouchControl()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
        }
    }

    private void MouseControls()
    {
        if (Input.GetMouseButton(0))
        {

            Vector2 inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = inputPos + offset;
            spriteRenderer.enabled = true;
            transform.Rotate(Vector3.forward * rotation_Speed);


            if (transform.position.x < target.position.x)
            {
                baloon_Rigidbody.AddForce(Vector2.right * force);
            }
            if (transform.position.x > target.position.x)
            {
                baloon_Rigidbody.AddForce(Vector2.left * force);
            }
            if (transform.position.y < target.position.y)
            {
                baloon_Rigidbody.AddForce(Vector2.up * force);
            }
            if (transform.position.y > target.position.y)
            {
                baloon_Rigidbody.AddForce(Vector2.down * force);
            }
        }
        else
        {
            spriteRenderer.enabled = false;
            transform.Rotate(Vector3.zero);
        }
    }
}
