using UnityEngine;

public class EquipmentInteraction: MonoBehaviour
{
    [Header ("Interaction Settings")]
    public float interactionDistance = 3f;
    [Header ("References")]
    //public GameObject playerSword, playerOrb, pedestalSword, pedestalOrb;
    public GameObject [] playerWeapons;
    public GameObject [] weaponStructures;
    private Camera mainCam;


    void Start(){
        mainCam = Camera.main;
        if(playerWeapons[0] != null) {
            playerWeapons[0].SetActive(false);
        }
        if(playerWeapons[1] != null) {
            playerWeapons[1].SetActive(false);
        }
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.E)){
            TryInteract();
        }
        if (Input.GetKeyDown(KeyCode.F)){
            DropItem();
        }
    }
    void TryInteract(){
        Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
        RaycastHit hitInfo;
        if(Physics.Raycast (ray, out hitInfo, interactionDistance)){
            if(hitInfo.collider.CompareTag("SwordPickup")){
                if(playerWeapons[1].activeInHierarchy == false){
                    weaponStructures[0].SetActive(false);
                    playerWeapons[0].SetActive(true);
                    
                }
            }
            if(hitInfo.collider.CompareTag("OrbPickup")){
                if(playerWeapons[0].activeInHierarchy == false){
                    weaponStructures[1].SetActive(false);
                    playerWeapons[1].SetActive(true);
                    
                }
            }
        }
    }
    void DropItem(){
       foreach (GameObject weapon in playerWeapons){
        if (weapon != null){
            foreach (GameObject weaponStruct in weaponStructures){
                weaponStruct.SetActive(true);
                weapon.SetActive(false);
            }
        }
       }
    }
}
