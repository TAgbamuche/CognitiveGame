// script creates the avatar
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ProfileCreation : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Image selectedAvatarPreview;
    public Sprite[] avatarOptions;
    //public GameObject avatarSelectionPanel;
    private Sprite chosenAvatar;
    public  TMP_Text profilecreated;
     private int currentAvatarIndex = 0;

    void Start()
    {
        if (avatarOptions.Length > 0)
        {
            SelectAvatar(currentAvatarIndex);
        }
    }

    //select an avatar
    public void SelectAvatar(int index)
    {
        if (index >= 0 && index < avatarOptions.Length)
        {
            currentAvatarIndex = index;
            chosenAvatar = avatarOptions[index];
            selectedAvatarPreview.sprite = chosenAvatar;
        }
    }
    public void NextAvatar()
    {
        currentAvatarIndex = (currentAvatarIndex + 1) % avatarOptions.Length;
        SelectAvatar(currentAvatarIndex);
    }

    public void PreviousAvatar()
    {
        currentAvatarIndex = (currentAvatarIndex - 1 + avatarOptions.Length) % avatarOptions.Length;
        SelectAvatar(currentAvatarIndex);
    }
    public void SaveProfile()
    {
        PlayerInfo.Instance.playerName = nameInput.text;
        PlayerInfo.Instance.avatar = chosenAvatar;
        profilecreated.text = "Profile Created!";

    }

    public void GoToHome()
    {
        SaveProfile();
        SceneManager.LoadScene("HomeScene"); // Change to your actual home scene name
    }
}
