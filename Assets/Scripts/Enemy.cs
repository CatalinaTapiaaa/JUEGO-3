using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject Enemyprefab;
    public float DistancePlayer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void DoEnemyAction()
    {
        StartCoroutine(Enemyturn());
    }
    IEnumerator Enemyturn()
    {

        


            Gamemanager.instance.EnemyTurnText.enabled = true;
        


        if (DistancePlayer <= 5f)
        {
            

        }
        yield return new WaitForSeconds(0.5f);

        Gamemanager.instance.EnemyTurnFinish(this);
        Gamemanager.instance.EnemyTurnText.enabled = false;



    }
}
