//using MagicTournament.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MagicTournament.Data.Map
//{
//    public class UserMap : IEntityTypeConfiguration<UserModel>
//    {
//        public void Configure(EntityTypeBuilder<UserModel> builder)
//        {
//            builder.HasKey(t => t.ID);
//            builder.Property(t => t.Login)
//                .HasMaxLength(15)
//                .IsRequired();
//            builder.Property(t => t.Senha)
//                .HasMaxLength(15)
//                .IsRequired();
//            builder.Property(t => t.Deck)
//                .HasMaxLength(500);

//            builder.ToTable("UserModel");
//        }
//    }
//}
