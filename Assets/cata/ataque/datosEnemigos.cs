using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datosEnemigos : MonoBehaviour
{
    public int vidaEnemigo;
    public GameObject imagen;

    private void Update()
    {
        if(vidaEnemigo <= 0)
        {
            Destroy(gameObject);
            imagen.SetActive(false);

        }
        
    }
}
