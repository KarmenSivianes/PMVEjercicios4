using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI aviso;
    public TextMeshProUGUI choque;
    public TextMeshProUGUI contador;
    public int numContador = 0;

    private void Awake()
    {
        GameManager.Instance.HUD = this;
        tiempo = GameObject.Find("Tiempo").GetComponent<TextMeshProUGUI>();
        aviso = GameObject.Find("Aviso").GetComponent<TextMeshProUGUI>();
        choque = GameObject.Find("Choque").GetComponent<TextMeshProUGUI>();
        contador = GameObject.Find("Contador").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        choque.text = "¡Cuidado!";
        choque.color = new Color(choque.color.r, choque.color.g, choque.color.b, 0);
        aviso.text = "Pulsa Space para inciar, ESC para parar el juego, S para salir y D para disparar";
    }
    public void MostrarTiempo(float time)
    {
        tiempo.text = $"{Mathf.Floor(time / 60):00}:{Mathf.Floor(time % 60):00}:{(time - (int)time) * 100f:00}";
    }

    public void Choque()
    {
        StartCoroutine(nameof(Fade));
    }

    IEnumerator Fade()
    {
        for (float f = 10; f >= 0; f--)
        {
            Color c = choque.color;
            c.a = f / 10;
            choque.color = c;
            yield return new WaitForSeconds(.1f);
        }
    }

    public void ContarAciertos()
    {
        numContador++;
        contador.text = $"Contador: {numContador}";
    }
}
