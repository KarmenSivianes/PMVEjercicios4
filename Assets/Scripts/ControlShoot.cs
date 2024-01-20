using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShoot : MonoBehaviour
{
    public float speed = 10f;
    public ShipManager shipManager;  

    //Update is called once per frame
    //Mueve el disparo hacia la derecha y lo destruye cuando deja de estar visible
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        if (!GetComponent<SpriteRenderer>().isVisible)
            Destroy(gameObject);
    }

    //Gestiona la colision con un meteorito. Llama a la función del controlador del meteorito,
    //destruye el rayo laser y llama a la función que aumenta el contador de aciertos
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<MeteorController>(out var component))
        {
            component.HitByShoot();
        }
        GameManager.Instance.CountHit();
        Destroy(gameObject);
    }
}
