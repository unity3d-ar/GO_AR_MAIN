using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : MonoBehaviour
{
  //起始弧度参数
  public float radian = 0;
  //弧度变化
  public float perRad = 0.03f;
  //位移偏量
  public float add = 0f;
  //存储物体生成时的真实坐标
  private Vector3 posOri;

  void Start()
  {
    //获取物体生成时的真实坐标
    posOri = transform.position;
  }

  void Update()
  {
    //弧度不断的增加
    radian += perRad;
    //计算偏移量
    add = Mathf.Sin(radian);
    // 让物体浮动起来
    transform.position = posOri + new Vector3(0, add, 0);
    // 以世界坐标为旋转依据，在Y轴上旋转
    transform.Rotate(0, Time.deltaTime * 100f, 0, Space.World);
  }
}
