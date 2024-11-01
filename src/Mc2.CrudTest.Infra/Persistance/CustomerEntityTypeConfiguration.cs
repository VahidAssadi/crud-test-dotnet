using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infra.Persistance
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasKey(c => c.Id);

            entity.Property(fn => fn.FirstName).IsRequired().HasColumnName("FirstName");
            entity.Property(fn => fn.LastName).IsRequired().HasColumnName("LastName");

            entity.Property(bd => bd.BirthDate).HasColumnName("BirthDate");

            entity.OwnsOne(c => c.ContactNumber, birthDate =>
            {
                birthDate.Property(bd => bd.Number).IsRequired().HasColumnName("ContactNumber");
            });

            entity.OwnsOne(c => c.EmailAddress, birthDate =>
            {
                birthDate.Property(bd => bd.Address).IsRequired().HasColumnName("EmailAddress");
                birthDate.HasIndex(c => c.Address).IsUnique();
            });

            entity.OwnsOne(c => c.AccountNumber, accNumber =>
            {
                accNumber.Property(bd => bd.AccountNumber).IsRequired().HasColumnName("AccountNumber");
                accNumber.HasIndex(c => c.AccountNumber).IsUnique();

            });

            entity.HasIndex(c => new { c.FirstName, c.LastName, c.BirthDate }).IsUnique();

        }
    }
}
