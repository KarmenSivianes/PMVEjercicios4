using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    private float speed = 6f;

    //Se ejecuta a cada frame. Mueve el meteorito desde el punto de generación hacia la izquierda con la velocidad indicada.
    //Comprueba si el meteorito está visible en la pantalla, si no lo esta lo destruye.
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        //para que se destruya al salir de la zona visible
        if (!GetComponent<SpriteRenderer>().isVisible) 
            Destroy(gameObject);
    }

    //Destruye el meteorito si es alcanzado por el rayo laser
    public void HitByShoot()
    {
        Destroy(gameObject);
    }
}
