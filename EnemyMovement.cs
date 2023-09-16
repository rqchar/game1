using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Transform targetDestination;
    [SerializeField] Transform enemyDestination;
    GameObject targetGameObject;

    public Rigidbody2D rb;
    public Animator animator;

    private bool faceRight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        targetGameObject = targetDestination.gameObject;
    }

    void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
        ReflectEnemy();
    }

    void ReflectEnemy()
    {
        if ( enemyDestination.position.x > targetDestination.position.x && faceRight == false ||
            enemyDestination.position.x < targetDestination.position.x && faceRight == true)
        {

            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;

            faceRight = !faceRight;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        } 
    }
    private void Attack()
    {
        //Debug.Log("Attack");
    }
}
