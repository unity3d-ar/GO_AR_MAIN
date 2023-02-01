using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreInsPet : MonoBehaviour
{

  // 宠物栏小精灵的生成点
  public Transform[] Pos;
  // 小精灵的预制体
  private GameObject[] pets;
  // 仓库中已经展示的小精灵
  private GameObject[] petsShow = new GameObject[3];

  void Awake()
  {
    pets = Resources.LoadAll<GameObject>("Pets");
  }

  void Start()
  {
    InsPet();
  }

  void Update()
  {

  }

  public void InsPet()
  {
    int _petNum = StaticData.PetList.Count;
    if (_petNum > 0)
    {
      // 生成小精灵
      for (int i = 0; i < 3; i++)
      {
        if ((_petNum - 1) < i)
        {
          // 如果小精灵数量不足3个，就不生成
          break;
        }
        PetSave _petSave = StaticData.PetList[i];
        GameObject _pet = Instantiate(pets[_petSave.PetIndex], Pos[i].transform.position, Pos[i].transform.rotation);
        // 获取小精灵的名字
        string _petNm = _petSave.PetName;
        // 刷新小精灵的名字
        StoreUIMgr.Instance.UpdatePetNm(i, _petNm);
        // 获取小精灵的类型
        string _petType = StaticData.GetType(_petSave.PetIndex);
        // 刷新小精灵的类型
        StoreUIMgr.Instance.UpdatePetType(i, _petType);
      }
    }
  }
}
