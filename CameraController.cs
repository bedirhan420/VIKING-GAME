using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target ;
    public float cameraSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = Vector3.Slerp(transform.position,new Vector3(target.position.x,target.position.y,transform.position.z),cameraSpeed);
    }
}
