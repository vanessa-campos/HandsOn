using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Text dialogue;
    [SerializeField]
    private Tilemap[] tilemaps = new Tilemap[3];

    public float distancia;
    [HideInInspector]
    public GameObject interagiu;

    [SerializeField]
    private GameObject caixaDeDialogo;
    [SerializeField]
    private GameObject icone;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {   
        bool temTile = false;
        Vector2 mouseNaTela = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 posicao = this.gameObject.transform.position;
        
        distancia = Mathf.Sqrt(Mathf.Pow(mouseNaTela.x - posicao.x, 2f) + Mathf.Pow(mouseNaTela.y - posicao.y, 2f));         
        
        foreach(Tilemap tilemap in tilemaps)
        {
            if (temTile == false && distancia < 5f)
                temTile = tilemap.GetTile(tilemap.WorldToCell(mouseNaTela));
        }
        if (distancia < 5f && temTile)
        {
            temTile = false;
            if (caixaDeDialogo.activeSelf == false)
                icone.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E))
            {
                if (caixaDeDialogo.activeSelf == false)
                    detectarObjeto();
                else
                    caixaDeDialogo.SetActive(false);
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.E))
                caixaDeDialogo.SetActive(false);
            icone.SetActive(false);
        }
    }

    private void detectarObjeto()
    {
        foreach(Tilemap tilemap in tilemaps)
        {
            if (caixaDeDialogo.activeSelf == false)
            {
                Vector3 mousePosicao = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Tile tile = tilemap.GetTile<Tile>(tilemap.WorldToCell(mousePosicao));

                bool check = false;
                if (tilemap.GetTile(tilemap.WorldToCell(mousePosicao)) && !check)
                {
                    icone.SetActive(false);
                    caixaDeDialogo.SetActive(true);
                    switch (tile.name)
                    {
                        case "Wall Blueprint":
                            {
                                check = true;
                                
                                int tijolo = 2;
                                int concreto = 3;
                                GameObject[] items = GameObject.FindGameObjectsWithTag("item");
                                foreach (GameObject item in items)
                                {
                                    if (Mathf.Sqrt(Mathf.Pow(item.transform.position.x - tilemap.WorldToCell(mousePosicao).x,2f) + Mathf.Pow(item.transform.position.y - tilemap.WorldToCell(mousePosicao).y,2f)) < 3)
                                    {
                                        if (item.name == "brick")
                                        {
                                            if (tijolo > 0)
                                                tijolo--;
                                        }
                                        if (item.name == "Concrete")
                                        {
                                            if (concreto > 0)
                                               concreto--;
                                        }
                                    }
                                }
                                dialogue.text = "This is a Wall Blueprint, it requires " + tijolo + " bricks and " + concreto + " concrete to finish.";
                            }
                            break;
                        case "Floor Blueprint":
                            {
                                check = true;
                                
                                int concreto = 1;
                                GameObject[] items = GameObject.FindGameObjectsWithTag("item");
                                foreach (GameObject item in items)
                                {
                                    if (Mathf.Sqrt(Mathf.Pow(item.transform.position.x - tilemap.WorldToCell(mousePosicao).x,2f) + Mathf.Pow(item.transform.position.y - tilemap.WorldToCell(mousePosicao).y,2f)) < 3)
                                    {
                                        if (item.name == "Concrete")
                                        {
                                            if (concreto > 0)
                                                    concreto--;
                                        }
                                    }
                                }
                                dialogue.text = "This is a Floor Blueprint, it requires " + concreto + " concrete to finish.";
                            }
                            break;
                        case "Wall":
                            check = true;
                            dialogue.text = "This is a Wall.";
                            break;
                        case "Floor":
                            check = true;
                            dialogue.text = "This is a Floor.";
                            break;
                    }
                }
            }
        }
    }

}
