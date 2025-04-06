using Unity.Entities;
using UnityEngine;

public class EnemySpawnerAuthoring : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 4f;
    public int maxEnemies = 5;

    public class Baker : Baker<EnemySpawnerAuthoring>
    {
        public override void Bake(EnemySpawnerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);

            AddComponent(entity, new EnemySpawner
            {
                spawnRate = authoring.spawnRate,
                nextSpawnTime = 0f,
                enemyPrefab = GetEntity(authoring.enemyPrefab, TransformUsageFlags.Dynamic),
                maxEnemies = authoring.maxEnemies,
                isSpawning = true
            });
        }
    }
}
