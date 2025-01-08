using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Vector3[] enemyPosX;
    [SerializeField] GameObject enemySpawner;
    [SerializeField] GameObject ufoPrefab;
    [SerializeField] GameObject ufoSpawner;
    [SerializeField] GameObject[] ufoOnGameArea;
    [SerializeField] float ufoCooldown;





    // Start is called before the first frame update
    void Start()
    {
        ufoCooldown = 20;
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnUfo();
    }

    void SpawnEnemies()
    {
        

        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            enemyPosX[i] = enemyPrefabs[i].transform.position;


            for (int j = 0; j < 10; j++)
            {
                enemyPosX[i].x = enemyPosX[i].x + 1f;
                Instantiate(enemyPrefabs[i], enemyPosX[i], Quaternion.identity, enemySpawner.transform);
            }
        }

    }
    
    public void SpawnUfo()
    {
        ufoCooldown -= Time.deltaTime;
        if (ufoCooldown <= 0)
        {
            ufoCooldown = 40f;
            Instantiate(ufoPrefab, ufoSpawner.transform.position, Quaternion.identity);
        }    
                       
    }


}
