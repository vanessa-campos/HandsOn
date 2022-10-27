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
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        transform.parent = obj.transform;
    }

    public virtual void FunctionLeftMe()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        transform.parent = null;
    }
}
