namespace InEducation.Server
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class InEducationEntities : DbContext
    {
        public InEducationEntities()
            : base("name=InEducationEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<База_знаний> База_знаний { get; set; }
        public virtual DbSet<Журнал> Журнал { get; set; }
        public virtual DbSet<Задание> Задание { get; set; }
        public virtual DbSet<Оценка_ученика> Оценка_ученика { get; set; }
        public virtual DbSet<Пользователь> Пользователь { get; set; }
        public virtual DbSet<Предмет> Предмет { get; set; }
        public virtual DbSet<Роль> Роль { get; set; }
        public virtual DbSet<Чат> Чат { get; set; }
    }
}
