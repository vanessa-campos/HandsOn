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
                        handsOne.nameItem = brick.gameObject.name;
                        handsTwo.nameItem = brick.gameObject.name;
                        handsOne.occupied = true;
                        handsTwo.occupied = true;
                        handsOne.gameObjectItem = brick.gameObject;
                        handsTwo.gameObjectItem = brick.gameObject;
                        brick.FunctionPickMe(gameObject);
                    }
                    
                break;

                case "PICKUP_BUCKET":
                    Bucket bucket = gameObjectItem.GetComponent<Bucket>();
                    if(!handsOne.occupied && !handsTwo.occupied)
                    {
                        handsOne.nameItem = bucket.gameObject.name;
                        handsTwo.nameItem = bucket.gameObject.name;
                        handsOne.occupied = true;
                        handsTwo.occupied = true;
                        handsOne.gameObjectItem = bucket.gameObject;
                        handsTwo.gameObjectItem = bucket.gameObject;
                        bucket.FunctionPickMe(gameObject);
                    }
                break;

                case "PICKUP_TILE":
                    Tile tile = gameObjectItem.GetComponent<Tile>();
                    if(!handsOne.occupied && !handsTwo.occupied)
                    {
                        handsOne.nameItem = tile.gameObject.name;
                        handsTwo.nameItem = tile.gameObject.name;
                        handsOne.occupied = true;
                        handsTwo.occupied = true;
                        handsOne.gameObjectItem = tile.gameObject;
                        handsTwo.gameObjectItem = tile.gameObject;
                        tile.FunctionPickMe(gameObject);
                    }
                break;
            }
        }

        if(inputButtonG)
        {
            if(handsOne.occupied)
            {
                switch(handsOne.nameItem)
                {
                    case "PICKUP_BRICK":
                        handsOne.gameObjectItem.GetComponent<Brick>().FunctionLeftMe();
                    break;

                    case "PICKUP_BUCKET":
                        handsOne.gameObjectItem.GetComponent<Bucket>().FunctionLeftMe();
                    break;
                    
                    case "PICKUP_TILE":
                        handsOne.gameObjectItem.GetComponent<Tile>().FunctionLeftMe();
                    break;
                }

                handsOne.nameItem = null;
                handsOne.occupied = false;
                handsOne.gameObjectItem = null;

            }

            if(handsTwo.occupied)
            {
                switch(handsTwo.nameItem)
                {
                    case "PICKUP_BRICK":
                        handsTwo.gameObjectItem.GetComponent<Brick>().FunctionLeftMe();
                    break;

                    case "PICKUP_BUCKET":
                        handsTwo.gameObjectItem.GetComponent<Bucket>().FunctionLeftMe();
                    break;

                    case "PICKUP_TILE":
                        handsTwo.gameObjectItem.GetComponent<Tile>().FunctionLeftMe();
                    break;
                }

                handsTwo.nameItem = null;
                handsTwo.occupied = false;
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




