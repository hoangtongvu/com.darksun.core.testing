using Unity.Entities;

namespace Core.Testing
{
    public abstract partial class ECSTestsFixture
    {
        private const int DefaultEntityCount = 1000;


        protected SystemHandle CreateSystem<T>()
            where T : unmanaged, ISystem => this.World.CreateSystem<T>();

        protected T CreateManagedSystem<T>()
            where T : ComponentSystemBase, new() => this.World.CreateSystemManaged<T>();

        protected void UpdateSystem<T>()
            where T : unmanaged, ISystem =>
            this.World.GetExistingSystem<T>().Update(this.World.Unmanaged);

        protected void UpdateManagedSystem<T>()
            where T : ComponentSystemBase =>
            this.World.GetExistingSystemManaged<T>().Update();

        protected Entity CreateEntity(params ComponentType[] types) => this.EntityManager.CreateEntity(types);

        protected void CreateEntities(ComponentType[] types, int entityCount = DefaultEntityCount)
        {
            for (var i = 0; i < entityCount; i++)
            {
                this.EntityManager.CreateEntity(types);
            }
        }

        protected void CreateEntityCommandBufferSystem()
        {
            this.World.CreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

    }

}