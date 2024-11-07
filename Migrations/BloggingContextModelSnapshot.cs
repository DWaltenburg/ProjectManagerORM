﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFGetStarted.Migrations
{
    [DbContext(typeof(BloggingContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BlogId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentTaskTaskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.HasIndex("CurrentTaskTaskId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TeamWorker", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamId", "WorkerId");

                    b.ToTable("TeamWorkers");
                });

            modelBuilder.Entity("TeamWorker1", b =>
                {
                    b.Property<int>("TeamsTeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkersWorkerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamsTeamId", "WorkersWorkerId");

                    b.HasIndex("WorkersWorkerId");

                    b.ToTable("TeamWorker1");
                });

            modelBuilder.Entity("Todo", b =>
                {
                    b.Property<int>("TodoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TaskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TodoId");

                    b.HasIndex("TaskId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentTodoTodoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WorkerId");

                    b.HasIndex("CurrentTodoTodoId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Post", b =>
                {
                    b.HasOne("Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Team", b =>
                {
                    b.HasOne("Task", "CurrentTask")
                        .WithMany()
                        .HasForeignKey("CurrentTaskTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentTask");
                });

            modelBuilder.Entity("TeamWorker1", b =>
                {
                    b.HasOne("Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkersWorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Todo", b =>
                {
                    b.HasOne("Task", null)
                        .WithMany("Todos")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("Worker", b =>
                {
                    b.HasOne("Todo", "CurrentTodo")
                        .WithMany()
                        .HasForeignKey("CurrentTodoTodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentTodo");
                });

            modelBuilder.Entity("Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Task", b =>
                {
                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
