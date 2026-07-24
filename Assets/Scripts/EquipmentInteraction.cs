using UnityEngine;

public class EquipmentInteraction: MonoBehaviour
{
    [Header ("Interaction Settings")]
    public float interactionDistance = 3f;
    [Header ("References")]
    public GameObject playerSword;
    public GameObject playerOrb;
    private Camera mainCam;

    void Start(){
        mainCam = Camera.main;
        if(playerSword != null) {
            playerSword.SetActive(false);
        }
        if(playerOrb != null) {
            playerOrb.SetActive(false);
        }
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.E)){
            TryInteract();
        }
    }
    void TryInteract(){
        Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
        RaycastHit hitInfo;
        if(Physics.Raycast (ray, out hitInfo, interactionDistance)){
            if(hitInfo.collider.CompareTag("SwordPickup")){
                if(playerOrb.activeInHierarchy == false){
                    Destroy(hitInfo.collider.gameObject);
                    playerSword.SetActive(true);
                }
            }
            if(hitInfo.collider.CompareTag("OrbPickup")){
                if(playerSword.activeInHierarchy == false){
                Destroy(hitInfo.collider.gameObject);
                playerOrb.SetActive(true);
                }
            }
        }
    }
}
