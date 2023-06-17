namespace CV_Manager.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CV> CVs { get; set; }
    }
}
