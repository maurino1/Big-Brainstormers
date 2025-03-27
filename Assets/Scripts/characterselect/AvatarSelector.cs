using UnityEngine;
using UnityEngine.UI;

public class AvatarSelector : MonoBehaviour
{
    public Image avatarDisplay; // UI Image to display selected avatar
    public Sprite[] avatarSprites; // Array to store 6 avatar images

    // Function to change avatar when a button is clicked
    public void SelectAvatar(int index)
    {
        if (index >= 0 && index < avatarSprites.Length)
        {
            avatarDisplay.sprite = avatarSprites[index]; // Change UI Image
        }
        else
        {
            Debug.LogError("Invalid Avatar Index");
        }
    }
}
