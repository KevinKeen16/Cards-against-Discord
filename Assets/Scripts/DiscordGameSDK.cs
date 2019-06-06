using Discord;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DiscordGameSDK : MonoBehaviour
{
    public Discord.Discord discord = new Discord.Discord(553923478646947853, (uint)CreateFlags.Default);
    public TaskCompletionSource<bool> SDKReady = new TaskCompletionSource<bool>();

    private static DiscordGameSDK instance;

    public static DiscordGameSDK Instance
    {
        get { return instance ?? (instance = new GameObject("DiscordGameSDK").AddComponent<DiscordGameSDK>()); }
    }

    private void Awake()
    {
        discord.SetLogHook(LogLevel.Debug, DebugLogging);
        discord.GetUserManager().OnCurrentUserUpdate += OnCurrentUserUpdate;
    }

    private void OnCurrentUserUpdate()
    {
        Debug.Log("Discord SDK Ready!");

        SDKReady.SetResult(true);
    }

    private void Update()
    {
        discord.RunCallbacks();
    }

    public void DebugLogging(LogLevel level, string message)
    {
        Debug.Log(message);
    }

    private void Start()
    {
        Debug.Log("TEST");
    }
}
