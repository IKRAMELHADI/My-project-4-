using UnityEngine;

public class PuzzleTransitionManager : MonoBehaviour
{
    public PuzzleInventory puzzleInventory;
    public Transform puzzleArea;
    public GameObject player;

    private void Start()
    {
        // Abonne la méthode TeleportToPuzzleArea à un événement que PuzzleInventory déclenche
        puzzleInventory.onAllPiecesCollected += TeleportToPuzzleArea;
    }

    private void TeleportToPuzzleArea()
    {
        // Téléporte le joueur à la zone du puzzle
        player.transform.position = puzzleArea.position;
        player.transform.rotation = puzzleArea.rotation;

        // Optionnel : Désactive le script ou l'événement après la téléportation
        puzzleInventory.onAllPiecesCollected -= TeleportToPuzzleArea;
        Debug.Log("Joueur téléporté à la zone du puzzle.");
    }
}
