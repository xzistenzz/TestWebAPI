using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebAPI.Domain.Models;

namespace TestWebAPI.Persistance.Configuration
{
    internal class FriendshipsConfiguration : IEntityTypeConfiguration<Friendships>
    {
        public void Configure(EntityTypeBuilder<Friendships> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.UserFrom)
                .WithMany(x => x.Friends)
                .HasForeignKey(x => x.UserFromId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
