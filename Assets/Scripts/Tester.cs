using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private string apiKey;
    [SerializeField] private VoiceVoxRequester voiceVoxRequester;
    [SerializeField] private TextMeshProUGUI text;
    
    private WinSpeechRecognition winSpeechRecognition;
    
    void Start()
    {
        winSpeechRecognition = new WinSpeechRecognition();
        winSpeechRecognition.OnDictationResult += (t, c) =>
        {
            Debug.Log("YOU:" + t);
            text.text = t;
            RequestChatGPT(t).Forget();
        };
        winSpeechRecognition.StartSpeechRecognition();
    }

    private async UniTask RequestChatGPT(string asking)
    {
        var client = new ChatGPTConnection(apiKey);
        // var response = await client.RequestAsync("はじめまして、こんにちは。今日は何をしたらいいか教えてください。");
        var response = await client.RequestAsync(asking);
        Debug.Log("AI:" + response.choices[0].message.content);
        
        await voiceVoxRequester.PlayVoice(response.choices[0].message.content);
    }
}
