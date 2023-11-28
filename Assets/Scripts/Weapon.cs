using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int WeaponDamage;
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GameObject.Find("Hand").GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<NewAi>().TakeDamage(WeaponDamage);
            Debug.Log("EnemyHasBeenHit");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            Debug.Log("PlayerHasAttacked");
        }
    }
    private void Attack()
    {
        Anim.SetTrigger("Swing");
    }
}
