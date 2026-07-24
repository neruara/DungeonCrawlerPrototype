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
            Instantiate(explosionPrefab, explosionPoint.position, explosionPoint.rotation);
        }
        else
        {

            Debug.LogWarning("Dikkat: Patlama efekti veya cikis noktasi (Transform) atanmamis!");
        }
    }
}
