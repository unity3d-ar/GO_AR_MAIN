using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARShootBall : MonoBehaviour
{

  // 设置小球向前的力的大小
  public float FwdForce = 200f;
  // 设置一个夹角的参照数值
  public Vector3 StanTra = new Vector3(0, 1f, 0);


  // 是否允许手指滑动
  private bool blTouched = false;
  // 是否允许精灵球的发射
  private bool blShooted = false;
  // 手指滑动的起始点
  private Vector3 startPosition;
  // 手指滑动的终点
  private Vector3 endPosition;
  // 记录手指滑动的距离
  private float disFlick;
  // 记录滑动的偏移向量
  private Vector3 offset;
  // 记录滑动时间
  private int timeFlick;
  // 记录滑动的速度
  private float speedFlick;
  // 记录主摄像机
  private Camera mainCamera;

  void Start()
  {
    // 获取主摄像机
    mainCamera = Camera.main;
  }

  void Update()
  {
    if (blTouched)
    {
      slip();
    }
  }

  // 重置参数
  private void resetVari()
  {
    // 手指按下的位置
    startPosition = Input.mousePosition;
    endPosition = Input.mousePosition;
  }

  //鼠标（手指）按下，是否触碰到脚本挂载的物体
  private void OnMouseDown()
  {
    if (blShooted == false)
    {
      blTouched = true;
    }
  }

  // 计算手指的滑动
  private void slip()
  {
    timeFlick += 25; // 时间每帧加25
    if (Input.GetMouseButtonDown(0)) // 手指按下
    {
      resetVari();
    }
    if (Input.GetMouseButton(0))
    { // 手指滑动
      // 获取手指滑动的终点
      endPosition = Input.mousePosition;
      // 计算手指滑动的距离
      disFlick = Vector3.Distance(startPosition, endPosition);
      // 计算手指滑动的偏移向量，考虑摄像机的旋转因素, 因为精灵球的发射使用的是世界坐标系
      offset = mainCamera.transform.rotation * (endPosition - startPosition);
    }
    if (Input.GetMouseButtonUp(0))
    { // 手指抬起
      // 计算手指滑动的速度
      speedFlick = disFlick / timeFlick;
      blTouched = false;
      timeFlick = 0;
      // 如果移动距离大于20并且方向是向上，则允许发射
      if (disFlick > 20 && endPosition.y - startPosition.y > 0)
      {
        shootBall();
      }
    }
  }

  // 发射精灵球
  private void shootBall()
  {
    // 添加刚体组件
    transform.gameObject.AddComponent<Rigidbody>();
    // 获取刚体组件
    Rigidbody _rigBall = transform.GetComponent<Rigidbody>();
    // 初始速度
    _rigBall.velocity = offset * 0.003f * speedFlick;
    // 给一个向着屏幕前的力
    _rigBall.AddForce(mainCamera.transform.forward * FwdForce);
    // 让精灵球旋转
    _rigBall.AddTorque(transform.right);
    // 设置精灵球的阻力
    _rigBall.drag = 0.5f;
    blShooted = true;
    // 脱离父级物体
    transform.parent = null;
    // 减少精灵球的数量
    StaticData.BallNum--;
    // 刷新精灵球的数量
    ARUI_Mgr.Instance.RefreshBallNum();
    // 延迟生成一个新的精灵球
    StartCoroutine(LateInsBall());
  }

  IEnumerator LateInsBall()
  {
    yield return new WaitForSeconds(0.2f);
    ARBallCtrl.Instance.InsNewBall();
  }
}
