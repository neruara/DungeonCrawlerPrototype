using UnityEngine;

public class EquipmentInteraction: MonoBehaviour
{
    [Header ("Interaction Settings")]
    public float interactionDistance = 3f;
    [Header ("References")]
    public GameObject playerSword;
    private Camera mainCam;

    void Start(){
        mainCam = Camera.main;
        if(playerSword != null) {
            playerSword.SetActive(false);
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
                Destroy(hitInfo.collider.gameObject);
                playerSword.SetActive(true);
            }
        }
    }
}
