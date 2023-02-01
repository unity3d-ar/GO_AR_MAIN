using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreUIMgr : MonoBehaviour
{

  public Text[] Tx_PetNm;
  public Text[] Tx_PetType;

  // 单例
  public static StoreUIMgr Instance;

  void Awake()
  {
    Instance = this;
  }

  void Start()
  {

  }

  void Update()
  {

  }

  /// <summary>
  /// 刷新小精灵名字的显示
  /// </summary>
  /// <param name="_index">指定Text在数组中的序号</param>
  /// <param name="_name">具体要显示的名字</param>
  public void UpdatePetNm(int _index, string _name)
  {
    Tx_PetNm[_index].text = _name;
  }

  /// <summary>
  /// 刷新小精灵类型的显示
  /// </summary>
  /// <param name="_index">指定Text在数组中的序号</param>
  /// <param name="_type">具体要显示的类型</param>
  public void UpdatePetType(int _index, string _type)
  {
    Tx_PetType[_index].text = _type;
  }

  public void Btn_ToMap()
  {
    SceneManager.LoadScene("Map_Scn");
  }
}
