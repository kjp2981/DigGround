using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCallBack : MonoBehaviour
{
    [SerializeField]
    private Transform poolTransform = null;

    public void OnParticleSystemStopped()
    {
        transform.SetParent(poolTransform, false);
        gameObject.SetActive(false);
    }
}
