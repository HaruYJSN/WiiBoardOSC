# WiiBoardOSC
バランスWiiボードから取得した重心をOSCで転送するソフトウェアです.

# HowtoUse
## 接続
以下のソフトウェアを使用し,お使いのコンピュータと接続してください.  
http://tyche.pu-toyama.ac.jp/~a-urasim/wiimote/
## Bluetooth接続
Bluetoothタブ内のConnectをクリックし,接続してください.  
中央に黒い窓が出てきたら接続成功です.  
バランスWiiボードに乗ると重心を示す赤い点が出てきます.  
## OSC接続
### 当ソフトとTouchOSCの接続
#### 当ソフト
OSCタブを選択し,TouchOSCが動いているPCのIPアドレスを指定してください.同じPCで動かす場合は127.0.0.1のままで構いません.  
Connectボタンを押すと送信動作が開始します.  
#### TouchOSC
Editタブ→Connectionsを選択し,以下のように設定します
##### Connection1
- Host: 当ソフトが動いているPCのIPアドレス
- Receive Port: 8000
##### Connection2
- Host: VRChatが動いているPCのIPアドレス
- Send Port: 9000

同梱のVRC_BalanceWiiBoard2.toscを読み込み,再生ボタンを押し,スタートしてください.  
体重移動でVRChat上のアバターが動きます.