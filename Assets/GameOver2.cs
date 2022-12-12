using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver2 : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject activar;
    public GameObject activar2;
    public GameObject desactivar;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Ene");

        if (Enemies.Length >= 0)
        {
            activar.SetActive(true);
            activar2.SetActive(true);
            desactivar.SetActive(false);


        }
    }
}
