using UnityEngine;
using System.Collections;

public class SpawmEntity : MonoBehaviour
{
    [SerializeField] private GameObject enemyprefab;
    [SerializeField] private float minimunmSpawmTime = 1f;
    [SerializeField] private float maximumSpawmTime = 3f;
    [SerializeField] private Vector2 spawnAreaSize = new Vector2(5f, 5f);
    [SerializeField] private GameObject spawnEffectPrefab;

    private float spawmTime;

    void Awake()
    {
        SetTimeUntilSpawm();
    }

    void Update()
    {
        spawmTime -= Time.deltaTime;
        if (spawmTime <= 0)
        {
            Vector2 spawnPos = GetRandomSpawnPos();
            StartCoroutine(SpawnWithEffect(spawnPos));
            SetTimeUntilSpawm();
        }
    }

    private void SetTimeUntilSpawm()
    {
        spawmTime = Random.Range(minimunmSpawmTime, maximumSpawmTime);
    }

    private Vector2 GetRandomSpawnPos()
    {
        Vector2 randomPos = new Vector2(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
        );

        return (Vector2)transform.position + randomPos;
    }

    private IEnumerator SpawnWithEffect(Vector2 position)
    {
        // Tạo hiệu ứng spawn
        if (spawnEffectPrefab != null)
        {
            GameObject effect = Instantiate(spawnEffectPrefab, position, Quaternion.identity);
            Destroy(effect, 2f); // xóa hiệu ứng sau 2s
        }

        // Chờ 2 giây rồi mới spawn quái
        yield return new WaitForSeconds(2f);

        Instantiate(enemyprefab, position, Quaternion.identity);
    }

    // Vẽ gizmo trong Scene view để thấy khu vực spawn
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
