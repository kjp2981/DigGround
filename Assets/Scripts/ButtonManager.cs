using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject backmenu = null;
    private void Start()
    {
        Screen.SetResolution(1440, 2960, true);
        backmenu.SetActive(false);
    }
    private void Update()
    {
        BackButton();
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Animation");
    }

    public void SkipButton()
    {
        SceneManager.LoadScene("Main");
    }

    private void BackButton()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            backmenu.SetActive(true);
        }
    }

    public void MenuQuit()
    {
        backmenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
