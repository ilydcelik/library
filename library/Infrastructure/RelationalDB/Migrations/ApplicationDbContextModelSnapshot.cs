﻿// <auto-generated />
using System;
using Infrastructure.RelationalDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace library.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"),
                            CreatedAt = new DateTime(2023, 10, 23, 2, 42, 50, 138, DateTimeKind.Local).AddTicks(6906),
                            IsDeleted = false,
                            Name = "Richard Bach"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"),
                            CreatedAt = new DateTime(2023, 10, 23, 2, 42, 50, 144, DateTimeKind.Local).AddTicks(4671),
                            IsDeleted = false,
                            IsUsed = false,
                            Name = "Marti"
                        });
                });

            modelBuilder.Entity("Domain.Entities.BookType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BookTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cb03753a-aabb-430d-8575-1cf524e2e2ea"),
                            CreatedAt = new DateTime(2023, 10, 23, 2, 42, 50, 144, DateTimeKind.Local).AddTicks(7898),
                            IsDeleted = false,
                            Name = "Kurgu"
                        });
                });

            modelBuilder.Entity("Domain.Entities.RelBookAuthor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("RelBookAuthors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8abac909-6cee-4799-b467-680a814604d3"),
                            AuthorId = new Guid("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"),
                            BookId = new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17")
                        });
                });

            modelBuilder.Entity("Domain.Entities.RelBookType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("TypeId");

                    b.ToTable("RelBookTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8abac909-6cee-4799-b467-680a814604d3"),
                            BookId = new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"),
                            TypeId = new Guid("cb03753a-aabb-430d-8575-1cf524e2e2ea")
                        });
                });

            modelBuilder.Entity("Domain.Entities.RelUserBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Userd")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("RelUserBook");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entities.RelBookAuthor", b =>
                {
                    b.HasOne("Domain.Entities.Author", "Author")
                        .WithMany("RelBookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Book", "Book")
                        .WithMany("RelBookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Domain.Entities.RelBookType", b =>
                {
                    b.HasOne("Domain.Entities.Book", "Book")
                        .WithMany("RelBookType")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.BookType", "Type")
                        .WithMany("RelBookType")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Domain.Entities.RelUserBook", b =>
                {
                    b.HasOne("Domain.Entities.Book", "Book")
                        .WithMany("RelUserBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("RelUserBooks")
                        .HasForeignKey("UserId");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Author", b =>
                {
                    b.Navigation("RelBookAuthors");
                });

            modelBuilder.Entity("Domain.Entities.Book", b =>
                {
                    b.Navigation("RelBookAuthors");

                    b.Navigation("RelBookType");

                    b.Navigation("RelUserBooks");
                });

            modelBuilder.Entity("Domain.Entities.BookType", b =>
                {
                    b.Navigation("RelBookType");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("RelUserBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
