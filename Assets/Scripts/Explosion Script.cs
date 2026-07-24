using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    [Header("Efekt Ayarlari")]
    public GameObject explosionPrefab;
    public Transform explosionPoint;

    public void TriggerExplosion()
    {

        if (explosionPrefab != null && explosionPoint != null)
        {
            GameObject createdExplosion = 
            Instantiate(explosionPrefab, explosionPoint.position, explosionPoint.rotation);
            Destroy (createdExplosion, 2f);
        }
        else
        {

            Debug.LogWarning("Dikkat: Patlama efekti veya cikis noktasi (Transform) atanmamis!");
        }
    }
}
