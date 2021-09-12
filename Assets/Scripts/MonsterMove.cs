using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    private RaycastHit2D hit;

    private Animator animator = null;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    //private void OnClick()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        Ray2D ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //        if(Physics2D.Raycast(ray, out hit))
    //        {
    //            animator.Play("Dead");
    //            gameObject.SetActive(false);
    //        }
    //    }
    //}
}
