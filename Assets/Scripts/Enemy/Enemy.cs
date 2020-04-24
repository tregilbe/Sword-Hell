using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float waitTime;
    public float startWaitTime;

    public GameObject healthPackPrefab;

    public Transform player;
    public Rigidbody2D rb;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    public bool isPatrolling = false;
    public bool isChasing = false;

    public int health;
    public HealthBar healthBar;

    public int healthDrop;

    public GameObject soundPlayer;

    public AudioSource audioSource;
    public AudioSource deathSound;
    public AudioClip hit;
    public AudioClip dead;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager.instance.enemiesList.Add(this.gameObject);

        waitTime = startWaitTime;

        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        healthBar.SetMaxHealth(health);
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
        }
        else if (isChasing == true)
        {
            Chase();
        }
        else
        {
            Idle();
        }

        soundPlayer = GameObject.FindGameObjectWithTag("Sound");

        deathSound = soundPlayer.GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        // play hit sound here
        audioSource.clip = hit;
        audioSource.Play();
    }
    void OnDestroy()
    {
        deathSound.clip = dead;
        deathSound.Play();

        healthDrop = Random.Range(1, 6);

        if (healthDrop <= 3)
        {
            Instantiate(healthPackPrefab, transform.position, transform.rotation);
            GameManager.instance.enemiesList.Remove(this.gameObject);
        } else if (healthDrop >= 3.1)
        {
            GameManager.instance.enemiesList.Remove(this.gameObject);
        }
    }
    void Patrol()
    {
        //Patrol
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
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
    }
    void Idle()
    {

    }
}
