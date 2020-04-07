using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float waitTime;
    public float startWaitTime;

    public Transform player;
    public Rigidbody2D rb;
    private Animator animator;

    public Transform[] moveSpots;
    private int randomSpot;

    public bool isPatrolling = false;
    public bool isChasing = false;

    public int health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        GameManager.instance.enemiesList.Add(this.gameObject);

        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        // Defines target
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // Tracks health, destroys if 0
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (isPatrolling == true)
        {
            Patrol();
        }else if (isChasing == true)
        {
            Chase();
        }
        else
        {
            Idle();
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
    void Patrol()
    {
        //Patrol
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }
    void Chase()
    {
        // Chase and attack
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
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
    void Idle()
    {
        animator.Play("WarriorIdle");
    }
}
