using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gm;
    public GameObject meteorMedPrefab;
    public GameObject meteorBigPrefab;
    private float spawnTimer = 1f;
    public float posMaxX = 12f;

    private void Start()
    {
        gm = GameManager.Instance;
    }

    //Si el juego esta parado no se generan meteoritos
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

    //Inicia la genración de meteoritos
    public void StartSpawn()
    {
        InvokeRepeating(nameof(SpawnMeteor), 0, spawnTimer);
    }

    //Detiene la generación de meteoritos
    public void CancelSpawn()
    {
        CancelInvoke(nameof(SpawnMeteor));
    }

    //Genera meteoritos aleatoriamente en la pantalla dentro del rango indicado del eje y,
    //para que lo hagan desde la derecha y se muevan hacia la izquierda.
    //Siempre lo hacen desde el mismo punto del eje x
    void SpawnMeteor()
    {
        Vector2 spawnPos;
        spawnPos.x = transform.position.x;
        spawnPos.y = Random.Range(-5f, 5f);

        //Genero aleatoriamente los dos tipos de meteoritos que hay
        float randomPrefab = Random.value;
        if (randomPrefab < 0.5)
            Instantiate(meteorMedPrefab, spawnPos, Quaternion.identity);        
        else
            Instantiate(meteorBigPrefab, spawnPos, Quaternion.identity);
    }
}
