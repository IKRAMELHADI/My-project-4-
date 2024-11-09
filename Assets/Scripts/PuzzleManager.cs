using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private int numberOfTasksToComplete;  // Nombre de pièces pour compléter le puzzle
    [SerializeField] private int currentlyCompletedTasks = 0;

    

    [Header("Completion Events")]
    public UnityEvent onPuzzleCompletion;  // Événement en cas de réussite
    public GameObject winUI;




    public void CompletedPuzzleTask()
    {
  
        currentlyCompletedTasks++;
        Debug.Log("Pièce de puzzle collectée. Nombre actuel : " + currentlyCompletedTasks);

        CheckForPuzzleCompletion();
    }

    private void CheckForPuzzleCompletion()
    {
        if (currentlyCompletedTasks >= numberOfTasksToComplete)
        {
            onPuzzleCompletion.Invoke(); // Puzzle réussi ma mascotte va commencer à danser NORMALEMENT

            winUI.SetActive(true);
        }
    }

    public void PuzzlePieceRemoved()
    {
            currentlyCompletedTasks--;
            Debug.Log("Pièce de puzzle retirée. Nombre actuel : " + currentlyCompletedTasks);
        
    }
}

