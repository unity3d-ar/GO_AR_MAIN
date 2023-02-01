using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARBallCtrl : MonoBehaviour
{
  //获取精灵球预制体
  private GameObject[] balls;
  //存储生成精灵球的位置
  public Transform PosInsBall;
  //单例
  public static ARBallCtrl Instance;

  private void Awake()
  {
    Instance = this;
  }

  void Start()
  {
    //赋值
    balls = Resources.LoadAll<GameObject>("Balls");
    //刷新精灵球数量
    ARUI_Mgr.Instance.RefreshBallNum();
    InsNewBall();
  }

  //生成精灵球
  public void InsNewBall()
  {
    //判断精灵球数量是否大于0
    if (StaticData.BallNum > 0)
    {
      //随机生成精灵球
      int index = Random.Range(0, balls.Length);
      //生成精灵球
      GameObject _ball = Instantiate(balls[0], PosInsBall.position, Quaternion.identity);
      //设置精灵球的父物体
      _ball.transform.SetParent(PosInsBall);
      _ball.gameObject.AddComponent<SphereCollider>();
      _ball.gameObject.AddComponent<ARShootBall>();
      // 调整缩放比例
      _ball.transform.localScale = new Vector3(25f, 25f, 25f);
      // 调整碰撞器大小
      _ball.GetComponent<SphereCollider>().radius = 0.01f;
    }
  }
}
