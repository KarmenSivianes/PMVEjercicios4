using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HUDManager HUD;
    public bool isPlaying = false, iniciar = false, parar = false;
    private float tiempo = 0;
    private static GameManager _instance;

    //Instancia para poder usarlo en las otras clases
    public static GameManager Instance
    {
        get => _instance;
    }

    void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Empezamos con el juego parado y mostrando el mensaje
        isPlaying = false;
        HUD.aviso.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Tecla Espacio inicia o reaunda el juego y por tanto el tiempo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isPlaying)
            {
                isPlaying = true;
                iniciar = true;
                HUD.aviso.enabled = false;                
            }
        }
        //Tecla Escape para el juego y por tanto el tiempo
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPlaying)
            {
                isPlaying = false;
                parar = true;
                HUD.aviso.enabled = true;
            }
        }
        //Tecla Z cierra el juego solo si el juego esta parado.
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isPlaying)
                UnityEditor.EditorApplication.isPlaying = false;
        }
        //Si el juego esta en marcha se activa el tiempo
        if (isPlaying)
        {
            ContarTiempo();
        }            
    }

    //Llama a la funcion que muestra el tiempo en pantalla de la clase HUD
    void ContarTiempo()
    {
        tiempo += Time.deltaTime;
        HUD.MostrarTiempo(tiempo);
    }

    //Llama a la funcion que gestiona la colision en la clase HUD
    public void Crash()
    {
        HUD.Choque();
    }

    //Llama a la funcion que gestiona el contador de aciertos de la clase HUD
    public void CountHit()
    {
        HUD.ContarAciertos();
    }
}
