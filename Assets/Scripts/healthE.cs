using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthE : MonoBehaviour
{

    [SerializeField] float Health, Maxhealth = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float DamageAmount)
    {
        Health -= DamageAmount;
        if (Health <= 0)
        {
            

            Destroy(gameObject);
        }
    }

}
