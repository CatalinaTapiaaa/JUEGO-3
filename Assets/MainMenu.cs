using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ButtonStart()
   {
        SceneManager.LoadScene("Nivel 1");
   }

  public  void ButtonQuit()
  {
        Application.Quit();
  }
}
