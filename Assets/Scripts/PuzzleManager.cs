using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private int numberOfTasksToComplete; // Nombre de pièces pour compléter le puzzle
    [SerializeField] private int currentlyCompletedTasks = 0;
    [SerializeField] private float timeLimit = 300f; // Limite de temps en secondes

    public GameObject winUI;  // UI de victoire
    public GameObject loseUI; // UI de défaite
    public Text timerText;    // Texte pour le minuteur

    public UnityEvent onPuzzleCompletion;  // Événement de succès du puzzle

    private bool puzzleCompleted = false;
    private float timeRemaining;
    private bool timerIsRunning = false;

    private void Start()
    {
        winUI.SetActive(false); // Cache les UIs au début
        loseUI.SetActive(false);
    }

    // Démarre le minuteur
    public void StartPuzzleTimer()
    {
        timeRemaining = timeLimit;
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                if (!puzzleCompleted)
                {
                    TimeOut(); // Déclenche l'échec si le temps est écoulé
                }
            }
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void CompletedPuzzleTask()
    {
        if (puzzleCompleted) return;

        currentlyCompletedTasks++;
        Debug.Log("Pièce de puzzle collectée. Nombre actuel : " + currentlyCompletedTasks);

        CheckForPuzzleCompletion();
    }

    private void CheckForPuzzleCompletion()
    {
        if (currentlyCompletedTasks >= numberOfTasksToComplete)
        {
            puzzleCompleted = true;
            timerIsRunning = false;
            onPuzzleCompletion.Invoke(); // Événement de victoire
            ShowWinUI(); // Affiche le message de succès
        }
    }

    public void PuzzlePieceRemoved()
    {
        currentlyCompletedTasks--;
        if (currentlyCompletedTasks < 0) currentlyCompletedTasks = 0;
        Debug.Log("Pièce de puzzle retirée. Nombre actuel : " + currentlyCompletedTasks);
    }

    private void ShowWinUI()
    {
        winUI.SetActive(true);
    }

    private void TimeOut()
    {
        loseUI.SetActive(true); // Affiche le message de défaite
        Debug.Log("Temps écoulé. Vous avez perdu.");
    }
}
