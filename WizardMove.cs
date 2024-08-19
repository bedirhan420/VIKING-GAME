using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMove : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Patrol Points")]
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform leftEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header ("Movement Parameters")]
    [SerializeField] private float speed;

     [Header ("Idle Behaivour")]
     [SerializeField] private float idleDuration;
     private float idleTimer;

    private bool movingLeft;

    private Vector3 initScale;

    [SerializeField] private Animator animator;
     private void Awake() 
    {
        initScale = enemy.localScale;
        animator = GetComponent<Animator>();
        
    }
    private void Start() {
        if (enemy.localScale.x<0)
        {
            movingLeft=true;
        }
    }

    private void OnDisable() 
    {
        animator.SetBool("isMove",false);
    }

    private void Update()
    {
        if (movingLeft)
        {   
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                //yön değiştir
                Flip();
            }
            
        }
        else
        {    
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                //yön değiştir
                Flip();
            }
            
        }
        
    }

     private void Flip()
    {
        animator.SetBool("isMove",false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }
        
    }

    
    private void MoveInDirection(int _direction)
    {   
        idleTimer =0;
        animator.SetBool("isMove",true);
        //düşmanın yüzünün yönü
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x)*_direction,initScale.y,initScale.z);
        //düşmanın hareketinin yönü
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction *speed,enemy.position.y ,enemy.position.z );
    }

}
