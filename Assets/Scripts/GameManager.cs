using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HUDManager HUD;
    public bool isPlaying = false, iniciar = false, parar = false;
    private float tiempo = 0;
    private static GameManager _instance;

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
        isPlaying = false;
        HUD.aviso.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isPlaying)
            {
                isPlaying = true;
                iniciar = true;
                HUD.aviso.enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPlaying)
            {
                isPlaying = false;
                parar = true;
                HUD.aviso.enabled = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            #if UNITY_EDITOR
                // Application.Quit() does not work in the editor so
                // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                    Application.Quit();
            #endif

        }
        if (isPlaying)
        {
            ContarTiempo();
        }            
    }

    void ContarTiempo()
    {
        tiempo += Time.deltaTime;
        HUD.MostrarTiempo(tiempo);
    }

    public void Crash()
    {
        HUD.Choque();
    }

    public void CountHit()
    {
        Debug.Log("entra en count");
        HUD.ContarAciertos();
    }
}
