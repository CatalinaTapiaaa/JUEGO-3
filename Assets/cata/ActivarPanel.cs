using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActivarPanel : MonoBehaviour
{
    public Text EnemiesCount;
    public GameObject[] Enemies;
 
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("NPC");
        EnemiesCount.text = "NPC" + Enemies.Length.ToString();


        if (Enemies.Length <= 0)
        {
            SceneManager.LoadScene("VictoryPanel");
        }
    }
}

