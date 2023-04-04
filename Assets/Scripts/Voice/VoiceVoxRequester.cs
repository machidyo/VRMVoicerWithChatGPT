using Cysharp.Threading.Tasks;
using UnityEngine;
using VoicevoxBridge;

public class VoiceVoxRequester : MonoBehaviour
{
    [SerializeField] private VOICEVOX voicevox;
    
    async void Start()
    { 
        // await TestVoice();
    }

    public async UniTask PlayVoice(string message)
    {
        Debug.Log("Dore:" + message);
        await voicevox.PlayOneShot(8, message); // 8 = 春日部つむぎ
    } 
    
    public async UniTask TestVoice()
    {
        var message = "テストだにゃー";
        Debug.Log("TEST:" + message);
        await voicevox.PlayOneShot(1, message);
    } 
}
