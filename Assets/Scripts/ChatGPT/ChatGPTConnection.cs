using System;
using System.Collections.Generic;
using System.Text;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ChatGPTConnection
{
    private readonly string apiKey; 
    private readonly List<ChatGPTMessageModel> messages = new();

    public ChatGPTConnection(string apiKey)
    {
        this.apiKey = apiKey;
        messages.Add(new ChatGPTMessageModel { role = "system", content = "丁寧な口調" });
    }

    public async UniTask<ChatGPTResponseModel> RequestAsync(string userMessage)
    {
        messages.Add(new ChatGPTMessageModel { role = "user", content = userMessage });

        var headers = new Dictionary<string, string>
        {
            { "Authorization", "Bearer " + apiKey },
            { "Content-type", "application/json" },
            { "X-Slack-No-Retry", "1" }
        };

        var options = new ChatGPTCompletionRequestModel
        {
            model = "gpt-3.5-turbo",
            messages = messages
        };
        var jsonOptions = JsonUtility.ToJson(options);

        using var request = new UnityWebRequest("https://api.openai.com/v1/chat/completions", "POST")
        {
            uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonOptions)),
            downloadHandler = new DownloadHandlerBuffer()
        };

        foreach (var header in headers)
        {
            request.SetRequestHeader(header.Key, header.Value);
        }

        await request.SendWebRequest();

        if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
            throw new Exception();
        }
        else
        {
            var responseString = request.downloadHandler.text;
            var responseObject = JsonUtility.FromJson<ChatGPTResponseModel>(responseString);
            messages.Add(responseObject.choices[0].message);
            return responseObject;
        }
    }
}