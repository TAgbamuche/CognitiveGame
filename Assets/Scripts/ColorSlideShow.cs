using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorSlideshow : MonoBehaviour
{
    [System.Serializable]
    public class ColorEntry
    {
        public string colorName;
        public Color colorValue;
    }
     public GameObject ColorPanel;

    public List<ColorEntry> colors;

    public Image colorDisplay;
    public TextMeshProUGUI colorNameText;
    private int currentIndex = 0;

    void Start()
    {
        ShowColor(currentIndex);
    }

    public void NextColor()
    {
        currentIndex = (currentIndex + 1) % colors.Count;
        ShowColor(currentIndex);
    }

    public void PreviousColor()
    {
        currentIndex = (currentIndex - 1 + colors.Count) % colors.Count;
        ShowColor(currentIndex);
    }

    void ShowColor(int index)
    {
        if (colors.Count == 0) return;

        colorDisplay.color = colors[index].colorValue;
        colorNameText.text = colors[index].colorName;
    }

    public void ClosePanel()
    {
        ColorPanel.SetActive(false);
    }

    public void OpenPanel()
    {
        ColorPanel.SetActive(true);
    }
}
