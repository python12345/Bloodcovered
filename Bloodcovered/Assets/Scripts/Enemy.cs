using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        Debug.Log("enemy died!");

        //Die Animation
        animator.SetTrigger("Die");

        //Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
