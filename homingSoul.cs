using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingSoul : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    public float rootatingSpeed = 200;
    public GameObject target;
    public float followDistance = 5f;  // Takip mesafesi
    private float elapsedTime = 0f;
    private bool isFollowing = false;

    Rigidbody2D rb;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
{
    // Takip durumu kontrolü
    if (isFollowing)
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 5f)
        {
            // 5 saniye geçtiğinde düşmanı yok et veya devre dışı bırak
            Destroy(gameObject); // Düşmanı yok etmek
            // veya enemy.gameObject.SetActive(false); // Düşmanı devre dışı bırakmak
        }
    }
}

  

void FixedUpdate()
{
    Vector2 pointTarget = (Vector2)transform.position - (Vector2)target.transform.position;
    pointTarget.Normalize();
    float value = Vector3.Cross(pointTarget, transform.right).z;

    // Takip mesafesini kontrol et
    float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);
    bool isWithinFollowDistance = distanceToPlayer <= followDistance;

    if (isWithinFollowDistance)
    {   
        if (!isFollowing)
        {
            // Takip durumu başladı
            isFollowing = true;
            elapsedTime = 0f;
        }

        if (value > 0)
        {
            rb.angularVelocity = rootatingSpeed;
        }
        else if (value < 0)
        {
            rb.angularVelocity = -rootatingSpeed;
        }
        else
        {
            rb.angularVelocity = 0;
        }

        rb.velocity = transform.right * speed;
    }
    else
    {
        // Takip mesafesinin dışında olduğunda farklı bir davranış gerçekleştir
        // Örneğin, hareket etmeyi durdurabilir veya başka bir yöne gidebilirsin
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;

        if (isFollowing)
        {
             isFollowing = false;
            elapsedTime = 0f;
        }
    }

}

}
