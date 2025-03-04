using NUnit.Framework;
using Unity.Entities;

namespace Core.Testing
{
    public abstract partial class ECSTestsFixture
    {
        protected World World { get; private set; }
        protected EntityManager EntityManager { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            World = new World("Test World");
            EntityManager = World.EntityManager;
        }

        [TearDown]
        public virtual void TearDown()
        {
            World.Dispose();
        }

    }

}