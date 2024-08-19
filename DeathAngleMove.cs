using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAngleMove : MonoBehaviour
{
     [Header("Patrol Points")]
    [SerializeField] private Transform topEdge;
    [SerializeField] private Transform bottomEdge;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;

    private bool movingUp = true;

    private void Update()
    {
        if (movingUp)
        {
            MoveInDirection(Vector2.up);

            if (transform.position.y >= topEdge.position.y)
            {
                transform.localScale=new Vector3(-7,-7,1);
                movingUp = false;
            }
        }
        else
        {
            MoveInDirection(Vector2.down);

            if (transform.position.y <= bottomEdge.position.y)
            {
                transform.localScale=new Vector3(7,7,1);
                movingUp = true;
            }
        }
    }

    private void MoveInDirection(Vector2 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

}
