using Unity.Entities;

[InternalBufferCapacity(0)]
public struct BulletTag : IComponentData { }


public struct BulletStats : IComponentData 
{
    public float bulletSpeed;
    public float bulletScale;
    public float lifeTime;
}

public struct BulletPrefab : IComponentData
{
    public Entity bulletPrefab;
}

public struct BulletMovement : IComponentData
{
    public Unity.Mathematics.float3 bulletDirection;
}