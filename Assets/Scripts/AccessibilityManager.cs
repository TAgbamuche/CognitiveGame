/*using UnityEngine;
using UnityEngine.UI;

public class AccessibilityManager : MonoBehaviour
{
    public static AccessibilityManager Instance;

    public Toggle colorblindToggle;
    public Toggle symbolsToggle;
    public Toggle keyboardToggle;
    public Toggle audioToggle;

    public GameObject accessibilityPanel;

    public bool ColorblindMode { get; private set; }
    public bool SymbolsMode { get; private set; }
    public bool KeyboardNavEnabled { get; private set; }
    public bool AudioCuesEnabled { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // Load defaults or saved prefs
        colorblindToggle.onValueChanged.AddListener(SetColorblindMode);
        symbolsToggle.onValueChanged.AddListener(SetSymbolsMode);
        keyboardToggle.onValueChanged.AddListener(SetKeyboardNav);
        audioToggle.onValueChanged.AddListener(SetAudioCues);
    }

    public void OpenPanel() => accessibilityPanel.SetActive(true);
    public void ClosePanel() => accessibilityPanel.SetActive(false);

    void SetColorblindMode(bool value) => ColorblindMode = value;
    void SetSymbolsMode(bool value) => SymbolsMode = value;
    void SetKeyboardNav(bool value) => KeyboardNavEnabled = value;
    void SetAudioCues(bool value) => AudioCuesEnabled = value;
}
*/