using Unity.Entities;
using Unity.Mathematics;

public interface IEnemyBuilder 
{
    IEnemyBuilder SetHealth(float health);
    IEnemyBuilder SetSpeed(float speed);
    IEnemyBuilder SetPosition(float3 position);
    Entity Build(EntityCommandBuffer ecb, Entity prefab);
}
