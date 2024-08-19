using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSkeletonSpawner : MonoBehaviour
{
    // Start is called before the first frame updat
    public Animator anim;
   
   public Transform player;
    public GameObject enemyPrefab; 
    public Transform spawnPoint; 

    private bool hasSpawned = false;
    private void Update()
    {
    
        if (PlayerReachedDestination() && !hasSpawned)
        {  
            anim.SetTrigger("Spawn");
            SpawnEnemy();
            hasSpawned = true;
        }
    }

    private bool PlayerReachedDestination()
    {
    
        if (Mathf.Approximately(player.position.x, 600f))
        {
            return true;
        }
        return false;
    }

    private void SpawnEnemy()
    {

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
