using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionSphere : MonoBehaviour
{
    public GameObject Target;
    void Update()
    {
        gameObject.transform.position = Target.transform.position;
    }
}
