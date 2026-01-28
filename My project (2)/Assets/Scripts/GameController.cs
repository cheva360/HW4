using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private GameObject pipeSpawn;
    [SerializeField] private Transform pipeSpawnPos;
    [SerializeField] private float spawnInterval = 2f;
    public float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval; //so it spawns immediately
    }

    // Update is called once per frame
    void Update()
    {
        //timer for every x seconds spawn pipe
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            // Spawn pipe logic here
            //Debug.Log("Spawn Pipe");
            Instantiate(pipePrefab, pipeSpawnPos.position, Quaternion.identity);
            //change pipe spawn y between -3 and -5
            float randomY = Random.Range(-5f, -2f);
            pipeSpawnPos.position = new Vector2(pipeSpawnPos.position.x, randomY);
            timer = 0f;
        }
    }
}
