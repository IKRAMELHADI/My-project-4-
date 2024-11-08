using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInventory : MonoBehaviour
{
    //Liste des pièces de puzzle collectées
    private List<GameObject> collectedPieces = new List<GameObject>();

    //nb total des pièces
    public int totalPieces = 9;

    public void CollectePiece(GameObject piece)
    {
        if(!collectedPieces.Contains(piece))
        {
            collectedPieces.Add(piece);
            Debug.Log("Pièce collectée ! Total: " + collectedPieces.Count);

            if(collectedPieces.Count == totalPieces)
            {
                Debug.Log("Toutes les pièces ont été collectées !");
                PuzzleComplete();
            }
        }
    }
    private void PuzzleComplete()
    {
        Debug.Log("Commencer le résolution du puzzle !");
    }

}
