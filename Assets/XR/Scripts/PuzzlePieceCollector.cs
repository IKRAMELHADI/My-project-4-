using UnityEngine;

public class PuzzlePieceCollector : MonoBehaviour
{
    private PuzzleInventory puzzleInventory;

    private void Start()
    {
        // Assurez-vous que PuzzleInventory est assigné, soit en le trouvant dans la scène, soit en le définissant manuellement dans l'inspecteur
        puzzleInventory = FindObjectOfType<PuzzleInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assurez-vous que le joueur a le tag "Player"
        {
            CollectPuzzlePiece();
        }
    }

    private void CollectPuzzlePiece()
    {
        puzzleInventory.CollectPiece();
        Destroy(gameObject); // Détruit la pièce de puzzle après collecte
    }
}
