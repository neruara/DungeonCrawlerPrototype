using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header ("References")]
    public Animator swordAnimator;

    void Update()
    {
         if (Input.GetMouseButtonDown(1)){
            if(swordAnimator != null){
                swordAnimator.ResetTrigger("Attack");
                swordAnimator.SetBool("IsBlocking",true);
            }
        }
        else if(Input.GetMouseButtonUp(1)){
            if(swordAnimator != null) {
                swordAnimator.SetBool("IsBlocking",false);
            }
        }

        if (Input.GetMouseButtonDown(0)){
            if(swordAnimator != null){
                if(swordAnimator.GetBool("IsBlocking") == false){
                swordAnimator.SetTrigger("Attack");
                }
            }
        }
       
    }
}
