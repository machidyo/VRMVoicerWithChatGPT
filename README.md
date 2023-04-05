# speaking-vrm-with-chatgpt-sample
VRMにしゃべってもらうことを体験するサンプルリポジトリです。

https://user-images.githubusercontent.com/1772636/229851106-14613be7-76a9-4217-979b-533e5df32237.mp4

# サンプルの概要
1. Unityを実行すると、音声入力待ちの状態になります。（上記動画では"塩の作り方を教えてください"といった後です）
2. 音声入力が完了すると、テキストで画面下に表示されます。（上記動画の"塩の作り方を教えてください"の箇所です）
3. 2に続いて、ChatGPTへテキストを基にリクエストを出してレスポンスを待ちます。（回答内容によって10秒ほどかかることがあります）
4. ChatGPTからレスポンスが返ってくると、その内容をVOICEVOXに連携して音声合成を待ちます。
5. 音声合成が完了すると、VRMのBlendshapeとOVRLipSyncを利用してVRMのアバターがしゃべりだしてくれます。（上記動画はこの5からです）

# 前提
* Windows10（音声入力がWindows前提になっています）
* Unity 2021.2.4f1
* Oculus LipSync v29

## 注意
* voicevox_engineはこのリポジトリに含まれていません（使い方を参照しくてください）
* 動画の背景は有料Assetなのでこのリポジトリ含まれていません

# 使い方
## 実行方法
1. OpenAIのAPIKeyを作成して、SampleSceneにいるTesterのInspectorのApi Keyに設定します
2. voicevox_engineをdockerで起動します。（※1）
3. Unityを実行して、ConsoleにStart speech recognition, waiting for your voice...と出てきていることを確認します
4. 話しかけてください！

※1
dockerでなくても大丈夫で、[こちら](https://voicevox.hiroshiba.jp/)で代替できます。
GUIを起動するだけ内部的にvoicevox_engineが起動されるため、それを利用できます。

### 注意
1. ときどき音声認識がうまく反応しないときがあります。その場合、再実行してみてください。

## VRMの入れ替え方
1. vrmをドラッグアンドロップでインポートします。
2. 1でインポートしたvrmをHierachyに配置します。
3. ドレ（dore）のPositionをコピーして、カメラ位置まで移動させます。
4. おそらく後ろを向いているのでY軸で180度回転させます。（doreのrotation参照）
5. ドレを削除します。

# Libraries
Library     |  License
------------|------------
[unity-voicevox-bridge](https://github.com/mikito/unity-voicevox-bridge)                    | MIT license
[voicevox_engine](https://github.com/VOICEVOX/voicevox_engine)                              | Unknown, LGPL-3.0 licenses found
[VRMLipSyncContextMorphTarget](https://github.com/TsubokuLab/VRMLipSyncContextMorphTarget)  | Unknown,
[UniVRM](https://github.com/vrm-c/UniVRM)                                                   | MIT license
[UniTask](https://github.com/Cysharp/UniTask)                                               | MIT license

# 参考にしたサイト
* [ChatGPT APIをUnityから動かす。](https://note.com/negipoyoc/n/n88189e590ac3)
* [GPT-3とVoiceVoxを活用してAIエージェントを作る！【Unity】](https://note.com/negipoyoc/n/n081e25f5ee9e)
* [VOICEVOX(音声合成)をREST-APIで利用する](https://qiita.com/A_T_B/items/1531d78944d8b796b9fa)
