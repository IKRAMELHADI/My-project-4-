using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject menuUI; // Référence au GameObject du menu UI
    

    // Cette méthode est appelée lorsque le joueur clique sur "Play"
    public void StartGame()
    {
        // Masquer le menu et afficher le jeu
        menuUI.SetActive(false);
        
    }

    // Cette méthode est appelée lorsque le joueur clique sur "Quit"
    public void QuitGame()
    {
        // Quitter l'application. Cela ne fonctionne que dans la version compilée du jeu
        Application.Quit();

        // Pour tester dans l'éditeur Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

