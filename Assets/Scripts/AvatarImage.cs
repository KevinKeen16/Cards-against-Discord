using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;
using UnityEngine.UI;

public class AvatarImage : MonoBehaviour
{
    public static bool Loaded;
    // Start is called before the first frame update
    async void Start()
    {
        Loaded = false;
        var discord = DiscordGameSDK.Instance.discord;
        await DiscordGameSDK.Instance.SDKReady.Task;
        User user = discord.GetUserManager().GetCurrentUser();
        Debug.Log(user.Id);
        var handle = new ImageHandle()
        {
            Type = ImageType.User,
            Id = user.Id,
            Size = 256
        };
        discord.GetImageManager().Fetch(handle, false, (result, rere) =>
        {
            Texture avatar = discord.GetImageManager().GetTexture(handle);
            RawImage image = gameObject.GetComponent<RawImage>();
            image.texture = avatar;
            Debug.Log("User Loaded");
            Loaded = true;
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
