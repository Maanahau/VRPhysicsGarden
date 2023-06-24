using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenGameMenu : MonoBehaviour
{
    [SerializeField] GameObject gameMenuPrefab;
    [SerializeField] float positionOffset;

    private GameObject spawnedMenu;
    private bool isButtonPressed;

    //disable in Hub scene
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            this.enabled = false;
    }

    private void Update()
    {
        if (Input.GetAxisRaw("XRI_Right_MenuButton") + Input.GetAxisRaw("XRI_Left_MenuButton") > 0)
        {
            if (!isButtonPressed)
            {
                isButtonPressed = true;
                if (spawnedMenu == null)
                {
                    spawnedMenu = Instantiate(gameMenuPrefab, transform.position + transform.forward * positionOffset, transform.rotation);
                    spawnedMenu.transform.LookAt(transform);
                }
                else
                {
                    Destroy(spawnedMenu);
                }
            }
        }
        else
        {
            isButtonPressed = false;
        }
    }
}
