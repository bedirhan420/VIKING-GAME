using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DoorCloser : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // oyuncu çarparsa
        {
            door.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = false;
            enemy1.GetComponent<AIPath>().enabled=true;
            enemy2.GetComponent<AIPath>().enabled=true;
            enemy3.GetComponent<AIPath>().enabled=true;
        }
    }
}
