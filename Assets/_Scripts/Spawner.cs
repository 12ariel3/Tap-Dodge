using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    List<GameObject> enemiesList;
    [SerializeField] GameObject pointPrefab;
    List<GameObject> pointsList;
    [SerializeField] float spawnTime = 1f;
    float timer;

    [SerializeField] Transform limitLeft;
    [SerializeField] Transform limitRight;

    public bool stop;



    // Start is called before the first frame update
    void Start()
    {
        enemiesList = new List<GameObject>();
        pointsList = new List<GameObject>();
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop){
            timer -= Time.deltaTime;
            if(timer <= 0){
                Spawn();
            }
        }
    }

    void Spawn(){
        Vector2 spawnPos = new Vector2(Random.Range(limitLeft.position.x, limitRight.position.x), transform.position.y);
        int rndType = Random.Range(0, 3);

        if(rndType == 0){
            GameObject newPoint = GetFirstPointNoActive();
            newPoint.transform.position = spawnPos;
            newPoint.SetActive(true);
        }else{
            GameObject newEnemy = GetFirstEnemyNoActive();
            newEnemy.transform.position = spawnPos;
            newEnemy.SetActive(true);
        }

        timer = spawnTime;
    }

    GameObject GetFirstEnemyNoActive(){
        for(int i = 0; i < enemiesList.Count; i++){
            if(!enemiesList[i].activeInHierarchy){
                return enemiesList[i];
            }
        }
        return CreateEnemy();
    }
    
    GameObject CreateEnemy(){
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.parent = gameObject.transform;
        newEnemy.SetActive(false);
        enemiesList.Add(newEnemy);
        return newEnemy;
    }

    GameObject GetFirstPointNoActive(){
        for(int i = 0; i < pointsList.Count; i++){
            if(!pointsList[i].activeInHierarchy){
                return pointsList[i];
            }
        }
        return CreatePoint();
    }

    GameObject CreatePoint(){
        GameObject newPoint = Instantiate(pointPrefab);
        newPoint.transform.parent = gameObject.transform;
        newPoint.SetActive(false);
        pointsList.Add(newPoint);
        return newPoint;
    }

    
}
