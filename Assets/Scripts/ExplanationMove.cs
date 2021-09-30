using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ExplanationMove : MonoBehaviour
{
    private RectTransform rectTransform = null;
    private Text text = null;

    [SerializeField]
    private string[] explanations = { "������ ������ �� ������ īƮ�� Ŭ���غ�����.", "��� �÷����ϴٺ��� �Ʒ����� ������.", "�� ������ ����ֱ� ���Կ�." };
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        text = GetComponent<Text>();
        StartCoroutine(Move());
    }

    private void Update()
    {

    }

    private IEnumerator Move()
    {
        while (true)
        {
            rectTransform.DOMoveX(-8, 6f);
            yield return new WaitForSeconds(6f);
            rectTransform.anchoredPosition = new Vector2(2000, 898);
            text.text = string.Format("{0}", explanations[Random.Range(0, 3)]);
            yield return new WaitForSeconds(10f);
            InfiniteLoopDetector.Run();
        }
    }
}