using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Atributtes Hands")]
    [SerializeField] protected Hands handsOne;
    [SerializeField] protected Hands handsTwo;

    [Header("Atributtes Proximity Item")]
    [SerializeField] protected string nameItem;
    [SerializeField] protected GameObject gameObjectItem;

    [Header("Inputs")]
    [SerializeField] public bool inputButtonE;

    void Start()
    {
        
    }

    void Update()
    {
        ControllerInputs();
        ControllerHands();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            nameItem = other.gameObject.name;
            gameObjectItem = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            nameItem = null;
            gameObjectItem = null;
        }
    }

    protected void ControllerHands()
    {
        if(inputButtonE && nameItem != null)
        {
            switch(nameItem)
            {
                case "PICKUP_BRICK":
                    Brick brick = gameObjectItem.GetComponent<Brick>();
                    if(!handsOne.occupied && !handsTwo.occupied)
                    {
                        handsOne.nameItem = "Brick";
                        handsTwo.nameItem = "Brick";
                        handsOne.occupied = true;
                        handsTwo.occupied = true;
                        brick.FunctionDestroyMe();
                    }
                    
                break;
            }
        }
    }

    protected void ControllerInputs()
    {
        inputButtonE = Input.GetKeyDown(KeyCode.E) ? inputButtonE = true : inputButtonE = false;
    }
}

[System.Serializable]
public class Hands
{
    public string nameItem;
    public bool occupied;
}




