using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeRepe : MonoBehaviour
{
    public GameObject[] ObjectsList; // Not only 18, this script will except any number of game objects you put here.

    void Start()
    {
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
       

    }
    private void Update()
    {
        StartCoroutine(ResetInvoKe());
    }
    IEnumerator ResetInvoKe()
    {
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);
        yield return new WaitForSeconds(10);

    }
}
