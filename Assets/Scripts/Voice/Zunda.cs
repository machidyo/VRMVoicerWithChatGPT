using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VoicevoxBridge;

public class Zunda : MonoBehaviour
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
        // var client = new ChatGPTConnection("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");
        // var response = await client.RequestAsync("はじめまして、こんにちは。今日は何をしたらいいか教えてください。");
        // Debug.Log("AI:" + response.choices[0].message.content);
        // var message = response.choices[0].message.content;
        
        var message = "テストだにゃー";
        Debug.Log("TEST:" + message);
        await voicevox.PlayOneShot(1, message);
    } 
}
