using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform tf;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator;

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public float movementSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal") * movementSpeed;
        float yMovement = Input.GetAxis("Vertical") * movementSpeed;
        rb2d.velocity = new Vector2(xMovement, rb2d.velocity.y);
        rb2d.velocity = new Vector2(rb2d.velocity.x, yMovement);
        if (xMovement > 0)
        {
           // RIGHT
            animator.Play("PlayerWalkRight");
        }
        else if (xMovement < 0)
        {
           // LEFT
            animator.Play("PlayerWalkLeft");
        }
        else if (yMovement > 0)
        {
            // UP
            animator.Play("PlayerWalkUp");
        }
        else if (yMovement < 0)
        {
            // DOWN
            animator.Play("PlayerWalkDown");
        }
        else if (yMovement > 0 && xMovement > 0)
        {
            // UP RIGHT
            animator.Play("PlayerWalkUpRight");
        }
        else if (yMovement < 0 && xMovement > 0)
        {
            // DOWN RIGHT
            animator.Play("PlayerWalkDownRight");
        }
        else if (yMovement < 0 && xMovement < 0)
        {
            // DOWN LEFT
            animator.Play("PlayerWalkDownLeft");
        }
        else if (yMovement > 0 && xMovement < 0)
        {
            // UP LEFT
            animator.Play("PlayerWalkUpLeft");
        }
        else
        {
            animator.Play("PlayerIdle");
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health == 0)
        {
            SceneManager.LoadScene(sceneName: "GameOver");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
