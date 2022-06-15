# WiiBoardOSC
バランスWiiボードから取得した重心をOSCで転送するソフトウェアです.

# HowtoUse
## 接続
以下のソフトウェアを使用してください.
http://tyche.pu-toyama.ac.jp/~a-urasim/wiimote/
## Bluetooth接続
Bluetoothタブ内のConnectをクリックし,接続してください.
中央に黒い窓が出てきたら接続成功です.
乗ってみると赤い点が出てきます.
## OSC接続
OSCタブを選択し,接続先を指定してください.

## TouchOSCの設定
添付の	VRC_BalanceWiiBoard2.tosc をTouchOSCに読み込ませ,OSCの入力設定から,localhost:8000からの入力を1に,localhost:9000への出力を2に入れてください.
## TouchOSCと当ソフトの接続
当ソフトのOSCタブから,Connectボタンを押し,TouchOSCの再生ボタンをクリックしてください.
接続されない場合はTouchOSCを再起動するなどしてください.