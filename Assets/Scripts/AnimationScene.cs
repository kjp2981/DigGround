using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationScene : MonoBehaviour
{
    [SerializeField]
    private GameObject[] scene = null;
    [SerializeField]
    private float speed = 1f;
    void Start()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        yield return new WaitForSeconds(speed);
        scene[1].SetActive(true);
        yield return new WaitForSeconds(speed);
        scene[2].SetActive(true);
        yield return new WaitForSeconds(speed);
        scene[3].SetActive(true);
        yield return new WaitForSeconds(speed);
        scene[4].SetActive(true);
        yield return new WaitForSeconds(speed);
        scene[5].SetActive(true);
        yield return new WaitForSeconds(speed);
        SceneManager.LoadScene("Main");
    }
}
