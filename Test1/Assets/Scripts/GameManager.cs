using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    [SerializeField]
    private Transform player;

    private Transform playerInstanciate;

    private Player playerScript;

    public Transform PlayerInstanciate { get { return playerInstanciate; } }

    [SerializeField]
    private Transform SpawnPoint;


   



    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        InstanciatePlayer();
      
    }

    

    void Start()
    {
        
    }

    private void InstanciatePlayer()
    {
        playerInstanciate = Instantiate(player, SpawnPoint.position, Quaternion.identity);

        playerScript = playerInstanciate.GetComponent<Player>();

        playerScript.MonEvent += PlayerScript_MonEvent;
    }

  

    private void PlayerScript_MonEvent()
    {
        Destroy(playerInstanciate.gameObject);

        StartCoroutine(RespawnPlayer());
    }


    private IEnumerator RespawnPlayer()
    {
        Debug.Log("3");

        yield return new WaitForSeconds(1);

        Debug.Log("2");

        yield return new WaitForSeconds(1);

        Debug.Log("1");

        yield return new WaitForSeconds(1);

        InstanciatePlayer();
    }

    void Update()
    {
        
    }
}
