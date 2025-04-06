using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class BasicEnemyBuilder : IEnemyBuilder
{
    private float health; //
    private float speed; //
    private float3 position;

    public Entity Build(EntityCommandBuffer ecb, Entity prefab)
    {
        Entity enemy = ecb.Instantiate(prefab);
        ecb.AddComponent<EnemyTag>(enemy); //?

        ecb.SetComponent(enemy, new LocalTransform{
            Position = position,
            Rotation = quaternion.identity,
            Scale = 1f
        });

        return enemy;
    }

    public IEnemyBuilder SetHealth(float health)
    {
        this.health = health;
        return this;
    }

    public IEnemyBuilder SetPosition(float3 position)
    {
        this.position = position;
        return this;
    }

    public IEnemyBuilder SetSpeed(float speed)
    {
        this.speed = speed;
        return this;
    }
}
