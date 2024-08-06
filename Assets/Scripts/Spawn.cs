using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Enemy enemy; //referenciando o inimigo do jogo
    public float spawnInternal;  //intervalo de spawn
    public int miniSpawnAmount; // minimo de inimigos que pode spawnar por ordar
    public int maxiSpawnAmount; //maximo de inimigos que pode spawnar por ordar
    public float radius;

    float timeCount; // contador
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        //SE
        if (timeCount > spawnInternal)
        {
            SpawnEnemies();
            timeCount = 0;
        }

    }

    void SpawnEnemies()
    {
        int enemiesToSpawn = Random.Range(miniSpawnAmount, maxiSpawnAmount);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector2 enemyPos = (Vector2)player.transform.position + Random.insideUnitCircle * radius;
            Instantiate(enemy, enemyPos, Quaternion.identity);
        }
    }

}
