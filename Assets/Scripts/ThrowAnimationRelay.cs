using UnityEngine;

public class ThrowAnimationRelay : MonoBehaviour
{
    public void FireProjectileEvent()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.FirePendingProjectile();
        }
    }
}