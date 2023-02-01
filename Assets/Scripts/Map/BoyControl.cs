using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyControl : MonoBehaviour
{

  //储存动画控制器
  private Animator animator;
  //储存角色移动类
  private MoveAvatar moveAvatar;

  void Start()
  {
    //获取动画控制器
    animator = gameObject.GetComponent<Animator>();
    //获取角色移动类, 在父物体上面
    moveAvatar = transform.parent.GetComponent<MoveAvatar>();
  }

  void Update()
  {
    //判断动画状态
    if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Idle)
    {
      if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
      {
        //播放Idle动画
        animator.SetTrigger("Idle");
      }
    }
    else if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Walk)
    {
      if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
      {
        //播放Walk动画
        animator.SetTrigger("Walk");
      }
    }
    else if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Run)
    {
      if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
      {
        //播放Run动画
        animator.SetTrigger("Run");
      }
    }
  }
}
