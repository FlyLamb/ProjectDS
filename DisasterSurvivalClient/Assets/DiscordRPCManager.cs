using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordRPCManager : MonoBehaviour
{
    public Discord.Discord discord;
    public Activity activity;
    void Start() { // todo: do not store in plaintext!
        discord = new Discord.Discord(852909249885765742, (System.UInt64)Discord.CreateFlags.Default );

        
        
        activity = new Activity() {
            Details = "Tossing pallettes at people",
            State = "Online as " + ConArg.Get("--username"),
            Party = {
                Id= "cumparty",
                Size = {
                    CurrentSize = 1,
                    MaxSize = 99
                }
            }
        };
        StartCoroutine(UpdateStatus());
    }

    private IEnumerator UpdateStatus() {
        var activityManager = discord.GetActivityManager();
        while(true) {
            
            activityManager.UpdateActivity(activity, (w) => { 
                Debug.Log(w); 
            });
            yield return new WaitForSeconds(20);
        }
    }

    void FixedUpdate() {
        discord.RunCallbacks();
        activity.Party.Size.CurrentSize = LambWorks.Networking.Client.GameManager.players.Count;
    }

    void OnApplicationQuit() {
        discord.GetActivityManager().ClearActivity((w) => { ;});
    }
}
