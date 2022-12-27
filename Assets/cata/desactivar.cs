using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivar : MonoBehaviour
{
    public GameObject a;
    private void Start()
    {
        a.gameObject.SetActive(false);
    }
} 
 