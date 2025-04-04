using Unity.Entities;
using Unity.Transforms;

public readonly partial struct BulletAspect : IAspect
{
    
    
    public readonly RefRW<LocalTransform> localTransform;


    public void Move(float deltaTime)
    {

    }
}
