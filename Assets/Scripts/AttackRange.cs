using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private float timeBtwAttack;
    public float startAttacktime;
    public Transform Attackpos;
    public float Attackrange;
    public int damage;
    public LayerMask Enemies;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Collider2D[] enemiestoDamege = Physics2D.OverlapCircleAll(Attackpos.position, Attackrange,Enemies);
                for (int i = 0; i < enemiestoDamege.Length; i++)
                {
                    enemiestoDamege[i].GetComponent<healthE>().TakeDamage(damage);
                }
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Attackpos.position, Attackrange);
    }
}
