using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.Collections; 

public class GridManager : MonoBehaviour
{
    public GameObject squarePrefab;
    public Transform GridPanel;
    public Color[] colors; // Add 8 pairs of colors in Inspector
    public TextMeshProUGUI promptText;

    //private List<Color> shuffledColors = new List<Color>();
    private List<GameObject> gridSquares = new List<GameObject>();
    private SelectSquare firstSelected;
    private SelectSquare secondSelected;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // Create grid squares
            List<Color> shuffledColors = new List<Color>();

    // Add 8 pairs of colors to the list
    foreach (Color color in colors)
    {
        shuffledColors.Add(color);
        shuffledColors.Add(color); // Duplicate for matching pairs
    }

    // Shuffle the colors randomly
    System.Random random = new System.Random();
    shuffledColors = shuffledColors.OrderBy(x => random.Next()).ToList();
    //check color application
     Debug.Log("Shuffled Colors: " + string.Join(", ", shuffledColors.Select(c => c.ToString()).ToArray()));

    // Now assign the shuffled colors to the grid squares
    for (int i = 0; i < 16; i++)
    { 
            GameObject squareGO = Instantiate(squarePrefab, GridPanel);
            SelectSquare squareScript = squareGO.GetComponent<SelectSquare>();
            squareScript.SetColor(shuffledColors[i], this); // sets color and passes it to grid manager
            // Assign color and pass this GridManager reference to each square
            Button button = squareGO.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => squareScript.OnClick());
            }       
            gridSquares.Add(squareGO);
    }
 }

    public void SquareClicked(SelectSquare square, Color color)
    {
        //if (square == null) return; 

        if (firstSelected == null)
        {
            firstSelected = square;
           // firstSelected.RevealColor();
            firstSelected.SetOutline(Color.black); // Set red outline for incorrect match
            return;//promptText.text = "Select another square...";
        }
        if (secondSelected == null && square != firstSelected)
        {
            secondSelected = square;
            //square.RevealColor();
            //secondSelected.RevealColor();
            secondSelected.SetOutline(Color.black); // Set outline red for incorrect match

            if (firstSelected.AssignedColor == secondSelected.AssignedColor)
            {
                promptText.text = $"{color} was matched!";
                firstSelected.MatchFound();
                secondSelected.MatchFound();
                 // Green outline and grey out squares after a correct match
                firstSelected.SetOutline(Color.green);
                secondSelected.SetOutline(Color.green);

                //firstSelected.MakeInvisible();
              //  secondSelected.MakeInvisible();
            }
            else
            {
                promptText.text = "Not the same color!";
                firstSelected.SetOutline(Color.red);
                secondSelected.SetOutline(Color.red);
              //  StartCoroutine(HideAfterDelay(0.8f));
            }

            // Reset for next round SUSPECT
             StartCoroutine(ResetSelectionAfterDelay(0.8f));
        }
    }

    private IEnumerator ResetSelectionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Reset outlines before clearing the selections
        if (firstSelected != null)
        {
        firstSelected.SetOutline(Color.clear); // Or reset to no outline
        }
        if (secondSelected != null)
        {
        secondSelected.SetOutline(Color.clear);
}
        firstSelected = null;
        secondSelected = null;
    }

    private IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        promptText.text = "";
    }
}
