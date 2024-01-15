using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float posMinX = -10f;
    public float posMaxX = 10f;
    public float posMinY = 5f;
    public float posMaxY = -5f;
    public GameObject myPrefab;

    void Start()
    {
        //Llamamos al metodo spawnprefab al iniciar y luego cada 2 segundos
        InvokeRepeating(nameof(SpawnPrefab), 0f, 2f);
    }

    //Asigna una posicion aleatoria y lo mueve hacia la izda
    void SpawnPrefab()
    {
        //recogemos la posicion del prefab
        Vector3 posicion = transform.position;
        //para que salga siempre desde la posicion maxima de la izda
        posicion.x = posMaxX;
        posicion.y = Random.Range(posMinY, posMaxY);
        //le asginamos a la posicion la nueva aleatoria que hemos creado
        transform.position = posicion;
        Debug.Log($"Posición aleatoria bichito: {posicion}");
        //Instancia del prefab
        Instantiate(myPrefab, posicion, Quaternion.identity);
    }
}
