using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Atributtes Geneal")]
    [SerializeField] public bool useTwoHands;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public virtual void FunctionPickMe(GameObject obj)
    {
        gameObject.SetActive(false);
        transform.parent = obj.transform;
    }

    public virtual void FunctionLeftMe()
    {
        gameObject.SetActive(true);
        transform.parent = null;
    }
}
