using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private GameObject pipeSpawn;
    [SerializeField] private Transform pipeSpawnPos;
    [SerializeField] private float pipeSpawnY = 2f;
    [SerializeField] private float spawnInterval = 2f;
    private float timer = 2f;

    public event Action<int> ScoreChanged;
    public event Action Jumped;
    public event Action Died;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //timer = spawnInterval - 0.5f; //so it spawns immediately
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //timer for every x seconds spawn pipe
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            // Spawn pipe logic here
            //Debug.Log("Spawn Pipe");
            //change pipe spawn y
            float randomY = UnityEngine.Random.Range(pipeSpawnY, pipeSpawnY + 2f);
            pipeSpawnPos.position = new Vector2(pipeSpawnPos.position.x, randomY);
            Instantiate(pipePrefab, pipeSpawnPos.position, Quaternion.identity);
            timer = 0f;
        }
    }

    public void OnScoreChanged(int newScore)
    {
        ScoreChanged?.Invoke(newScore);
    }

    public void OnJumped()
    {
        Jumped?.Invoke();
    }

    public void OnDied()
    {
        Died?.Invoke();
    }
}