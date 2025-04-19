// The scrript file displays the player's name and avatar on scenes attached to!

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayPlayerInfo : MonoBehaviour
{
    public TMP_Text nameText;
    public Image avatarImage;

    void Start()
    {
        nameText.text = PlayerInfo.Instance.playerName;
        avatarImage.sprite = PlayerInfo.Instance.avatar;
    }
}
