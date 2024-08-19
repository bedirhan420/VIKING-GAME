using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer;
    [SerializeField] private Animator anim;
    private Health playerHealth;
    public bool isBigSkeleton;
    public bool isNecromancerAttack;
    public float dmgdelay;
    public float yOffset;
    private RaycastHit2D hit;

    public bool isWingDemon;

    private void Start()
    {
        if (isBigSkeleton)
        {
            attackCooldown = 2;
            cooldownTimer = -5;
        }
        else if (isNecromancerAttack)
        {
            attackCooldown = 2;
            cooldownTimer = -5;
        }
        else
        {
            attackCooldown=1;
            cooldownTimer = Mathf.Infinity;
        }
    }
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                if (isNecromancerAttack)
                {
                    anim.SetTrigger("Spawn");

                }
                else
                {
                    anim.SetTrigger("Attack");
                }


                DamagePlayer();
                if (isBigSkeleton)
                {
                    cooldownTimer = -2;
                }
                else if (isNecromancerAttack)
                {
                    cooldownTimer = -6;
                }
                else
                {
                    cooldownTimer = 0;
                }


            }
        }
    }

    private bool PlayerInSight()
    {
        if (isBigSkeleton || isWingDemon)
        {   
            Vector3 gizmosCenter = boxCollider.bounds.center + new Vector3(0, yOffset, 0);

            hit = Physics2D.BoxCast(gizmosCenter + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        }
       

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (isBigSkeleton || isWingDemon)
        {
            Vector3 gizmosCenter = boxCollider.bounds.center + new Vector3(0, yOffset, 0);

            Gizmos.DrawWireCube(gizmosCenter + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
        }
        else
        {
            Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
        }
    }
    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }

}
