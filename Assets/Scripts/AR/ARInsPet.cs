using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInsPet : MonoBehaviour
{

  public Transform[] tanPos;
  private GameObject[] pets;
  // 摄像机位置
  public Transform camPos;

  void Start()
  {
    pets = Resources.LoadAll<GameObject>("Pets");
    InsPet();
    checkDis();
  }

  void Update()
  {

  }

  public void InsPet()
  {
    int indexPos = Random.Range(0, tanPos.Length);
    GameObject _pet = Instantiate(pets[StaticData.CatchingPetIndex], tanPos[indexPos].transform.position, Quaternion.identity);
    // 调整缩放比例
    _pet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    // _pet.transform.SetParent(tanPos[indexPos]);
    // _pet.gameObject.AddComponent<SphereCollider>();
    // 生成的小精灵面向摄像机
    _pet.transform.LookAt(new Vector3(camPos.position.x, _pet.transform.position.y, camPos.position.z));

  }

  private void checkDis()
  {
    foreach (Transform _tan in tanPos)
    {
      float _dis = Vector3.Distance(_tan.position, camPos.position);
      Debug.Log(_dis);
    }
  }
}
