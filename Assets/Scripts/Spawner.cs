using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject spawnPoint;
    private float timer;
    private float randomY;
    [SerializeField] private GameManager gameManager;

    public bool Spawnable;
    

    void Start()
    {
        // Initialize any required variables
        timer = 0f;
        Spawnable = true;
    }

    void Update()
    {
        if (gameManager.start)
        {
            timer += Time.deltaTime;
        }
        
        
        if (timer > 2f && gameManager.start) 
        {
            Spawn();
            timer = 0;
        }
    }

    public void Spawn()
    {
        if (Spawnable)
        {
            randomY = Random.Range(spawnPoint.transform.position.y + 2, spawnPoint.transform.position.y - 2);

            Instantiate(prefab, new Vector2(spawnPoint.transform.position.x, randomY), Quaternion.identity);
        }
    }
    public void setSpawnable(bool spawn)
    {
        Spawnable = spawn;
    }
}