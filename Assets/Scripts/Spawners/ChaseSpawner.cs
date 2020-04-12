using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseSpawner : MonoBehaviour
{
    public GameObject enemy;

    public Transform SpawnPoint;
    public GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
            enemy = (GameObject)Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
            enemy.GetComponent<Enemy>().isChasing = true;
            Destroy(this.gameObject);
        }
    }
}
