using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class BulletAuthoring : MonoBehaviour
{
    public float speed = 10f;
    public float scale = 0.2f;
    public float bulletLifeTime = 3f;

    public class Baker : Baker<BulletAuthoring>
    {
        public override void Bake(BulletAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent<BulletTag>(entity);

            AddComponent(entity, new BulletStats
            {
                bulletScale = authoring.scale,
                bulletSpeed = authoring.speed,
                lifeTime = authoring.bulletLifeTime
            });
            AddComponent(entity, new LocalTransform
            {
                Scale = authoring.scale
            });
            AddComponent(entity, new BulletMovement());
        }
    }
}