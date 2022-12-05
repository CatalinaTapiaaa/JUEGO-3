using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datosEnemigos : MonoBehaviour
{
    public int vidaEnemigo;

    private void Update()
    {
        if(vidaEnemigo ==0)
        {
            Destroy(gameObject);
        }
    }
}
