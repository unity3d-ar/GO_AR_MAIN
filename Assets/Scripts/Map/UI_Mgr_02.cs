using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Mgr_02 : MonoBehaviour
{
  public Text Tx_BallNum;
  public Text Tx_FoodNum;
  // 单例模式
  public static UI_Mgr_02 Instance;
  // 捕捉面板
  public GameObject Im_Catch;

  void Awake()
  {
    Instance = this;
  }

  private void Start()
  {
    // 刷新精灵球数量
    Tx_BallNum.text = StaticData.BallNum.ToString();
  }

  public void AddBallNum()
  {
    StaticData.BallNum++;
    Tx_BallNum.text = StaticData.BallNum.ToString();
  }

  public void AddFoodNum()
  {
    int _foodNum = int.Parse(Tx_FoodNum.text);
    _foodNum++;
    Tx_FoodNum.text = _foodNum.ToString();
  }

  public void SetIm_Catch(bool _isShow)
  {
    Im_Catch.SetActive(_isShow);
  }

  public void Btn_GoARScn()
  {
    SceneManager.LoadScene("AR_Scn");
  }

  public void Btn_ToStoreScn()
  {
    SceneManager.LoadScene("Store_Scn");
  }
}
