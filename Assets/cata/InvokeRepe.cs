using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeRepe : MonoBehaviour
{
    public GameObject[] ObjectsList; // Not only 18, this script will except any number of game objects you put here.
    public GameObject Jefe;
    
    public int ataqueBoss;
    public int Hpbossactual;
    public float HpBossTotal;
   

    void Start()
    {
        StartCoroutine(ResetInvoKe());
       
        
    }
    private void Update()
    {
        Hpbossactual = Jefe.GetComponent<datosEnemigos>().vidaEnemigo;
    }
    IEnumerator ResetInvoKe()
    {
        List<int> posibles = new List<int>();
      
        for (int i = 0; i < ObjectsList.Length; i++)
        {
            ObjectsList[i].SetActive(false);
            posibles.Add(i);
        }

        for (int i = 0; i < 4 + Mathf.Clamp((1 - Hpbossactual / HpBossTotal ) * 3, 0, 3); i++)
         
        {
            int selected = Random.Range(0, posibles.Count);
            ObjectsList[posibles[selected]].SetActive(true);
            posibles.RemoveAt(selected);
            
            Debug.Log(HpBossTotal / Hpbossactual) ;

            
          

        }
        yield return new WaitForSeconds(10);
        ResetInvoKe();
       
    }
}
