using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public string Nextlevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonRetry()
    {
        SceneManager.LoadScene(Nextlevel);

    }
    public void ButtonQuit()
    {
        Application.Quit();
    }
}
