# WiiBoardOSC
バランスWiiボードから取得した重心をOSCで転送するソフトウェアです.

# HowtoUse
## バランスWiiボードとの接続
以下のソフトウェアを使用し,バランスWiiボードとお使いのコンピュータと接続してください.  
http://tyche.pu-toyama.ac.jp/~a-urasim/wiimote/
## Bluetooth接続
Bluetoothタブ内のConnectをクリックし,接続してください.  
中央に黒い窓が出てきたら接続成功です.  
バランスWiiボードに乗ると重心を示す赤い点が出てきます.  
## OSC接続
OSCタブを選択し,VRChatが動いているPCのIPアドレスを指定してください.同じPCで動かす場合は127.0.0.1のままで構いません.  
Connectボタンを押すと送信動作が開始します.  
体重移動でVRChat上のアバターが動きます.
# 問題点
VRChatの仕様により,VRモード時にOSCを使用して移動しているときは腕がロックされるようです.  
Cannyにもこの問題が上がっています.  
https://feedback.vrchat.com/feature-requests/p/osc-locks-arms