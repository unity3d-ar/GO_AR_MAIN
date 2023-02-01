using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 静态类，管理所有的全局静态数据
public static class StaticData
{
  // 玩家默认的精灵球数量
  public static int BallNum = 5;
  // 当前正要捕捉的小精灵在预制体集合中的索引
  public static int CatchingPetIndex;
  // 玩家已经捕捉到的小精灵集合
  public static List<PetSave> PetList = new List<PetSave>();

  /// <summary>
  /// 往全局数据的小精灵集合中添加一个小精灵
  /// </summary>
  /// <param name="_pet"></param>
  public static void AddPet(PetSave _pet)
  {
    PetList.Add(_pet);
  }

  /// <summary>
  /// 通过小精灵的序号获得类型
  /// </summary>
  /// <param name="_index"></param>
  /// <returns></returns>
  public static string GetType(int _index)
  {
    switch (_index)
    {
      case 0:
        return "火";
      case 1:
        return "水";
      case 2:
        return "草";
      case 3:
        return "电";
      case 4:
        return "冰";
      case 5:
        return "毒";
      case 6:
        return "地面";
      case 7:
        return "飞行";
      case 8:
        return "超能力";
      case 9:
        return "虫";
      case 10:
        return "恶";
      case 11:
        return "钢";
      case 12:
        return "幽灵";
      case 13:
        return "龙";
      case 14:
        return "格斗";
      case 15:
        return "岩石";
      case 16:
        return "妖精";
      default:
        return "未知";
    }
  }
}
