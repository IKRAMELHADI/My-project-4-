using UnityEngine;
using UnityEngine.Events;

public class PuzzleInventory : MonoBehaviour
{
    public int totalPieces = 9; // Nombre total de pièces de puzzle
    private int collectedPiecesCount = 0;

    public UnityEvent onAllPiecesCollected;

    public void CollectPiece()
    {
        collectedPiecesCount++;

        if (collectedPiecesCount >= totalPieces)
        {
            onAllPiecesCollected?.Invoke(); // Déclenche l'événement quand toutes les pièces sont collectées
            Debug.Log("Toutes les pièces sont collectées !");
        }
    }

    public bool AllPiecesCollected()
    {
        return collectedPiecesCount >= totalPieces;
    }
}

