using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{
    [SerializeField] private float max_XPos;

    private void Update()
    {
        if (transform.position.x >= max_XPos)
        {
            transform.position=new Vector3(max_XPos,transform.position.y,transform.position.z);
        }
        if (transform.position.x <= -max_XPos)
        {
            transform.position = new Vector3(-max_XPos, transform.position.y, transform.position.z);
        }
    }
}
