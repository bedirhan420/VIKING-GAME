using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    // Start is called before the first frame update
    private float vertical;
    public float climbSpeed;

    private bool isLadder;
    private bool isClimbing;
    public Animator anim;
    [SerializeField] private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }
    private void FixedUpdate()
    {
        if (isClimbing && Input.GetKey(KeyCode.UpArrow))
        {
            rb.gravityScale = 0f;
            anim.SetBool("isClimbing", true);
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbSpeed);
        }
        else
        {
            anim.SetBool("isClimbing", false);
            rb.gravityScale = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            isLadder = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
