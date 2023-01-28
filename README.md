# Game-Grand-Prize
## 使用バージョン

Unity2021.3.17f1
## GitHubルール

developから各ブランチを切る。

作業が終わったらPull Requestをdevelopに出す。

Pull Requestを出したらdiscordのタスクチャンネルに通知をする。

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

・コメントアウト

メソッド関数の上と機能ごと

[例]

//コメント

void Function()
{
  //コメント
  for(int i = 0;i < 5; i++)
  ...
}

## 使用ツール

GitBash
→パソコンにインストール

・UniRx

・UniTask

・AddressableAsset

・InputAction

・DOTweenPro

・ShaderGraph
