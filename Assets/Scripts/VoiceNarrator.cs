/*using UnityEngine;
using System.Collections.Generic;

public class VoiceNarrator : MonoBehaviour
{
    public static VoiceNarrator Instance;

    public AudioSource audioSource;

    [System.Serializable]
    public struct ColorAudio
    {
        public string name;
        public AudioClip clip;
    }

    public List<ColorAudio> colorClips;
    public AudioClip matchClip;
    public AudioClip noMatchClip;

    private Dictionary<string, AudioClip> colorDict;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        colorDict = new Dictionary<string, AudioClip>();
        foreach (var item in colorClips)
        {
            colorDict[item.name.ToLower()] = item.clip;
        }
    }

    public void PlayColor(string colorName)
    {
        if (!AccessibilityManager.Instance.AudioCuesEnabled) return;

        if (colorDict.TryGetValue(colorName.ToLower(), out AudioClip clip))
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void PlayMatch() => audioSource.PlayOneShot(matchClip);
    public void PlayNoMatch() => audioSource.PlayOneShot(noMatchClip);
}
*/