using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerfollow : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float stoppingDistance = 1f;
    public float startFollowDistance = 10f;
    public int scale;

    public bool isCrossWall = false;

    private bool isWallTimerActive = false;

    public Animator anim;

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= startFollowDistance)
            {
                Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);

                if (targetPosition.x > transform.position.x + stoppingDistance)
                {
                    // Oyuncu düşmanın sağında olduğunda sağa doğru hareket et
                    anim.SetBool("isMove", true);


                    if (!isCrossWall)
                    {
                        anim.SetBool("isMove", true);
                        transform.localScale = new Vector3(scale, scale, 1);

                        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                    }


                    else
                    {
                        anim.SetBool("isMove", true);
                        transform.localScale = new Vector3(-scale, scale, 1);

                        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                    }
                }
                else if (targetPosition.x < transform.position.x - stoppingDistance)
                {
                    // Oyuncu düşmanın solunda olduğunda sola doğru hareket et
                    anim.SetBool("isMove", true);

                    if (!isCrossWall)
                    {
                        anim.SetBool("isMove", true);
                        transform.localScale = new Vector3(-scale, scale, 1);

                        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                    }


                    else
                    {
                        anim.SetBool("isMove", true);
                        transform.localScale = new Vector3(scale, scale, 1);

                        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                    }

                }
                else
                {
                    anim.SetBool("isMove", false);
                }
            }
            else
            {
                anim.SetBool("isMove", false);
            }

           
        }
        if (isWallTimerActive)
        {
            StartCoroutine(ResetIsCrossWallAfterSeconds(5f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isCrossWall = true;
            isWallTimerActive = true;
        }
    }

    private IEnumerator ResetIsCrossWallAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isCrossWall = false;
        isWallTimerActive = false;
    }




}
