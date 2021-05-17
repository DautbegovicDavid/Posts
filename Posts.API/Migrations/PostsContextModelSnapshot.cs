﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Posts.API.Database;

namespace Posts.API.Migrations
{
    [DbContext(typeof(PostsContext))]
    partial class PostsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Posts.API.Models.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("body")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("slug")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("PostID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Posts.API.Models.PostTag", b =>
                {
                    b.Property<int>("PostID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagID")
                        .HasColumnType("INTEGER");

                    b.HasKey("PostID", "TagID");

                    b.HasIndex("TagID");

                    b.ToTable("PostsTags");
                });

            modelBuilder.Entity("Posts.API.Models.Tag", b =>
                {
                    b.Property<int>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.HasKey("TagID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Posts.API.Models.PostTag", b =>
                {
                    b.HasOne("Posts.API.Models.Post", "Post")
                        .WithMany("tagList")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Posts.API.Models.Tag", "Tag")
                        .WithMany("postList")
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Posts.API.Models.Post", b =>
                {
                    b.Navigation("tagList");
                });

            modelBuilder.Entity("Posts.API.Models.Tag", b =>
                {
                    b.Navigation("postList");
                });
#pragma warning restore 612, 618
        }
    }
}
