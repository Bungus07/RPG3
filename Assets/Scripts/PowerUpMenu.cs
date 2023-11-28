using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMenu : MonoBehaviour
{
    public GameObject Menu;
    private bool MenuIsOpen;
    public GameObject DoubleJumpPowerUp;
    private bool DoubleJumpIsEnabled;
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive (false);
        DoubleJumpIsEnabled = true; 
    }
    public void DJE()
    {
        Debug.Log("DJE Activated");
        
        {
            Debug.Log("Double Jump is " + DoubleJumpIsEnabled);
            DoubleJumpPowerUp.SetActive(true);
            DoubleJumpIsEnabled = true;
        }
    }

    public void DJD()
    {
        Debug.Log("DJE Deactivated");
        DoubleJumpPowerUp.SetActive(false);
        DoubleJumpIsEnabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && MenuIsOpen == false)
        {
            Menu.SetActive(true);
            MenuIsOpen = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.M) && MenuIsOpen == true)
        {
            Menu.SetActive(false);
            MenuIsOpen = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;
        }
    }
}
