using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using UnityEngine.UI;
using TMPro;

public class SteamProfile : MonoBehaviour
{
    [SerializeField] public RawImage profilePicture;
    [SerializeField] public TMP_Text playerName;

    async void Start()
    {
        if (!SteamClient.IsValid) return;

        playerName.text = SteamClient.Name;

        var image = await SteamFriends.GetLargeAvatarAsync(SteamClient.SteamId);

        profilePicture.texture = GetTextureFromImage(image.Value);
    }

    public static Texture2D GetTextureFromImage(Steamworks.Data.Image image)
    {
        Texture2D texture = new Texture2D((int)image.Width, (int)image.Height, TextureFormat.ARGB32, false);

        texture.filterMode = FilterMode.Trilinear;

        for (int x = 0; x < image.Width; x++)
        {
            for (int y = 0; y < image.Height; y++)
            {
                var picture = image.GetPixel(x, y);
                texture.SetPixel(x, (int)image.Height - y, new Color(picture.r / 255.0f, picture.g / 255.0f, picture.b / 255.0f, picture.a / 255.0f));
            }
        }
        texture.Apply();
        return texture;
    }
}
