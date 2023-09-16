using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator; 

    [HideInInspector] public Vector2 movement;
    [HideInInspector] public float lastHorizontalVector;
    [HideInInspector] public float lastVerticalVector;

    private bool faceRight = true; 
    

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");  //движение по горизонтали от -1(лево) до 1(право)
        movement.y = Input.GetAxisRaw("Vertical");    //движение по вертикали от -1(низ) до 1(вверх)

        if(movement.x != 0)
        {
            lastHorizontalVector = movement.x;
        }
        if(movement.y != 0)
        {
            lastVerticalVector = movement.y;
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        

        ReflectPlayer();
    }
    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void ReflectPlayer()
    {
        if(movement.x > 0 && faceRight == false ||
            movement.x < 0 && faceRight == true)
        {
            
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;

            faceRight = !faceRight;
        }
    }
}
