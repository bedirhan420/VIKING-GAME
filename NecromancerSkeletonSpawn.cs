using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerSkeletonSpawn : MonoBehaviour
{
    // Start is called before the first frame update public Animator animator;
    public Animator anim;

    public float spawnInterval = 10f;
    public float moveSpeed = 5f;

    [SerializeField] private GameObject[] skeletons;
    public float delay;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject step;
    public int teleport=0;

    Enemy enemy;

    private float lastSpawnTime;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        // Belirli aralıklarla nesne oluşturma
        if (Time.time - lastSpawnTime >= spawnInterval)
        {
            lastSpawnTime = Time.time;
            if (enemy.currentHealth > 0)
            {
                anim.SetTrigger("Spawn");
                Invoke("SpawnObject", delay);
            }


        }
        if (enemy.currentHealth <= 0)
        { 
            
            Invoke("SpawnObject", 4f);
            step.SetActive(true);
        }
    }

    private void SpawnObject()
    {
        skeletons[Findskeleton()].transform.position = spawnPoint.position;
        skeletons[Findskeleton()].GetComponent<Skeleton>().SetDirection(Mathf.Sign(transform.localScale.x));
        Invoke("Disableskeleton", 2f);
    }
    private int Findskeleton()
    {
        for (int i = 0; i < skeletons.Length; i++)
        {
            if (skeletons[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    public void Disableskeleton()
    {
        skeletons[Findskeleton()].SetActive(false);
    }

}
