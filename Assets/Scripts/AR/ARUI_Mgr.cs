using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ARUI_Mgr : MonoBehaviour
{
  // 显示精灵球数量的Text组件
  public Text Tx_BallNum;
  // 捕捉成功面板
  public GameObject PnCatched;
  // 小精灵起名的Text组件
  public Text InputPetName;

  // 单例
  public static ARUI_Mgr Instance;

  void Awake()
  {
    Instance = this;
  }

  public void Btn_GoMapScn()
  {
    SceneManager.LoadScene("Map_Scn");
  }

  // 刷新精灵球数量
  public void RefreshBallNum()
  {
    Tx_BallNum.text = StaticData.BallNum.ToString();
  }

  public void Show_PnCatched()
  {
    PnCatched.SetActive(true);
  }

  public void Btn_Yes()
  {
    // 获取玩家输入的小精灵名字
    string _name = InputPetName.text;
    // 向全局数据的小精灵列表中新增一个小精灵
    StaticData.AddPet(new PetSave(_name, StaticData.CatchingPetIndex));
    // 跳转到仓库场景
    SceneManager.LoadScene("Store_Scn");
  }

  public void Btn_GiveUp()
  {
    // 跳转到地图场景
    SceneManager.LoadScene("Map_Scn");
  }

  public void Btn_ToStore()
  {
    SceneManager.LoadScene("Store_Scn");
  }
}
