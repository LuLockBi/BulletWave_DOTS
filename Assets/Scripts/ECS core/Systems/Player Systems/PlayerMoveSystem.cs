using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct PlayerMovementSystem : ISystem
{
    public readonly void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        foreach (var (playerInput, playerTransform, playerStats) in SystemAPI.Query<RefRO<PlayerMovementInput>,RefRW <LocalTransform>, RefRO<PlayerStats>>())
        {
            playerTransform.ValueRW.Position += deltaTime * playerStats.ValueRO.speed * new float3(playerInput.ValueRO.move.x , playerInput.ValueRO.move.y, 0f);
        }
    }
}
