using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    [Header("Cams")]
    public GameObject FirstPersonCam;
    public GameObject ThirdPersonCam;
    // Start is called before the first frame update
    void Start()
    {
        FirstPersonCam.GetComponent<Camera>().enabled = false;
        ThirdPersonCam.GetComponent<Camera>().enabled = true;
    }

    void CameraSwitch()
    {
        FirstPersonCam.GetComponent<Camera>().enabled = !FirstPersonCam.GetComponent<Camera>().enabled;
        ThirdPersonCam.GetComponent<Camera>().enabled = !ThirdPersonCam.GetComponent<Camera>().enabled;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CameraSwitch();
        }
    }
}
