using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    public NecromancerSkeletonSpawn Script { get; private set; }

    public float speedAmount =8f;
    public float jumpAmount =8f;
    public Animator animator;
    private float cooldownTimer =Mathf.Infinity;
    [SerializeField] private float attackCooldown;
    
    
    
    public Transform attackPoint;
    public Transform icePoint;
    
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;

    

    
    


    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         Script=GetComponent<NecromancerSkeletonSpawn>();
       
    }
   
    // Update is called once per frame
    private void FixedUpdate() {
         float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speedAmount,rb.velocity.y);

        animator.SetFloat("Speed",Mathf.Abs(Input.GetAxis("Horizontal")));

        //sağa sola giderken karakterin dönmesi için
        if(horizontalInput>0.01f)
        {
            transform.localScale = new Vector3(5,5,1);
         

        }
        else if(horizontalInput<-0.01f)
        {
            transform.localScale = new Vector3(-5,5,1);


        }
    }
    void Update()
    {
        //mathfApproximately eşitlerse 1 değillerse 0 döndürür
        //burda rbnin y eksenindeki hızı 0sa ve space basılıyosa kuvvet uyguluyo ve isjumpingi true yapıyo
        if(Input.GetButtonDown("Jump") && Mathf.Approximately(0f,rb.velocity.y))
        {
            rb.AddForce(Vector3.up * jumpAmount,ForceMode2D.Impulse);
            animator.SetBool("isJumping",true);
        }  
        //isjumping trueysa ve rbnin y eksenindeki hızı 0sa isjumpingi false yapıyo
        if(animator.GetBool("isJumping") && Mathf.Approximately(0f,rb.velocity.y))
        {
            animator.SetBool("isJumping",false);
        }
         if(Input.GetKeyDown(KeyCode.X))
        {
          Attack(); 
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
                IceKickAttack(); 
               
            
            
        }
        
        cooldownTimer+=Time.deltaTime;
        Debug.Log(Script.teleport);
        

    }
    
    void Attack()
    {
        animator.SetTrigger("Attack"); 
         Collider2D[] hitEnemies =Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        
        foreach (Collider2D enemy in hitEnemies)
        {
           enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(attackDamage);
        }
        if (collision.tag=="Finish")
        {
            rb.velocity=Vector2.zero; 
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }

    void IceKickAttack(){
        animator.SetTrigger("IceKickAttack");
        if ( transform.localScale == new Vector3(5,5,1))
        {
             transform.position+=new Vector3(10,0,0);
        }
        else if ( transform.localScale == new Vector3(-5,5,1))
        {
             transform.position+=new Vector3(-10,0,0);
        }
       
    }
   

}
