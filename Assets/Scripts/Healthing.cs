using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthing : MonoBehaviour
{
    public int HealingAmount;
    // Start is called before the first frame update
    void Start()
    {
  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("HealingOrbHasCollidedWith" + collision.gameObject.tag);
        if (GameObject.Find("Player").GetComponent<HealthBar>().CurrentHealth<= GameObject.Find("Player").GetComponent<HealthBar>().MaxHealth)
        {
            if (collision.gameObject.tag == ("Player"))
            {
                GameObject.Find("Player").GetComponent<HealthBar>().Heal(HealingAmount);
                Destroy(gameObject);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
