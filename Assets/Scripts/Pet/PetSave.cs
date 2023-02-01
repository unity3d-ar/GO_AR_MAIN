using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSave
{
  // 小精灵名字
  private string strName = "未命名宠物";
  // 小精灵序号
  private int petIndex = 0;

  // 小精灵名字的属性
  public string PetName
  {
    get
    {
      return strName;
    }

    set
    {
      strName = value;
    }
  }

  // 小精灵序号的属性
  public int PetIndex
  {
    get
    {
      return petIndex;
    }

    set
    {
      petIndex = value;
    }
  }

  /// <summary>
  /// 构造函数
  /// </summary>
  /// <param name="_name">为命名传入的参数</param>
  /// <param name="_index">为序号传入的参数</param>
  public PetSave(string _name, int _index)
  {
    PetName = _name;
    PetIndex = _index;
  }
}
