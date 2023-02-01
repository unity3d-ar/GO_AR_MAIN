using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsPoint : MonoBehaviour
{
  // 存储地图角色
  public GameObject Ava;
  // 存储事件点预制体
  public GameObject PrePoint;
  // 存储距离的最小值
  public float MinDis = 3f;
  // 存储距离的最大值
  public float MaxDis = 50f;
  // 存储当前角色位置
  private Vector3 v3Ava;


  void Start()
  {

  }

  void Update()
  {

  }

  // 生成预制体
  public void CreatePoint()
  {
    // 获取角色位置
    v3Ava = Ava.transform.position;
    // 从距离范围中取一个随机距离值
    float _dis = Random.Range(MinDis, MaxDis);
    // 从原点为(0,0)的坐标上获取任意一个方向的向量
    Vector2 _pOri = Random.insideUnitCircle;
    // 获取到向量的单位向量，只有方向，单位为1
    Vector2 _pNor = _pOri.normalized;
    // 算出随机点的位置
    Vector3 _v3Point = new Vector3(v3Ava.x + _pNor.x * _dis, 0, v3Ava.z + _pNor.y * _dis);
    // 生成事件点
    GameObject _poiMark = Instantiate(PrePoint, _v3Point, Quaternion.identity);
  }
}
