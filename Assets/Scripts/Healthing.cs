using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthing : MonoBehaviour
{
    public int HealingAmount;
    private Person2 PlayerScript;
    private GameObject Player;
    private HealthBar PlayerHealthBarScript;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerScript = Player.GetComponent<Person2>();
        PlayerHealthBarScript = Player.GetComponent<HealthBar>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HealingOrbHasCollidedWith" + collision.gameObject.tag);
        if (PlayerHealthBarScript.CurrentHealth<= PlayerHealthBarScript.MaxHealth)
        {
            if (collision.gameObject.tag == ("Player"))
            {
                if (PlayerHealthBarScript.CurrentHealth != PlayerHealthBarScript.MaxHealth)
                {
                    PlayerHealthBarScript.Heal(HealingAmount);
                    Destroy(gameObject);
                }
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
