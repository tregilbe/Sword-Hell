using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player;
    public GameObject skeletonPrefab;
    public GameObject demonPrefab;
    public GameObject deathPillarPrefab;
    public static GameManager instance;
    public List<GameObject> enemiesList = new List<GameObject>();
    public GameObject[] enemyPrefabs;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogError(message: "I tried to create a second game manager.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
        Instantiate(playerPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Respawn()
    {
        player = Instantiate(playerPrefab);
    }

}
