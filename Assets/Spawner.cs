using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject[] enemySpawned;
    [SerializeField] GameObject[] coinSpawned;
    [SerializeField] float enemySpawnTime=1.1f;
    [SerializeField] float coinSpawnTime=1.9f;
    [SerializeField] float enemyMinTransX;
    [SerializeField] float enemyMaxTransX;

    [SerializeField] float enemyMinTransY;
    [SerializeField] float enemyMaxTransY;

    [SerializeField] float coinMinTransX;
    [SerializeField] float coinMaxTransX;

    [SerializeField] float coinMinTransY;
    [SerializeField] float coinMaxTransY;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(coinSpawn());
    }

    IEnumerator EnemySpawn()
    {
        while(true)
        {
        var wantedX=Random.Range(enemyMinTransX,enemyMaxTransX);
        var wantedY=Random.Range(enemyMinTransY,enemyMaxTransY);
        var position=new Vector3(wantedX,wantedY);
        GameObject enemyGm=Instantiate(enemySpawned[Random.Range(0,enemySpawned.Length)],position,Quaternion.identity);
        yield return new WaitForSeconds(enemySpawnTime);
        Destroy(enemyGm,3.7f);
        }
        
    }

    IEnumerator coinSpawn()
    {
        while(true)
        {
            var coinWantedX=Random.Range(coinMinTransX,coinMaxTransX);
            var coinWantedY=Random.Range(coinMinTransY,coinMaxTransY);
            var coinPosition=new Vector3(coinWantedX,coinWantedY);

            GameObject coinGM=Instantiate(coinSpawned[Random.Range(0,coinSpawned.Length)],coinPosition,Quaternion.identity);
            yield return new WaitForSeconds(coinSpawnTime);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
