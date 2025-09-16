# スマートARドキュメントについて
本アプリはARグラス XREAL Air2 Ultra 向けに開発中の、  
ハンズフリーで操作可能な空間ドキュメント投影システムです。

# 動作環境
* Samsung Galaxy S24 Ultra
* XREAL Air2 Ultra

上記環境以外でも、XREAL向けアプリケーションが動作する環境  
（Galaxy S22、XREAL Beam Pro等）  
にて動作する可能性があります。

# Project環境
* Unity 2022.3.57f1
* ARFoundation 5.1.6
* XR Plugin Management 4.5.1
* XR Interaction Toolkit 2.6.4

Unity6000以降のバージョンではARFoundation6.xのAPI更新の影響により正常に動作しません。  
参考：https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@6.0/manual/whats-new.html  
本リポジトリを利用する場合はUnityEngine及びARFoundationのバージョンに注意してください。

# ビルド方法
基本的には最新コミットをそのままUnityで開き、  
Build Settingsからそのままビルドすれば正常にapkが出力されます。

`Assets/_KTEC/Scenes/Main.unity`をビルド対象に追加し、  
Androidプラットフォームをターゲットにビルド準備を行います。  
<img width="40%" alt="image" src="https://github.com/user-attachments/assets/f731a42d-badb-40a5-861a-a8ee952e1830" />

Project Settingsは基本的に`XR Plug-in Management/Project Validation`から、  
XREAL向けの推奨設定に準拠してください。  
<img width="40%" alt="image" src="https://github.com/user-attachments/assets/84992860-e63d-469b-80c7-f2485a6b721c" />  
<img width="40%" alt="image" src="https://github.com/user-attachments/assets/df342d62-9993-4351-9dc2-d3764e190fb4" />

Validation外の設定項目として、IL2CPPのCode生成パターンで、  
`Faster (smaller) builds`を選ばないと、apk容量制限に引っかかり  
ビルドが通らないケースがあります。  
`Player/Other Settings/Configuration`から`IL2CPP Code Generation`を`Faster (smaller) builds`に設定してください。  
<img width="60%" alt="image" src="https://github.com/user-attachments/assets/a060319c-cd2f-4c77-a90c-b72b2e965371" />

Project Settings等もプッシュしてあるため、基本的には本リポジトリをプルし  
Unityで開いてそのままビルドするだけでも通るはずです。  
何か変更を加える場合は上記設定に注意しながら、各環境に合わせて変更してください。

# 独自のドキュメントを適用するには
本アプリでのドキュメントのページ設定は  
[DocData](https://github.com/KDDI-Technology/smart_ar_document_reader/blob/main/Assets/_KTEC/Scripts/DocData.cs)というScriptableObjectにて管理されています。  
サンプルデータは`Assets/_KTEC/Documents`配下にあります。  
<img width="40%"  alt="image" src="https://github.com/user-attachments/assets/dc8287e5-9178-4675-88e8-149aff560c2a" />

新規にドキュメントデータを組み立てる場合は、  
`右クリックメニュー/Create/KTEC/DocData`から新規DocDataを生成します。  
<img width="40%"  alt="image" src="https://github.com/user-attachments/assets/a44ccda7-18da-4254-b8d4-ebedba71efb5" />

表示したいドキュメントのページを一つのフォルダにまとめます。  
DocDataのInspectorから`フォルダから画像を読み込み`をクリックするとフォルダ選択のダイアログが表示されるので、  
該当フォルダを選択するとフォルダ配下の画像ファイルを一括でロードし、配列で保持できます。
<img width="40%" alt="image" src="https://github.com/user-attachments/assets/531a3f55-d234-499d-a1bc-90e4ff37765b" />

GitHubにて公開しているバージョンでは基本的に画像ファイル（png,jpg等）しか対応していませんが、  
pdfやpptxなど別フォーマットのデータに関しては、  
下記お問い合わせよりご連絡いただければ専用カスタマイズ～納品を承ります。

# お問い合わせ先
本アプリ・リポジトリについての問い合わせや、  
企業別専用カスタマイズの依頼、pdf等別のファイルフォーマットへの対応依頼は    
[Issues](https://github.com/KDDI-Technology/smart_ar_document_reader/issues) に新スレッドを立てていただくか、  
開発者へメール( ri-fukuda@kddi-tech.com , sd3-all@kddi-tech.com )にてご連絡いただければと思います。
