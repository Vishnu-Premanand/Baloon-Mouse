using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
   [SerializeField]private Transform target;
   [SerializeField] private Joystick joystick;
   [SerializeField]private float force;
   [SerializeField]private float rotation_Speed;
   [SerializeField] private float move_Speed;
   [SerializeField] private float max_XPos;

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
            JoyStickControl();
        }
        if (transform.position.x >= max_XPos)
        {
            transform.position = new Vector3(max_XPos, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -max_XPos)
        {
            transform.position = new Vector3(-max_XPos, transform.position.y, transform.position.z);
        }

    }

    private void JoyStickControl()
    {
        spriteRenderer.enabled = true;
        float horiMove = joystick.Horizontal;
        float vertiMove = joystick.Vertical;
        
        if (horiMove > 0.5f|| horiMove < -0.5f || vertiMove > 0.5f || vertiMove < -0.5f)
        {
            Vector3 move = new Vector3(horiMove, vertiMove, 0);
            
            transform.Translate(move_Speed * move * Time.deltaTime);
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
