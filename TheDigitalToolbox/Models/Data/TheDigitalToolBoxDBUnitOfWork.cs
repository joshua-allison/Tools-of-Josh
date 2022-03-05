namespace TheDigitalToolbox.Models
{
    public class TheDigitalToolBoxDBUnitOfWork : ITheDigitalToolBoxDBUnitOfWork
    {
        private ToolboxContext context { get; set; }
        public TheDigitalToolBoxDBUnitOfWork(ToolboxContext ctx) => context = ctx;

        private IRepository<Comment> CommentData;
        public IRepository<Comment> Comments
        {
            get
            {
                if (CommentData == null)
                    CommentData = new Repository<Comment>(context);
                return CommentData;
            }
        }

        private IRepository<Embedded> EmbeddedData;
        public IRepository<Embedded> Embeddeds
        {
            get
            {
                if (EmbeddedData == null)
                    EmbeddedData = new Repository<Embedded>(context);
                return EmbeddedData;
            }
        }

        private IRepository<Guide> GuideData;
        public IRepository<Guide> Guides
        {
            get
            {
                if (GuideData == null)
                    GuideData = new Repository<Guide>(context);
                return GuideData;
            }
        }

        private IRepository<HelpfulLink> HelpfulLinkData;
        public IRepository<HelpfulLink> HelpfulLinks
        {
            get
            {
                if (HelpfulLinkData == null)
                    HelpfulLinkData = new Repository<HelpfulLink>(context);
                return HelpfulLinkData;
            }
        }

        private IRepository<Macro> MacroData;
        public IRepository<Macro> Macros
        {
            get
            {
                if (MacroData == null)
                    MacroData = new Repository<Macro>(context);
                return MacroData;
            }
        }

        private IRepository<Program> ProgramData;
        public IRepository<Program> Programs
        {
            get
            {
                if (ProgramData == null)
                    ProgramData = new Repository<Program>(context);
                return ProgramData;
            }
        }

        private IRepository<User> UserData;
        public IRepository<User> Users
        {
            get
            {
                if (UserData == null)
                    UserData = new Repository<User>(context);
                return UserData;
            }
        }

        public void Save() => context.SaveChanges();
        public void SaveAsync() => context.SaveChangesAsync();
    }
}