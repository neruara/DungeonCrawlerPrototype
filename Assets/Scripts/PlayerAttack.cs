using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header ("References")]
    public Animator swordAnimator;
    public Animator orbAnimator;
    public GameObject explosionPrefab;
    public Transform explosionPoint;



    void Update()
    {
        //Sword Animations
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
        //Orb Animations
        if (Input.GetMouseButtonDown(1)){
            if(orbAnimator != null){
                orbAnimator.SetBool("OrbCharge",true);
            }
        }
        if (Input.GetMouseButtonDown(0)){
            if(orbAnimator != null){
                if(orbAnimator.GetBool("OrbCharge") == true){
                    orbAnimator.SetTrigger("OrbChargeAttack");
                    orbAnimator.SetBool("OrbCharge",false);
                }
                else if (orbAnimator.GetBool("OrbCharge") == false){
                    orbAnimator.SetTrigger("OrbAttack");
                }
               
            }
        
        }
        
       
    }
    public void ExplosionTrigger(){
        if (explosionPrefab != null && explosionPoint != null){
            Instantiate(explosionPrefab, explosionPoint.position, explosionPoint.rotation);
        }
    }
}
