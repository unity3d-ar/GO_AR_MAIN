using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet_Find : MonoBehaviour
{

  // 小精灵的序号
  public int Pet_Index;

  // Start is called before the first frame update
  void Start()
  {
    // 小精灵面向角色,注意只在地图场景才触发
    if (GameObject.FindWithTag("Avatar") != null)
    {
      transform.LookAt(GameObject.FindWithTag("Avatar").transform);
    }
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter(Collider other)
  {
    Debug.Log("碰到了" + other.tag);

    if (other.tag == "Avatar")
    {
      // 弹出面板
      UI_Mgr_02.Instance.SetIm_Catch(true);
      // 设置当前要捕捉的小精灵的序号
      StaticData.CatchingPetIndex = Pet_Index;
      // 销毁小精灵
      Destroy(gameObject);
    }

    // 如果碰到的是精灵球
    if (other.tag == "Ball")
    {
      PlayCatched();
      StartCoroutine(ShowCatchedPn());
    }
  }

  IEnumerator ShowCatchedPn()
  {
    yield return new WaitForSeconds(2f);
    ARUI_Mgr.Instance.Show_PnCatched();
    Destroy(gameObject);
  }

  private void PlayCatched()
  {
    // 播放捕捉动画
    transform.GetComponent<Animator>().SetTrigger("Catched");
  }
}
