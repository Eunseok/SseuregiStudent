using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    static readonly int HitHash = Animator.StringToHash("Hit");
    static readonly int DeathHash = Animator.StringToHash("Death");
    
    public float speed = 2f;
    public int health = 1;
    
    [SerializeField] Animator animator;
    [SerializeField] GameObject deathEffect;
    [SerializeField] AudioClip hitClip;

    Transform playerTarget;
    AudioSource audioSource;
    
    bool isHit;
    bool IsDie => health <= 0;

    public void Init(Transform player)
    {
        playerTarget = player;
    }

    void Awake() {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetInt("sound_on", 1);
    }

    void Update()
    {
        if (isHit || GameManager.Instance.IsGameOver) return; // 피격 중이면 멈춤

        transform.position += Vector3.left * (speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, playerTarget.position) < 1.5f)
        {
            GameManager.Instance.FailGame(); // 실패 처리
        }
    }

    public void HitByProjectile() {
        health--;
        isHit = true; 
        animator.SetTrigger(HitHash);

        if (IsDie) {
            animator.SetBool(DeathHash, true);
            StartCoroutine(DeathRoutine());
        }

        audioSource.PlayOneShot(hitClip);
    }

    IEnumerator DeathRoutine() {
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.OnEnemyKilled();
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
}