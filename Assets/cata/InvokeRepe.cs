using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeRepe : MonoBehaviour
{
    public GameObject[] ObjectsList; // Not only 18, this script will except any number of game objects you put here.

    void Start()
    {
        StartCoroutine(ResetInvoKe());

    }
    private void Update()
    {
        
    }
    IEnumerator ResetInvoKe()
    {
        List<int> posibles = new List<int>();
        for (int i = 0; i < ObjectsList.Length; i++)
        {
            ObjectsList[i].SetActive(false);
            posibles.Add(i);
        }

        for (int i = 0; i < 4; i++)
        {
            int selected = Random.Range(0, posibles.Count);
            ObjectsList[posibles[selected]].SetActive(true);
            posibles.Remove(selected);
        }

        yield return new WaitForSeconds(10);
        ResetInvoKe();

    }
}
