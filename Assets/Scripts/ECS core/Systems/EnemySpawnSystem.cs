using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateInGroup(typeof(SimulationSystemGroup))]
public partial struct EnemySpawnSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<EnemySpawner>();
    }
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        float currentTime = (float)SystemAPI.Time.ElapsedTime;

        var ecbSingleton = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
        var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);

        float3 playerPosition = float3.zero;

        foreach (var playerTransform in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<PlayerTag>())
        {
            playerPosition = playerTransform.ValueRO.Position;
        }

        foreach (var (spawner, spawnerEntity) in SystemAPI.Query<RefRW<EnemySpawner>>().WithEntityAccess())
        {
            if (currentTime >= spawner.ValueRO.nextSpawnTime)
            {
                int currentEnemyCount = state.EntityManager.CreateEntityQuery(typeof(EnemyTag)).CalculateEntityCount();
                if (currentEnemyCount < spawner.ValueRO.maxEnemies)
                {
                    float angle = UnityEngine.Random.Range(0f, math.PI * 2f);
                    float radius = 7f;


                    float3 offset = new float3(math.cos(angle), math.sin(angle), 0) * radius;

                    
                    float3 spawnPosition = playerPosition + offset;

                    var builder = new BasicEnemyBuilder()
                        .SetHealth(100f)
                        .SetSpeed(5f)
                        .SetPosition(spawnPosition);

                    builder.Build(ecb, spawner.ValueRO.enemyPrefab);

                    spawner.ValueRW.nextSpawnTime = currentTime + spawner.ValueRO.spawnRate;

                    UnityEngine.Debug.DrawLine(playerPosition, spawnPosition, UnityEngine.Color.red, 5f); // 
                }
            }

        }
    }
}
