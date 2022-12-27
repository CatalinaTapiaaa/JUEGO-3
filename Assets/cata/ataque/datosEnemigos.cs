using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class datosEnemigos : MonoBehaviour
{
    public int vidaEnemigo;
    public Slider vidaVisual;
    public Text text;
    public GameObject imagen;

    private void Update()
    {
        vidaVisual.GetComponent<Slider>().value = vidaEnemigo;
        text.text = "" + vidaEnemigo;                  


        if (vidaEnemigo <= 0)
        {
            Destroy(gameObject);
            imagen.SetActive(false);
            
        }
        
    }
}
