using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvent : MonoBehaviour
{
  // 小精灵预制体
  private GameObject[] Pets;
  // 精灵球预制体
  public GameObject[] Balls;
  // 食物预制体
  public GameObject[] Foods;


  private void Awake()
  {
    //加载
    Pets = Resources.LoadAll<GameObject>("Pets");
    Balls = Resources.LoadAll<GameObject>("Balls");
    Foods = Resources.LoadAll<GameObject>("Foods");
  }

  void Start()
  {
    // 随机生成一个事件
    int _event = Random.Range(0, 3);
    // 生成事件
    switch (_event)
    {
      case 0:
        // 生成小精灵
        CreatePet();
        break;
      case 1:
        // 生成精灵球
        CreateBall();
        break;
      case 2:
        // 生成食物
        CreateFood();
        break;
    }
  }

  void Update()
  {

  }

  public void CreatePet()
  {
    int _petIndex = Random.Range(0, Pets.Length);
    //生成小精灵
    GameObject _pet = Instantiate(Pets[_petIndex], transform.position, Quaternion.identity);
    //设置小精灵的序号
    _pet.GetComponent<Pet_Find>().Pet_Index = _petIndex;
  }

  public void CreateBall()
  {
    int _ballIndex = Random.Range(0, Balls.Length);
    //生成精灵球
    GameObject _ball = Instantiate(Balls[_ballIndex], transform.position + new Vector3(0, 5f, 0), Quaternion.identity);
    // 设置精灵球的角度
    _ball.transform.localEulerAngles = new Vector3(-30f, 0, 0);
    // 增加球形碰撞体
    _ball.AddComponent<SphereCollider>();
    // 勾选Trigger
    _ball.GetComponent<SphereCollider>().isTrigger = true;
    // 设置球形碰撞体的大小
    _ball.GetComponent<SphereCollider>().radius = 0.011f;
    // 增加刚体
    _ball.AddComponent<Rigidbody>();
    // 冻结物理效果
    _ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    // 新增Ball_Find脚本和Move_Effect脚本
    _ball.AddComponent<Ball_Find>();
    _ball.AddComponent<MoveEffect>();
  }

  public void CreateFood()
  {
    int _foodIndex = Random.Range(0, Foods.Length);
    //生成食物
    GameObject _food = Instantiate(Foods[_foodIndex], transform.position + new Vector3(0, 5f, 0), Quaternion.identity);
    // 增加Box碰撞体
    _food.AddComponent<BoxCollider>();
    // 勾选Trigger
    _food.GetComponent<BoxCollider>().isTrigger = true;
    // 设置Box碰撞体的位置
    _food.GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
    // 设置Box碰撞体的尺寸
    _food.GetComponent<BoxCollider>().size = new Vector3(0.33f, 0.30f, 0.33f);
    // 增加刚体
    _food.AddComponent<Rigidbody>();
    // 冻结物理效果
    _food.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    // 新增Food_Find脚本和Move_Effect脚本
    _food.AddComponent<Food_Find>();
    _food.AddComponent<MoveEffect>();
  }
}
