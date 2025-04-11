using UnityEngine;
using UnityEngine.UI;

public class SelectSquare : MonoBehaviour
{
    private Color assignedColor;
    private GridManager gridManager;
    private Button button;
    private Image image;
    //private Color hiddenColor = new Color(0.6f, 0.6f, 0.6f); // default hidden gray
    private bool isMatched = false;

    void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
      //SUSPECT  button.onClick.AddListener(OnClick);
    }

    public void SetColor(Color color, GridManager manager)
    {
        gridManager = manager;
        assignedColor = color;
        image.color = assignedColor; // shows color immediately
    }
public Color AssignedColor => assignedColor;

    public void SetOutline(Color outlineColor)
    {
        // You can add an outline effect to the button here, or if using a UI element
        var outline = GetComponent<Outline>();
        if (outline != null)
        {
            outline.effectColor = outlineColor; // Set red or green outline
        }
    }

    public void MakeInvisible()
    {
        image.color = Color.grey; // Make the square invisible (transparent)
        button.interactable = false; // Disable button interaction
    }
    
    public void MatchFound()
    {
        /*
        image.color = assignedColor;
        image.GetComponent<Outline>().effectColor = Color.green;
        button.interactable = false;*/
        isMatched = true;
    }

     public void OnClick()
    {
        if (isMatched) return;
        //if (button.interactable)
        {
            gridManager.SquareClicked(this, assignedColor);
        }
    }

    public void RevealColor()
    {
        image.color = assignedColor;
        Debug.Log("Assigned color: " + assignedColor);
    }
/*
    public void HideColor()
    {
        image.color = hiddenColor;
    }
    */
    
}
