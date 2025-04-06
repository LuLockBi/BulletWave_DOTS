using Unity.Entities;

[InternalBufferCapacity(0)]
public struct EnemyTag : IComponentData { }

public struct EnemyStats : IComponentData
{
    public float moveSpeed;
    public float health;
    public float damage;
}

public struct EnemyHealth : IComponentData
{
    public float maxHealth;
    public float currentHealth;
}

public struct EnemyMovement : IComponentData
{
    public Unity.Mathematics.float3 moveDirection;
}

public struct EnemySpawner : IComponentData
{
    public float spawnRate;         
    public float nextSpawnTime;     
    public Entity enemyPrefab;      
    public int maxEnemies;
    public bool isSpawning;
}

