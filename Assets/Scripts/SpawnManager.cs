using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gm;
    public GameObject meteorPrefab;
    private float spawnTimer = 1f;
    public float posMaxX = 10f;

    private void Start()
    {
        gm = GameManager.Instance;
    }
    private void Update()
    {
        if (gm.iniciar)
        {
            gm.iniciar = false;
            StartSpawn();
        }
        if (gm.parar)
        {
            gm.parar = false;
            CancelSpawn();
        }
    }
    public void StartSpawn()
    {
        InvokeRepeating(nameof(SpawnMeteor), 0, spawnTimer);
    }
    public void CancelSpawn()
    {
        CancelInvoke(nameof(SpawnMeteor));
    }
    void SpawnMeteor()
    {
        Vector2 spawnPos;
        //spawnPos.x = posMaxX;
        spawnPos.x = transform.position.x;
        spawnPos.y = Random.Range(-5f, 5f);        
        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);        
    }
}
