using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDash : MonoBehaviour

{
    // Start is called before the first frame update
    
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer regularrender;
    public SpriteRenderer sliderender;
    public BoxCollider2D regularColl;
    public BoxCollider2D slideColl;
    private bool isSliding=false;

    public float slideSpeed=8f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.LeftShift))
        {
            PerformSlide();
        }
     
    }
    private void PerformSlide(){
        isSliding=true;
        animator.SetTrigger("slider");
        regularrender.enabled=false;
        regularColl.enabled=false;
        slideColl.enabled=true;
        sliderender.enabled=true;

        if (transform.localScale.x>0)
        {
            rb.AddForce(Vector2.right*slideSpeed);
        }
         if (transform.localScale.x<0)
        {
            rb.AddForce(Vector2.left*slideSpeed);
        }
         StartCoroutine("stopSlide");
    }

    IEnumerator stopSlide(){
        yield return new WaitForSeconds(1f);
        animator.Play("MainCharIdle");
        animator.SetBool("isSlide",false);

        regularColl.enabled=true;
        regularrender.enabled=true;
        slideColl.enabled=false;
        sliderender.enabled=false;

        isSliding=false;
    }
}
