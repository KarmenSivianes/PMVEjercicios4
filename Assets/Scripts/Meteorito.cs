using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorito : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float posMinX = -10f;

    void Update()
    {
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        if (transform.position.x < posMinX)
        //if (!GetComponent<SpriteRenderer>().isVisible) //esto sería si quieres que algo se genere dentro de la zona visible y se destruya al salir de ella
        {
            Destroy(gameObject);
        }
    }
}
