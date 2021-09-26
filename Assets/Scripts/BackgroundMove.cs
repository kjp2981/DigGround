using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 0f;

    private Vector2 offset = Vector2.zero;
    private MeshRenderer meshRenderer = null;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        offset.x += speed * Time.deltaTime;
        meshRenderer.material.SetTextureOffset("_MainTex", offset);
    }
}
