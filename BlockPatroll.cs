using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPatroll : MonoBehaviour
{
       
    public Transform pointA; // hareketin başlangıç noktası
    public Transform pointB; // hareketin bitiş noktası
    public float speed = 1f; // hareket hızı

    private Vector3 targetPosition; // hedef pozisyon

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == pointB.position)
        {
            targetPosition = pointA.position;
        }
        else if (transform.position == pointA.position)
        {
            targetPosition = pointB.position;
        }
    }

}
