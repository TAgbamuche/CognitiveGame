using UnityEngine;

public class InstructionPopUp : MonoBehaviour
{
    public GameObject instructionPanel;

    // Called when the Start Game button is clicked
    public void StartGame()
    {
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(false); // Just hides it — does NOT delete it
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
        }
    }
}
