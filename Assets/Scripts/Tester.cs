using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private string apiKey;
    [SerializeField] private Zunda zunda;
    [SerializeField] private TextMeshProUGUI text;
    
    private WinSpeechRecognition winSpeechRecognition;
    
    async void Start()
    {
        winSpeechRecognition = new WinSpeechRecognition();
        winSpeechRecognition.OnDictationResult += (t, c) =>
        {
            Debug.Log("YOU:" + t);
            text.text = t;
            RequestChatGPT(t).Forget();
        };
        winSpeechRecognition.StartSpeechRecognition();

        // await zunda.TestVoice();
    }

    private async UniTask RequestChatGPT(string asking)
    {
        var client = new ChatGPTConnection(apiKey);
        // var response = await client.RequestAsync("はじめまして、こんにちは。今日は何をしたらいいか教えてください。");
        var response = await client.RequestAsync(asking);
        Debug.Log("AI:" + response.choices[0].message.content);
        
        await zunda.PlayVoice(response.choices[0].message.content);
    }
}
