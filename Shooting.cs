using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Animator animator;
    [SerializeField] private GameObject[] bullets;
    public float delay;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private Transform firePoint;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {


            animator.SetTrigger("ShieldShoot");


            Invoke("Shoot", delay);


        }





    }
    void Shoot()
    {

        cooldownTimer = 0;

        bullets[FindBullet()].transform.position = firePoint.position;

        bullets[FindBullet()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));




        Invoke("DisableBullet", 1.0f);

    }

    private int FindBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (bullets[i].activeInHierarchy)
            {
                return i;
            }

        }
        return 0;
    }

    public void DisableBullet()
    {
        bullets[FindBullet()].SetActive(false);
    }
}
