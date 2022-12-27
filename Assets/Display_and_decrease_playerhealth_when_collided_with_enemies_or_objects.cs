using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Display_and_decrease_playerhealth_when_collided_with_enemies_or_objects : MonoBehaviour
{
    public float health;
    public Slider slider;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        slider.value = health;                           //syncing value of slider with player health
        text.text = "" + health;                  //syncing text with player health

    }
    //Function which detects collision
    private void OnTriggerEnter(Collision other)
    {
        //checking whether object tagged Enemy is collided
        if (other.gameObject.tag == "Pla")
            health = health - 1f;                          //
    }

}
