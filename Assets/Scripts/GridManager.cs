// this script handles the creation of the grid and matching

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.Collections; 
using System.Reflection;

public class GridManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //tracks score
    public TextMeshProUGUI timerText; //tracks time
    public TextMeshProUGUI levelText; //tracks the level
    public Button hintButton; //need help?
    private int score = 0;
    private int level = 1;
    //public float startTime = 120f; // 2 minutes
    //private float remainingTime;
    //private bool isGameActive = true;
    private int matchStreak = 0;
    public GameObject squarePrefab; //each square grid
    public Transform GridPanel; //contains the grid
    public Color[] colors; // Add 8 pairs of colors in Inspector
    public TextMeshProUGUI promptText; //
    private List<GameObject> gridSquares = new List<GameObject>();
    private SelectSquare firstSelected; //first selection
    private SelectSquare secondSelected; //second selection
    private Dictionary<string, string> ColorNames = new Dictionary<string, string>() //all the colors in gridManager
{
    { "#00FF00", "Green" },
    { "#FFFF00", "Yellow" },
    { "#800080", "Purple" },
    { "#FF8000", "Orange" },
    { "#000000", "Black" },
    { "#FF0000", "Red" },
    { "#FFFFFF", "White" },
    { "#0000FF", "Blue" }
};

    void Start()
    {
        //remainingTime = startTime;
        GenerateGrid();
        levelText.text = "Level: " + level.ToString();
        //hintButton.onClick.AddListener(ShowHint);
    }

    void GenerateGrid()
    {
        // Create grid squares
            List<Color> shuffledColors = new List<Color>();

    // Add 8 pairs of colors to the list
    foreach (Color color in colors)
    {
        shuffledColors.Add(color);
        shuffledColors.Add(color); // Duplicate for matching pair
  
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

 public string GetColorName(Color color)
{
    string hex = "#" + ColorUtility.ToHtmlStringRGB(color);

    // First check if its in the custom color name map
    if (ColorNames.TryGetValue(hex, out string customName))
    {
        return customName;
    }

    // Try match against Unity built-in color names
    foreach (PropertyInfo prop in typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static))
    {
        if (prop.PropertyType == typeof(Color))
        {
            Color namedColor = (Color)prop.GetValue(null, null);
            if (Mathf.Approximately(color.r, namedColor.r) &&
                Mathf.Approximately(color.g, namedColor.g) &&
                Mathf.Approximately(color.b, namedColor.b))
            {
                return prop.Name; // e.g., "Red", "Green"
            }
        }
    }

    // Fallback to hex
    return hex;
}

    public void SquareClicked(SelectSquare square, Color color)
    {
        //selecting the first square
        if (firstSelected == null)
        {
            firstSelected = square;
            // Choose outline color for contrast. outline is white for black 
            Color outlineColor = (square.AssignedColor == Color.black) ? Color.white : Color.black;
            firstSelected.SetOutline(outlineColor);
            return;//promptText.text = "Select another square...";
        }

        // If player clicks the same square again → deselect it
        if (square == firstSelected)
        {
            firstSelected.SetOutline(Color.clear);
            firstSelected = null;
            promptText.text = "Selection cleared.";
            return;
        }
      
        if (secondSelected == null && square != firstSelected)
        {
            secondSelected = square;
            secondSelected.SetOutline(Color.black); // Set outline red for incorrect match

            // checks if the two selection made were the same. 
            if (firstSelected.AssignedColor == secondSelected.AssignedColor)
            {
                matchStreak++;
                int pointsToAdd = 10;
                if (matchStreak==3){
                    pointsToAdd += 10;
                    matchStreak=0; //resets the counter for no of matches
                }
                score += pointsToAdd; //aggregrate total score
                UpdateScoreUI();

                promptText.text = $" Color {GetColorName(color)} was matched!";
                firstSelected.MatchFound();
                secondSelected.MatchFound();
                 // Green outline and grey out squares after a correct match
                firstSelected.SetOutline(Color.green);
                secondSelected.SetOutline(Color.green);
            }
            else
            {
                matchStreak = 0;
                score -= 5;
                UpdateScoreUI();
                promptText.text = "Incorrect match. Not the same color!";
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
    //The function handles the display of the score 
    void UpdateScoreUI()
    {
        scoreText.text = "Current Score: " + score.ToString();
    }

    //handles GameOver from UIManager
    public void HandleGameOver()
{
    Debug.Log("Game Over triggered from UIManager");
    promptText.text = "Time's up!";
    // Optional: Disable grid or add "Restart" UI here
    foreach (var squareGO in gridSquares)
    {
        squareGO.GetComponent<Button>().interactable = false;
    }
}

// restart the game

}