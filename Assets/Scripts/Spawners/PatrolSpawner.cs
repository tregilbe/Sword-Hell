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

    public GameObject skeletonPrefab;
    public GameObject warriorSkeletonPrefab;
    public GameObject demonPrefab;

    int enemyNumber;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.spawnersList.Add(this.gameObject);

        skeletonPrefab = GameManager.instance.skeletonPrefab;
        warriorSkeletonPrefab = GameManager.instance.warriorSkeletonPrefab;
        demonPrefab = GameManager.instance.demonPrefab;

        enemyNumber = Random.Range(1, 6);

        if (enemyNumber <= 2 && enemyNumber >= 0)
        {
            Prefab = skeletonPrefab;
        }
        else if (enemyNumber <= 4 && enemyNumber >= 2.1)
        {
            Prefab = warriorSkeletonPrefab;
        }
        else if (enemyNumber <= 6 && enemyNumber >= 4.1)
        {
            Prefab = demonPrefab;
        }
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
            GameManager.instance.spawnersList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
