// <auto-generated />
using System;
using GFT.InWallet.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GFT.InWallet.Infra.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220627145618_AlterItensAssetManager")]
    partial class AlterItensAssetManager
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GFT.InWallet.Domain.Entity.Asset", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("text");

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<DateTime>("Inclusion")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Symbol");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("GFT.InWallet.Domain.Entity.AssetMovement", b =>
                {
                    b.Property<double>("Fee")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("Inclusion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("OperationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<char>("OperationType")
                        .HasColumnType("character(1)");

                    b.Property<double>("PriceAsset")
                        .HasColumnType("double precision");

                    b.Property<string>("Symbol")
                        .HasColumnType("text");

                    b.Property<double>("Total")
                        .HasColumnType("double precision");

                    b.Property<double>("Volume")
                        .HasColumnType("double precision");

                    b.ToTable("AssetMovement");
                });
#pragma warning restore 612, 618
        }
    }
}
