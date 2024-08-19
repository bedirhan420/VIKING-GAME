using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float startingHealth;
    [SerializeField] public Transform viking;
    public float timeRemaining = 10;
    public float currentHealth{get;private set;}
    private Animator animator;
    private bool isDead;
    public float deathTime;


    private void Awake() 
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

     public void TakeDamage(float _damage)
    {   
        // mathf.clamp Verilen değeri, verilen minimum kayan nokta ile maksimum kayan nokta değerleri arasına sıkıştırır.
        // Minimum ve maksimum aralık içindeyse verilen değeri döndürür.
        //anlık can ile hasar farkını 0 ile başlangıç can arasında tutmak için.
        currentHealth = Mathf.Clamp(currentHealth-_damage,0,startingHealth);
        
        if (currentHealth > 0)
        {
            //karakter hasar alır.
            animator.SetTrigger("Hurt");
    
        }
        else
        {   
            if (!isDead)
            {
               //karakter ölür.
               animator.SetTrigger("Death");
               Invoke("DestroyCharacter",0.2f);

               //viking
               GetComponent<Move>().enabled=false; 
               //düşman
               
               GetComponent<DBAttack>().enabled=false;
    
               isDead = true;
               
            }
            
        }
    }

    public void Healing(float _healPoint){
        if (currentHealth<startingHealth)
        {
            currentHealth = Mathf.Clamp(currentHealth+_healPoint,0,startingHealth);
        }
    }   
     public void DestroyCharacter(){
        Destroy(gameObject);
    }
    private void GameOver(){

    }
}
