/*
Author: Ewere Agbamuche
Logic for the Memory CoLOR gAME
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorMemory : MonoBehaviour
{
    public Image colorDisplay; //object to show color
    public TMP_Dropdown dropdown; // dropdown menu gamet,p
    public TextMeshProUGUI feedbackText;
    public GameObject MemoryPanel;
    private Color currentColor;
    private string correctColorName;
    private Dictionary<Color, string> colorNameMap = new Dictionary<Color, string>();

    private List<Color> colorList = new List<Color>();

    void Start()
    {
        MemoryPanel.SetActive(false);

        // The color-name pairs
        AddColor(new Color(1f, 1f, 0f), "Yellow");
        AddColor(new Color(0f, 0f, 0f), "Black");
        AddColor(new Color(0f, 0f, 1f), "Blue");
        AddColor(new Color(1f, 1f, 1f), "White");
        AddColor(new Color(0.5f, 0f, 0.5f), "Purple");
        AddColor(new Color(1f, 0.5f, 0f), "Orange");
        AddColor(new Color(0f, 1f, 0f), "Green");
        AddColor(new Color(1f, 0f, 0f), "Red");

        // Populate dropdown
        dropdown.ClearOptions();
        dropdown.AddOptions(new List<string>(colorNameMap.Values));
        dropdown.gameObject.SetActive(false);
    }

    /*Maps the color */
    void AddColor(Color color, string name)
    {
        colorList.Add(color);
        colorNameMap[color] = name;
    }

    public void StartMemoryGame()
    {
        MemoryPanel.SetActive(true);
        StartCoroutine(ShowColorRoutine());
    }

    IEnumerator ShowColorRoutine()
    {
        feedbackText.text = "";
        dropdown.gameObject.SetActive(false);
        
        int index = Random.Range(0, colorList.Count);
        currentColor = colorList[index];
        correctColorName = colorNameMap[currentColor];

        colorDisplay.color = currentColor;
        colorDisplay.gameObject.SetActive(true);

        yield return new WaitForSeconds(4f); // show for 4 seconds

        colorDisplay.gameObject.SetActive(false);
        dropdown.gameObject.SetActive(true);
    }

    public void SubmitAnswer()
    {
        string selectedAnswer = dropdown.options[dropdown.value].text;
        if (selectedAnswer == correctColorName)
        {
            feedbackText.text = "Correct!";
        }
        else
        {
            feedbackText.text = $" Oops! The correct answer was {correctColorName}.";
        }

        // Optionally: delay before next round or exit
        StartCoroutine(NextRoundDelay());
    }

    IEnumerator NextRoundDelay()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(ShowColorRoutine()); // or exit, or go back to menu
    }
}

