using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private PuzzleInventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindAnyObjectByType<PuzzleInventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Ajouter la pièce à l'inventaire
            inventory.CollectPiece();

            //Désactiver la pièce de la scène pour montrer qu'elle est collectée
            gameObject.SetActive(false);
        }
    }

}
