using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Find : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Avatar") {
            // 新增UI数量
            UI_Mgr_02.Instance.AddFoodNum();
            // 销毁食物
            Destroy(gameObject);
        }
    }
}
