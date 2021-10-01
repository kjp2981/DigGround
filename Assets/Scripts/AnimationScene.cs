using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class AnimationScene : MonoBehaviour
{
    [SerializeField]
    private Image[] scene = null;
    [SerializeField]
    private float speed = 1f;

    private void Awake()
    {
        SceneColorSetting();
    }
    void Start()
    {
        StartCoroutine(Animation());
    }

    private void SceneColorSetting()
    {
        for(int i = 0; i < scene.Length; i++)
        {
            if (i == 0) continue;
            scene[i].color = new Color(1, 1, 1, 0);
        }
    }

    private IEnumerator Animation()
    {
        for(int i = 0; i < scene.Length; i++)
        {
            yield return new WaitForSeconds(speed);
            scene[i].gameObject.SetActive(true);
            scene[i].DOColor(Color.white, 1.5f);
        }
        yield return new WaitForSeconds(speed);
        SceneManager.LoadScene("Main");
    }
}
