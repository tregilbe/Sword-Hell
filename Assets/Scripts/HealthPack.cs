using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HealthPack : MonoBehaviour
{
    public GameObject player;
    public int healthBack;

    public AudioSource audioSource;
    public AudioClip pickup;

    public GameObject soundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        soundPlayer = GameObject.FindGameObjectWithTag("Sound");

        audioSource = soundPlayer.GetComponent<AudioSource>();
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
            audioSource.clip = pickup;
            audioSource.Play();

            Heal();
        }
    }

    public void Heal()
    {
        player.GetComponent<PlayerController>().health += healthBack;
        Destroy(gameObject);
    }
}
