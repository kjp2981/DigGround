using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterPanel : MonoBehaviour
{
    [SerializeField]
    private Animator animator = null;
    [SerializeField]
    private int hp = 30;
    [SerializeField]
    private Slider hpSlider = null;
    [SerializeField]
    private float time = 50;
    [SerializeField]
    private Slider timeSlider = null;

    private int fullHp = 0;
    private float fullTime = 0; 
    void Awake()
    {
        fullHp = hp;
        fullTime = time;
    }

    private void Update()
    {
        hpSlider.value = (float)hp / fullHp;
        timeSlider.value = time / fullTime;
        time -= Time.deltaTime;
    }

    public void OnClick()
    {
        animator.Play("Monster1");
        hp -= 1;
    }
}
