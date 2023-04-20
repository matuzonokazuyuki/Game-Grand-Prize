using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ClownMovement : MonoBehaviour
{
    [SerializeField]
    GameObject knifeObject, startPoisition, endPoisition;
    [SerializeField]
    float ThrowingAngle;
    [SerializeField]
    float knifeDestroyTime;
    void Start()
    {
        StartCoroutine(RepeatThrowingKnife());
    }

    //2秒ごとに3つのナイフを連射する
    IEnumerator RepeatThrowingKnife()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                Throwingknife();
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(2f);
        }
    }

    //ナイフを投げる
    void Throwingknife()
    {
        //ナイフオブジェクトの生成
        GameObject knife = Instantiate(knifeObject, startPoisition.transform.position, Quaternion.identity);

        //射出速度を算出
        Vector3 velocity = CalculateVelocity(startPoisition.transform.position, endPoisition.transform.position, ThrowingAngle);

        //ナイフを射出
        Rigidbody rid = knife.GetComponent<Rigidbody>();
        rid.AddForce(velocity * rid.mass, ForceMode.Impulse);

        //UniRxをのObservable.Timerを使いナイフオブジェクトを消す
        Observable.Timer(System.TimeSpan.FromSeconds(knifeDestroyTime)).Subscribe(_ =>
            {
                if (knife != null)
                {
                    Destroy(knife);
                }
            });
    }

    //ナイフを投げる角度の計算
    private Vector3 CalculateVelocity(Vector3 startPoint, Vector3 endPoint, float angle)
    {
        // 射出角をラジアンに変換
        float rad = angle * Mathf.PI / 180;

        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(startPoint.x, startPoint.z), new Vector2(endPoint.x, endPoint.z));

        // 垂直方向の距離y
        float y = startPoint.y - endPoint.y;

        // 斜方投射の公式を初速度について解く
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(endPoint.x - startPoint.x, x * Mathf.Tan(rad), endPoint.z - startPoint.z).normalized * speed);
        }
    }
}
