using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private int numberOfTasksToComplete;  // Nombre de pièces pour compléter le puzzle
    [SerializeField] private int currentlyCompletedTasks = 0;

    [Header("Timer Settings")]
    [SerializeField] private float puzzleTimeLimit = 60f;  // Temps limite en secondes
    private float timeRemaining;
    private bool puzzleStarted = false;
    private bool puzzleCompleted = false;

    [Header("Completion Events")]
    public UnityEvent onPuzzleCompletion;  // Événement en cas de réussite
    public UnityEvent onPuzzleFailure;     // Événement en cas d'échec (temps écoulé)

    private void Start()
    {
        timeRemaining = puzzleTimeLimit;
    }

    private void Update()
    {
        if (puzzleStarted && !puzzleCompleted)
        {
            UpdateTimer();
        }
    }

    public void StartPuzzle()
    {
        if (!puzzleStarted)
        {
            puzzleStarted = true;
            puzzleCompleted = false;
            timeRemaining = puzzleTimeLimit;
            currentlyCompletedTasks = 0;
            Debug.Log("Le puzzle a commencé !");
        }
    }

    private void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            GameOver(false);  // Temps écoulé, le joueur a échoué
        }
    }

    private void UpdateTimerUI()
    {
        // Débogage : Affiche le temps restant dans la console
        Debug.Log("Temps restant : " + Mathf.Ceil(timeRemaining) + " secondes");
    }

    private void GameOver(bool success)
    {
        puzzleCompleted = true;
        puzzleStarted = false;

        if (success)
        {
            Debug.Log("Puzzle terminé avec succès !");
            onPuzzleCompletion.Invoke();  // Invoquer l'événement de réussite
        }
        else
        {
            Debug.Log("Temps écoulé ! Échec du puzzle.");
            onPuzzleFailure.Invoke();  // Invoquer l'événement d'échec
        }
    }

    public void CompletedPuzzleTask()
    {
        if (!puzzleStarted) return;

        currentlyCompletedTasks++;
        Debug.Log("Pièce de puzzle collectée. Nombre actuel : " + currentlyCompletedTasks);

        CheckForPuzzleCompletion();
    }

    private void CheckForPuzzleCompletion()
    {
        if (currentlyCompletedTasks >= numberOfTasksToComplete)
        {
            GameOver(true);  // Puzzle réussi
        }
    }

    public void PuzzlePieceRemoved()
    {
        if (currentlyCompletedTasks > 0)
        {
            currentlyCompletedTasks--;
            Debug.Log("Pièce de puzzle retirée. Nombre actuel : " + currentlyCompletedTasks);
        }
    }
}

