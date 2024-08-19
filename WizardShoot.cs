using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardShoot : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private GameObject[] bullets;
    public float delay;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private Transform firePoint;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= 3.0f)
        {
            animator.SetTrigger("Shoot");
            Invoke("Shoot",0.5f);
            cooldownTimer = 0;
        }
    }

    void Shoot()
    {
        bullets[FindBullet()].transform.position = firePoint.position;
        bullets[FindBullet()].GetComponent<WizardProjectile>().SetDirection(Mathf.Sign(transform.localScale.x));
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