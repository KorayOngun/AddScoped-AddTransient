namespace IoCTest.Controllers
{
    public interface IGuid
    {
        Guid Guid { get; }
    }
    public interface IScopedGuid : IGuid { }
    public interface ITransientGuid : IGuid { }

    public class Scope : IScopedGuid
    {
        public Scope()
        {
            Guid = Guid.NewGuid();

        }
        public Guid Guid { get; private set; }
    }
    public class Transient : ITransientGuid
    {
        public Transient()
        {
            Guid = Guid.NewGuid();

        }
        public Guid Guid { get; private set; }
    }
}
      