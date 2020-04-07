using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public Transform player;
    public Rigidbody2D rb;
    private Animator animator;

    

    public int health;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        GameManager.instance.enemiesList.Add(this.gameObject);
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
    
        if (transform.position.x < player.position.x)
        {
            animator.Play("WarriorWalkRight");
        }
        else if (transform.position.x > player.position.x)
        {
            animator.Play("WarriorWalkLeft");
        }
        else if (transform.position.y < player.position.y)
        {
            animator.Play("WarriorWalkUp");
        }
        else if (transform.position.y > player.position.y)
        {
            animator.Play("WarriorWalkDown");
        }
        else
        {
            animator.Play("WarriorIdle");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    void OnDestroy()
    {
        GameManager.instance.enemiesList.Remove(this.gameObject);
    }
}
