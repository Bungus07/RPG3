using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionSphere : MonoBehaviour
{
    public GameObject Target;
    private EnemyControls EnemyScript;

    private void Start()
    {
        EnemyScript = Target.GetComponent<EnemyControls>();
    }
    void Update()
    {
        gameObject.transform.position = Target.transform.position;
        if (EnemyScript.EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
