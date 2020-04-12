using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolSpawner : MonoBehaviour
{
    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

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
    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
            enemy = (GameObject)Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
            enemy.GetComponent<Enemy>().moveSpot = moveSpot;
            enemy.GetComponent<Enemy>().minX = minX;
            enemy.GetComponent<Enemy>().maxX = maxX;
            enemy.GetComponent<Enemy>().minY = minY;
            enemy.GetComponent<Enemy>().maxY = maxY;
            enemy.GetComponent<Enemy>().isPatrolling = true;
            Destroy(this.gameObject);
        }
    }
}
