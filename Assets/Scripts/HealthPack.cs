using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public GameObject player;
    public int healthBack;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && player.GetComponent<PlayerController>().health < 10)
        {
            Heal();
        }
    }

    public void Heal()
    {
        player.GetComponent<PlayerController>().health += healthBack;
        Destroy(gameObject);
    }
}
