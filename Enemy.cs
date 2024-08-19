using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isHurt;
    public bool isNecromancer;
    public int maxHealth=100;
    public float delay;
    public float deathdelay;
    public int currentHealth;

    private Animator anim;

    public bool isDemon;

    public GameObject step;
    public GameObject ladder;

    public GameObject obelisk;
    
    void Start()
    {
        currentHealth=maxHealth;
        anim=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    public void TakeDamage(int damage){
        currentHealth-=damage;
        if (isHurt)
        {
            anim.SetTrigger("Hurt");
        }
        

        if (currentHealth<=0)
        {
            Die();

            
            if (isNecromancer)
            {
                Invoke("DestroyEnemy",deathdelay);
            }
            else
            {
                Invoke("DestroyEnemy",delay);
            }
            if (isDemon)
            {
                step.SetActive(true);
                ladder.SetActive(true);
                obelisk.SetActive(true);
            }
        }
    }

    public void Die(){
        anim.SetTrigger("Die");

    }
    public void DestroyEnemy(){
        Destroy(gameObject);
    }
}
