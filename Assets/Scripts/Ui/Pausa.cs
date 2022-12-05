using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    private bool Menuon;

    public GameObject PauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void Continuar()
    {
        PauseMenuUI.SetActive(false);

        Menuon = true;
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
