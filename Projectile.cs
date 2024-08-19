using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    private bool hit;
    private float direction;
    private BoxCollider2D boxCollider;
    public int attackDamage = 20;
    public float delay;
    

    private void Awake() {
        boxCollider=GetComponent<BoxCollider2D>();
        gameObject.SetActive(true);
    }
    private void Update() {
        if (hit) return;
        float movementSpeed = speed*Time.deltaTime*direction; 
        transform.Translate(movementSpeed,0,0);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        hit=true;
        boxCollider.enabled=false;
        gameObject.SetActive(false);
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    public void SetDirection(float _direction){
        direction=_direction;
        gameObject.SetActive(true);
        hit=false;
        boxCollider.enabled=true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX)!=_direction)
        {
            localScaleX=-localScaleX;
        }
        transform.localScale=new Vector3(localScaleX,transform.localScale.y,transform.localScale.z);
    }
    private void Deactiveate(){
        gameObject.SetActive(false);
    }

}
