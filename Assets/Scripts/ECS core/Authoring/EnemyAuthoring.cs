using Unity.Entities;

public class EnemyAuthoring : UnityEngine.MonoBehaviour
{
    public float moveSpeed = 2f;
    public float health = 2;
    public float damage = 2;

    public class Baker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new EnemyStats
            {
                moveSpeed = authoring.moveSpeed,
                health = authoring.health,
                damage = authoring.damage
            });
            AddComponent<EnemyMovement>(entity);
            AddComponent(entity, new EnemyHealth{
                currentHealth = authoring.health,
                maxHealth = authoring.health
            });
        }
    }
}
