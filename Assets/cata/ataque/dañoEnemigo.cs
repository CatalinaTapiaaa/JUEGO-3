using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dañoEnemigo : MonoBehaviour
{
    public int damage;
    public GameObject Enemigo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemigo")
        {
            Enemigo.GetComponent<datosEnemigos>().vidaEnemigo -= damage;

        }
    }
}