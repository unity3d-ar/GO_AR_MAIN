using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login_UI : MonoBehaviour
{
  void Start()
  {

  }

  void Update()
  {

  }

  public void Btn_ToMap()
  {
    // 跳转到地图场景
    SceneManager.LoadScene("Map_Scn");
  }
}
