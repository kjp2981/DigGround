using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoilMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 0f;

    private Vector2 offset = Vector2.zero;
    private MeshRenderer meshRenderer = null;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Move()
    {
        offset.x += speed * Time.deltaTime;
        meshRenderer.material.SetTextureOffset("_MainTex", offset);
    }
}
