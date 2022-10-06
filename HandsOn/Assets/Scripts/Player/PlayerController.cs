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
    [SerializeField] public bool inputButtonG;

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
                        handsOne.gameObjectItem = brick.gameObject;
                        handsTwo.gameObjectItem = brick.gameObject;
                        brick.FunctionPickMe(gameObject);
                    }
                    
                break;
            }
        }

        if(inputButtonG)
        {
            if(handsOne.occupied)
            {
                handsOne.nameItem = null;
                handsOne.occupied = false;
                handsOne.gameObjectItem.GetComponent<Brick>().FunctionLeftMe();
                handsOne.gameObjectItem = null;
            }

            if(handsTwo.occupied)
            {
                handsTwo.nameItem = null;
                handsTwo.occupied = false;
                handsTwo.gameObjectItem.GetComponent<Brick>().FunctionLeftMe();
                handsTwo.gameObjectItem = null;
            }


            
            
        }
    }

    protected void ControllerInputs()
    {
        inputButtonE = Input.GetKeyDown(KeyCode.E) ? inputButtonE = true : inputButtonE = false;
        inputButtonG = Input.GetKeyDown(KeyCode.G) ? inputButtonG = true : inputButtonG = false;
    }
}

[System.Serializable]
public class Hands
{
    public string nameItem;
    public bool occupied;
    public GameObject gameObjectItem;
}




