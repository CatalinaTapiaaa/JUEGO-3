using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvocaeEn : MonoBehaviour
{
    public GameObject targetObject;
    public float timetoInvoke;
    public Animator animation;

    private void Start()
    {
        InvokeRepeating("ChangeObjectState", timetoInvoke, timetoInvoke);
    }

    void ChangeObjectState()
    {
        targetObject.SetActive(!targetObject.activeInHierarchy);
        animation.gameObject.SetActive(!animation.gameObject.activeInHierarchy);
       
    }
}

