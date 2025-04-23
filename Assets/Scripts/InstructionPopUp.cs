using UnityEngine;

public class InstructionPopUp : MonoBehaviour
{
    public GameObject instructionPanel;
    public GameObject gridPanel;
    public GameObject memoryPanel;

    // Called when the Start Game button for grid matching is clicked
    public void StartGridGame()
    {
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(false); // Just hides it — does NOT delete it
            //gridPanel.SetActive(true); //displays grid panel
        }
        else
        {
            Debug.LogWarning("Instruction Panel not assigned!");
        }
    }

    public void StartMemGame()
    {
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(false); // Just hides it — does NOT delete it
            //gridPanel.SetActive(true); //displays grid panel
            memoryPanel.SetActive(true); //displays grid panel
        }
        else
        {
            Debug.LogWarning("Instruction Panel not assigned!");
        }
    }

    // Optional: Call this to bring it back later
    public void ShowInstructions()
    {
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(true);
            memoryPanel.SetActive(false);
            
        }
    }
}
