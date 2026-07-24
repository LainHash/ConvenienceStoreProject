using NanoidDotNet;

namespace ConvenienceStore.Domain.Abstraction
{
    public abstract class Entity
    {
        public int Id { get; private set; }
        public string PublicId { get; private set; } = Nanoid.Generate(size: 10);
    }
}
