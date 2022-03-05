namespace TheDigitalToolbox.Models
{
    public interface ITheDigitalToolBoxDBUnitOfWork
    {
        public IRepository<Comment> Comments { get; }
        public IRepository<Embedded> Embeddeds { get; }
        public IRepository<Guide> Guides { get; }
        public IRepository<HelpfulLink> HelpfulLinks { get; }
        public IRepository<Macro> Macros { get; }
        public IRepository<Program> Programs { get; }
        public IRepository<User> Users { get; }

        public void Save();
        public void SaveAsync();
    }
}
