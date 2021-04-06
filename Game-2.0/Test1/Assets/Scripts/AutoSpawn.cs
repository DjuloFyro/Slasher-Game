 using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AutoSpawn : MonoBehaviour
{
    public Transform Player;
    public Ennemi PrefabToSpawn;
    //public Transform ZoneDeSpawn;

    public float SpawnRate = 3f;
    private float NextSpawn;

    

    public Ennemi enemy;
    private List<Ennemi> enemies;
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

    
    void Update()
    {
        enemies = new List<Ennemi>(); // init as type

        //Random Spawn
        


        int num = Random.Range(0, 2);
        if (num == 0)
        {
           pos = new Vector3(Random.Range(SpawnBottomLeft.position.x , SpawnTopLeft.position.x ), Random.Range(SpawnBottomLeft.position.y , SpawnTopLeft.position.y ), 0);
        }
        else if(num == 1)
        {
            pos = new Vector3(Random.Range(SpawnBottomRight.position.x, SpawnTopRight.position.x), Random.Range(SpawnBottomRight.position.y, SpawnTopRight.position.y), 0);
        }
        transform.position = pos;

       

        for (int index = 0; index < numberOfEnemies; index++)
        {
            if (Time.time > NextSpawn)
            {
                
                NextSpawn = Time.time + SpawnRate;
                Ennemi spawned = Instantiate(enemy, pos, Quaternion.identity) as Ennemi;
                enemies.Add(spawned);
                
            }

        }
        
            /*foreach (Ennemi en in enemies) 
            {
                en.UpdatePath();
                en.FixedUpdate();
            }*/

        
      /* if (Time.time > NextSpawn)
         {
             NextSpawn = Time.time + SpawnRate;

             
             Instantiate(PrefabToSpawn, transform.position, Quaternion.identity);

          
         }*/
    }
}
