using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    private float speed = 6f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        //if (transform.position.y < -5) 
        if (!GetComponent<SpriteRenderer>().isVisible) //para que se destruya al salir de la zona visible
            Destroy(gameObject);
    }

    public void HitByShoot()
    {
        Destroy(gameObject);
    }
}
