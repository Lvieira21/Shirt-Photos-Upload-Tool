﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TShirt.Photos.App.Infra.Data.Context;

#nullable disable

namespace TShirt.Photos.App.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShirtColour", b =>
                {
                    b.Property<int>("ShirtId")
                        .HasColumnType("int");

                    b.Property<int>("ColourId")
                        .HasColumnType("int");

                    b.HasKey("ShirtId", "ColourId");

                    b.HasIndex("ColourId");

                    b.ToTable("ShirtColour");

                    b.HasData(
                        new
                        {
                            ShirtId = 1,
                            ColourId = 1
                        },
                        new
                        {
                            ShirtId = 1,
                            ColourId = 2
                        },
                        new
                        {
                            ShirtId = 1,
                            ColourId = 3
                        },
                        new
                        {
                            ShirtId = 2,
                            ColourId = 2
                        },
                        new
                        {
                            ShirtId = 2,
                            ColourId = 3
                        },
                        new
                        {
                            ShirtId = 3,
                            ColourId = 1
                        });
                });

            modelBuilder.Entity("ShirtFabric", b =>
                {
                    b.Property<int>("ShirtId")
                        .HasColumnType("int");

                    b.Property<int>("FabricId")
                        .HasColumnType("int");

                    b.HasKey("ShirtId", "FabricId");

                    b.HasIndex("FabricId");

                    b.ToTable("ShirtFabric");

                    b.HasData(
                        new
                        {
                            ShirtId = 1,
                            FabricId = 1
                        },
                        new
                        {
                            ShirtId = 1,
                            FabricId = 2
                        },
                        new
                        {
                            ShirtId = 1,
                            FabricId = 3
                        },
                        new
                        {
                            ShirtId = 2,
                            FabricId = 1
                        },
                        new
                        {
                            ShirtId = 2,
                            FabricId = 2
                        },
                        new
                        {
                            ShirtId = 3,
                            FabricId = 1
                        });
                });

            modelBuilder.Entity("TShirt.Photos.App.Models.Entities.Shirt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shirts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Abstract"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bubbles"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Plain"
                        });
                });

            modelBuilder.Entity("TShirt.Photos.App.Models.Entities.ShirtColour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colours");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "White"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Red"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Grey"
                        });
                });

            modelBuilder.Entity("TShirt.Photos.App.Models.Entities.ShirtFabric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fabrics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Cotton"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Linen"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Silk"
                        });
                });

            modelBuilder.Entity("TShirt.Photos.App.Models.Entities.ShirtImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ColourId")
                        .HasColumnType("int");

                    b.Property<int>("FabricId")
                        .HasColumnType("int");

                    b.Property<int>("ShirtId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ShirtId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ShirtColour", b =>
                {
                    b.HasOne("TShirt.Photos.App.Models.Entities.ShirtColour", null)
                        .WithMany()
                        .HasForeignKey("ColourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TShirt.Photos.App.Models.Entities.Shirt", null)
                        .WithMany()
                        .HasForeignKey("ShirtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShirtFabric", b =>
                {
                    b.HasOne("TShirt.Photos.App.Models.Entities.ShirtFabric", null)
                        .WithMany()
                        .HasForeignKey("FabricId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TShirt.Photos.App.Models.Entities.Shirt", null)
                        .WithMany()
                        .HasForeignKey("ShirtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TShirt.Photos.App.Models.Entities.ShirtImage", b =>
                {
                    b.HasOne("TShirt.Photos.App.Models.Entities.Shirt", null)
                        .WithMany("Images")
                        .HasForeignKey("ShirtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TShirt.Photos.App.Models.Entities.Shirt", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
