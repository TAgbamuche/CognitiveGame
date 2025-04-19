using UnityEngine;
public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo Instance;
    public string playerName;
    public Sprite avatar;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // This makes it persist between scenes
    }
}
