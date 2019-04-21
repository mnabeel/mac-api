using Microsoft.EntityFrameworkCore;
using MacApi.Models;

namespace MacApi.Data {
    public class MemberContext: DbContext {
        public MemberContext(DbContextOptions<MemberContext> options)
            : base(options) {

            }
        public DbSet<Member> Member { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
            modelBuilder.Entity<Member>().HasData(
                new Member {
                    Id = 1,
                    Name = "MemberName1"
                },
                new Member {
                    Id = 2,
                    Name = "MemberName2"
                },
                new Member {
                    Id = 3,
                    Name = "MemberName3"
                }
            );
        }
    }
}