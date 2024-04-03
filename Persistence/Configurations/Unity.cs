using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configurations
{
    public static class Unity
    {
        /// <summary>
        ///  Check that <paramref name="sourceDate"/> longer than or equal <paramref name="targetDate"/>
        /// </summary>

        /// <returns>Sql string query</returns>
        public static string CheckDate(string sourceDate,
            string targetDate = "GETDATE()") =>
            $"DATEPART(YEAR, {sourceDate}) >= DATEPART(YEAR, {targetDate}) and DATEPART(MONTH, {sourceDate}) >= DATEPART(MONTH, {targetDate}) and DATEPART(DAY, {sourceDate}) >= DATEPART(DAY, {targetDate})";


        /// <summary>
        /// Constraints on <see cref="Client"/> | <see cref="Employee"/> only 
        /// </summary>
        /// <typeparam name="TEntity"><see cref="Client"/> | <see cref="Employee"/></typeparam>
        /// <param name="builder">Entity</param>
        public static void ApplyEmailConstraint<TEntity>(EntityTypeBuilder<TEntity> builder)
            where TEntity : BaseEntity
        {
            builder.ToTable(b => b
                .HasCheckConstraint("EmailValidation",
                    "[Email] like '%[a-zA-Z0-9.]@gmail.com' and [Email] not like '%[-+/*]%'"));  
        }

    }
   
}
