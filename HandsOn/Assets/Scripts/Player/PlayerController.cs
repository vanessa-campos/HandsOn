using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Atributtes Hands")]
    [SerializeField] protected Hands handsOne;
    [SerializeField] protected Hands handsTwo;

    [Header("Atributtes Proximity Item")]
    [SerializeField] protected bool proximityItem;
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
        // Armazena informações sobre os pickup.
        if(other.gameObject.CompareTag("Item"))
        {
            proximityItem = true;
            gameObjectItem = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Retira informações sobre os pickup.
        if(other.gameObject.CompareTag("Item"))
        {
            proximityItem = false;
            gameObjectItem = null;
        }
    }

    protected void ControllerHands()
    {

        /* Aqui esta o controle de pegar os itens pickup. */
        if(inputButtonE && proximityItem)
        {
            Pickup pickup = gameObjectItem.GetComponent<Pickup>();
            if(pickup.useTwoHands && !handsOne.occupied && !handsTwo.occupied)
            {
                handsOne.nameItem = pickup.gameObject.name;
                handsTwo.nameItem = pickup.gameObject.name;
                handsOne.occupied = true;
                handsTwo.occupied = true;
                handsOne.gameObjectItem = pickup.gameObject;
                handsTwo.gameObjectItem = pickup.gameObject;
                pickup.FunctionPickMe(gameObject);
            }else 
            {
                if(!pickup.useTwoHands && !handsOne.occupied)
                {
                    handsOne.nameItem = pickup.gameObject.name;
                    handsOne.occupied = true;
                    handsOne.gameObjectItem = pickup.gameObject;
                    pickup.FunctionPickMe(gameObject);
                }else 
                {
                    if(!pickup.useTwoHands && !handsTwo.occupied)
                    {
                        handsTwo.nameItem = pickup.gameObject.name;
                        handsTwo.occupied = true;
                        handsTwo.gameObjectItem = pickup.gameObject;
                        pickup.FunctionPickMe(gameObject);
                    }
                }
            }
        }

        /* Aqui esta o controle de largr os itens pickup. */
        if(inputButtonG)
        {
            if(handsOne.occupied)
            {
                handsOne.gameObjectItem.GetComponent<Pickup>().FunctionLeftMe();
                handsOne.nameItem = null;
                handsOne.occupied = false;
                handsOne.gameObjectItem = null;
            }

            if(handsTwo.occupied)
            {
                handsTwo.gameObjectItem.GetComponent<Pickup>().FunctionLeftMe();
                handsTwo.nameItem = null;
                handsTwo.occupied = false;
                handsTwo.gameObjectItem = null;
            }
        }
    }

    protected void ControllerInputs()
    {
        /* Todos os inputs relacionados a mecanica do jogador irão ser adicionados aqui. */
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




