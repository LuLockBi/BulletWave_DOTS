using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
public partial struct EnemyMovementSystem : ISystem
{
    [BurstCompile]
    public readonly void OnUpdate(ref SystemState state)
    {
        float3 playerPosition = float3.zero;

        float deltaTime = SystemAPI.Time.DeltaTime;

        foreach (var playerTransform in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<PlayerTag>())
        {
            playerPosition = playerTransform.ValueRO.Position;
        }

        foreach (var (transform, enemyStats, enemyMovement) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<EnemyStats>, RefRW<EnemyMovement>>().WithAll<EnemyTag>())
        {
            float3 direction = math.normalize(playerPosition - transform.ValueRO.Position);
            enemyMovement.ValueRW.moveDirection = direction;

            transform.ValueRW.Position += deltaTime * direction * enemyStats.ValueRO.moveSpeed;
        }
    }
}
