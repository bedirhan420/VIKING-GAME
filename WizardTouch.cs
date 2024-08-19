using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardTouch : MonoBehaviour
{
     [SerializeField] private float damage;
     public bool isSoul;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            if (isSoul)
            {
                 Destroy(gameObject);
            }
        }
    }
}
