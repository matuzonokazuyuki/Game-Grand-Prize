# Game-Grand-Prize
## 使用バージョン

Unity2021.3.17f1
## 使用ツール

GitBash
→パソコンにインストール

・UniRx

・UniTask

・AddressableAsset

・InputAction

・DOTweenPro

・ShaderGraph

## コーディングルール

### 命名規則

・変数

ローワーキャメルケースでヘッダーをつける。
public変数はなし

[例]

[SerializeField,Header("変数の説明")]

private int temp;

・メソッド関数、クラス名

アッパーキャメルケース

[例]

public class Scripts

public void Function()

・引数

ローワーキャメルケースで先頭に_を入れる

[例]

void Function(_variable)
