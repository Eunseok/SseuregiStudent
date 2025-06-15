using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private float progress = 0f;
    public float travelTime = 0.5f; // 전체 비행 시간
    public float arcHeight = 1.5f;

    private bool launched = false;

    public void Fire(Transform enemy)
    {
        target = enemy;
        if (target == null) return;

        startPoint = transform.position;
        endPoint = target.position;
        launched = true;
    }

    void Update()
    {
        if (!launched || target == null) return;

        progress += Time.deltaTime / travelTime;
        progress = Mathf.Clamp01(progress);

        // Lerp로 기본 위치 보간
        Vector3 linearPos = Vector3.Lerp(startPoint, endPoint, progress);

        // 포물선 높이 추가
        float heightOffset = Mathf.Sin(progress * Mathf.PI) * arcHeight;
        linearPos.y += heightOffset;

        transform.position = linearPos;

        if (progress >= 0.9f)
        {
            if (target != null)
                target.GetComponent<EnemyController>().HitByProjectile();

            Destroy(gameObject);
        }
    }
}