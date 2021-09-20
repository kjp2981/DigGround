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
        backmenu.SetActive(false);
    }
    private void Update()
    {
        BackButton();
    }
    public void StartButton()
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
