using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public float Ysensitivity;
    private float Xrotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        float mouseY = Input.GetAxisRaw("Mouse Y") * Ysensitivity;
        Xrotation = -mouseY;
        Quaternion DeltarotationX = Quaternion.Euler(Xrotation, transform.localRotation.y, transform.localRotation.z);
        transform.localRotation = transform.localRotation * DeltarotationX;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
