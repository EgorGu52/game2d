using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float attackCooldown;
    public Transform firePoint;
    public GameObject[] fireBalls;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && PlayerMovement.CanAttack())
        {
            Attack();
            cooldownTimer = cooldownTimer + Time.deltaTime;
        }
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }
    private int FindFireBall()
    {
        for (int i = 0; i < fireBalls.Length; i++)
            if (!fireBalls[i].activeInHierarchy)
            {
                return i;
            }
        return 0;
    }
}
