using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillArea : MonoBehaviour
{
    public enum TypeFillArea
    {
        Water,
        Rock,
        Dirt,
    }

    [Header("Atributtes General")]
    [SerializeField] public TypeFillArea typeFillArea;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}


