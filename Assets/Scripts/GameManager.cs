using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player;
    public GameObject SpawnPointLevel1obj;
    public Transform SpawnPointLevel1;
    public GameObject skeletonPrefab;
    public GameObject warriorSkeletonPrefab;
    public GameObject demonPrefab;
    public GameObject deathPillarPrefab;
    public static GameManager instance;
    public List<GameObject> enemiesList = new List<GameObject>();
    public List<GameObject> spawnersList = new List<GameObject>();
    public List<GameObject> commonEnemiesList = new List<GameObject>();
    public GameObject[] enemyPrefabs;

    public int currentScene = 0;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
    public void StartLevel01()
    {
        SpawnPointLevel1obj = GameObject.FindGameObjectWithTag("PlayerSpawn");
        SpawnPointLevel1 = SpawnPointLevel1obj.GetComponent<Transform>();
        Instantiate(playerPrefab, SpawnPointLevel1.position, SpawnPointLevel1.rotation);
    }

    public void LoadLevel(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
        // Potentially Dangerous
        currentScene++;
    }

    public void loadLevel(int indexToLoad)
    {
        SceneManager.LoadScene(indexToLoad);
        currentScene = indexToLoad;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene += 1);
    }
}
