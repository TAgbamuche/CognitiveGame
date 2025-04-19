/*using UnityEngine;
using UnityEngine.UI;

public class KeyboardNavigator : MonoBehaviour
{
    public GridLayoutGroup gridLayout;
    private SelectSquare[,] squares = new SelectSquare[4, 4];
    private int x = 0, y = 0;

    void Start()
    {
        if (!AccessibilityManager.Instance.KeyboardNavEnabled) enabled = false;

        SelectSquare[] squareList = gridLayout.GetComponentsInChildren<SelectSquare>();
        int i = 0;
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (i < squareList.Length)
                {
                    squares[row, col] = squareList[i];
                    i++;
                }
            }
        }

        HighlightSquare(x, y);
    }

    void Update()
    {
        if (!AccessibilityManager.Instance.KeyboardNavEnabled) return;

        if (Input.GetKeyDown(KeyCode.RightArrow)) Move(1, 0);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Move(-1, 0);
        if (Input.GetKeyDown(KeyCode.DownArrow)) Move(0, 1);
        if (Input.GetKeyDown(KeyCode.UpArrow)) Move(0, -1);
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) squares[y, x].OnClick();
    }

    void Move(int dx, int dy)
    {
        x = Mathf.Clamp(x + dx, 0, 3);
        y = Mathf.Clamp(y + dy, 0, 3);
        HighlightSquare(x, y);
    }

    void HighlightSquare(int x, int y)
    {
        // Optionally highlight with outline
        foreach (var s in squares) s?.ClearHighlight();
        squares[y, x].SetOutline(Color.yellow); // Temporary hover
    }
}*/
