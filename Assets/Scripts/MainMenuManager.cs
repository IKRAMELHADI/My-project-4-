using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject menuUI; // Référence au menu principal
    public PuzzleManager puzzleManager; // Référence au PuzzleManager pour démarrer le minuteur

    // Méthode appelée lors du clic sur "Start"
    public void StartGame()
    {
        menuUI.SetActive(false); // Cache le menu principal
        puzzleManager.StartPuzzleTimer(); // Démarre le minuteur du puzzle
    }

    // Méthode appelée lors du clic sur "Quit"
    public void QuitGame()
    {
        Application.Quit();

        // Pour tester dans l'éditeur Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
