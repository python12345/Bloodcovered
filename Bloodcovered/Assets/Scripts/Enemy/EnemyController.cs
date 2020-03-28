using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            PlayerController player = col.gameObject.GetComponent<PlayerController>();
            float attackTime = Random.Range(0.5f, 1.5f);
            StartCoroutine(AttackCoroutine(attackTime, player));
        }
    }

    IEnumerator AttackCoroutine(float timeToWait, PlayerController player)
    {
        yield return new WaitForSeconds(timeToWait);
        player.Death();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            _animator.SetBool("Alert", true);
            Debug.Log("Detected collision with player - detection collider");
        }
    }

    public void Death()
    {
        Destroy(this.gameObject);
        Debug.Log("Enemy dead");
    }
}
