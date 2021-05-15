 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class AutoSpawn : MonoBehaviour
{
    public Transform Player;
    public Ennemi PrefabToSpawn;
    //public Transform ZoneDeSpawn;

    public float SpawnRate = 3f;
    private float NextSpawn;

    

    public GameObject enemy;
    public List<GameObject> enemies;
    public int numberOfEnemies = 2;

    
    //Variable random Spawn
    public Vector3 center;
    public Vector3 size;

    public Transform SpawnBottomLeft;
    public Transform SpawnBottomRight;
    public Transform SpawnTopLeft;
    public Transform SpawnTopRight;
    
    private Vector3 pos;

    //Animation
    private Animator anim;

    public GameObject spawned;

    public static AutoSpawn instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("trop d'instance AutoSpawn samer");
            return;
        }
        instance = this;
    }

    void Start()
    {

        /*enemies = new List<GameObject>(); // init as type

        if (Time.time > NextSpawn)
        {
            NextSpawn = Time.time + SpawnRate;

            for (int index = 0; index < numberOfEnemies; index++)
            {

                GameObject spawned = Instantiate(enemy, transform.position, Quaternion.identity) as GameObject;
                enemies.Add(spawned);

            }
        }*/

        anim = GetComponent<Animator>();
    }

    void SpawningEnemy()
    {
        enemies = new List<GameObject>(); // init as type

        //Random Spawn



        int num = Random.Range(0, 2);
        if (num == 0)
        {
            pos = new Vector3(Random.Range(SpawnBottomLeft.position.x, SpawnTopLeft.position.x), Random.Range(SpawnBottomLeft.position.y, SpawnTopLeft.position.y), 0);
        }
        else if (num == 1)
        {
            pos = new Vector3(Random.Range(SpawnBottomRight.position.x, SpawnTopRight.position.x), Random.Range(SpawnBottomRight.position.y, SpawnTopRight.position.y), 0);
        }
        transform.position = pos;



        for (int index = 0; index < numberOfEnemies; index++)
        {
            if (Time.time > NextSpawn)
            {

                NextSpawn = Time.time + SpawnRate;
                spawned = (GameObject) Instantiate(enemy, pos, Quaternion.identity) as GameObject;
                enemies.Add(spawned);

               
            }

        }
    }
    
    void Update()
    {
        SpawningEnemy();


        /*if (GameOverManager.instance.playerIsDead)
        {

            
            foreach (var en in enemies)
            {

                Destroy(en);
            }

        }*/
        /*else
        {
            foreach (GameObject eni in enemies)
            {

                DontDestroyOnLoad(eni);
            }
            
        }*/

       
    }
}
