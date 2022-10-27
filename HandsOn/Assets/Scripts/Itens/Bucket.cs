using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [Header("Atributtes General")]
    [SerializeField] protected ContentBucket contentBucket;

    [Header("Atributtes Fill Area")]
    [SerializeField] protected bool fillArea;
    [SerializeField] protected GameObject gameObjectFillArea;



    void Start()
    {
        
    }

    void Update()
    {
        ControllerFill();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("FillArea"))
        {
            fillArea = true;
            gameObjectFillArea = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("FillArea"))
        {
            fillArea = false;
            gameObjectFillArea = other.gameObject;
        }
    }

    protected void ControllerFill()
    {
        if(transform.parent == PlayerController.instance.transform)
        {
            if(fillArea && PlayerController.instance.inputButtonE 
            && !contentBucket.water 
            && !contentBucket.rock
            && !contentBucket.dirt)
            {
                switch(gameObjectFillArea.GetComponent<FillArea>().typeFillArea)
                {
                    case FillArea.TypeFillArea.Water:
                        contentBucket.water = true;
                    break;

                    case FillArea.TypeFillArea.Rock:
                        contentBucket.rock = true;
                    break;

                    case FillArea.TypeFillArea.Dirt:
                        contentBucket.dirt = true;
                    break;
                }
            }
        }
    }
}

[System.Serializable]
public class ContentBucket
{
    public bool water;
    public bool rock;
    public bool dirt;
}
