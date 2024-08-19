using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DoorOpenButon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    public GameObject enemy;
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // oyuncu çarparsa
        {
            door.SetActive(false);
        
            enemy.GetComponent<AIPath>().enabled=true;
  
        }
    }
    
}
