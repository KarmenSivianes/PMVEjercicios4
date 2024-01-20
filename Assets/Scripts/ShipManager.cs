using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    float shipSpeed = 5.0f;
    private Vector3 inicial;
    public GameObject shootPrefab;
    public SpriteRenderer laserSpriteRenderer;

    //Indicamos valores inciales de posición de la nave en la pantalla
    void Start()
    {
        inicial.x = 9f;
        inicial.y = 2.5f;
    }

    //Se ejecuta a cada frame.
    //Gestiona el movimiento de la nave. Posibilidad de movimiento en todas direcciones.
    //Gestiona el disparo de la nave que se activa al pulsar la tecla F.
    void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            //get the Input from Horizontal axis
            float horizontalInput = Input.GetAxis("Horizontal") * shipSpeed * Time.deltaTime; ;
            //get the Input from Vertical axis
            float verticalInput = Input.GetAxis("Vertical") * shipSpeed * Time.deltaTime; ;
            //update the position
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0));

            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject go = Instantiate(shootPrefab);
                go.transform.position = laserSpriteRenderer.gameObject.transform.position;
                go.GetComponent<ControlShoot>().shipManager = this;
            }
        }
    }

    //Comprueba si la nave ha colisionado con un meteorito y muestra un mensaje de advertencia
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Meteor"))
            GameManager.Instance.Crash();
    }
}
