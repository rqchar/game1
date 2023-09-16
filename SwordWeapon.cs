using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack = 2f;
    float timer;

    [SerializeField] GameObject leftSwordObject;
    [SerializeField] GameObject rightSwordObject;

    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            Attack();
        }
    }
    private void Attack()
    {
        Debug.Log("Attack");
        timer = timeToAttack;

        if(playerMovement.lastHorizontalVector < 0f)
        {
            leftSwordObject.SetActive(true);
        }
        else
        {
            rightSwordObject.SetActive(true);
        }
    }
}
