﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notes.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Notes.Database.Migrations
{
    [DbContext(typeof(NotesContext))]
    partial class NotesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NoteTag", b =>
                {
                    b.Property<Guid>("NotesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("uuid");

                    b.HasKey("NotesId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("NoteTag");
                });

            modelBuilder.Entity("Notes.Models.Entities.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasComment("Идентификатор");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("сontent")
                        .HasComment("Текст");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("header")
                        .HasComment("Заголовок");

                    b.HasKey("Id");

                    b.ToTable("notes", null, t =>
                        {
                            t.HasComment("Заметки");
                        });
                });

            modelBuilder.Entity("Notes.Models.Entities.Reminder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasComment("Идентификатор");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("сontent")
                        .HasComment("Текст");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("header")
                        .HasComment("Заголовок");

                    b.Property<DateTime>("NotifyDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("notify_date")
                        .HasComment("Дата и время напоминания");

                    b.HasKey("Id");

                    b.ToTable("reminders", null, t =>
                        {
                            t.HasComment("Напоминания");
                        });
                });

            modelBuilder.Entity("Notes.Models.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasComment("Идентификатор");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("header")
                        .HasComment("Наименование");

                    b.HasKey("Id");

                    b.ToTable("tags", null, t =>
                        {
                            t.HasComment("Тэги");
                        });
                });

            modelBuilder.Entity("ReminderTag", b =>
                {
                    b.Property<Guid>("RemindersId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("uuid");

                    b.HasKey("RemindersId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("ReminderTag");
                });

            modelBuilder.Entity("NoteTag", b =>
                {
                    b.HasOne("Notes.Models.Entities.Note", null)
                        .WithMany()
                        .HasForeignKey("NotesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Notes.Models.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReminderTag", b =>
                {
                    b.HasOne("Notes.Models.Entities.Reminder", null)
                        .WithMany()
                        .HasForeignKey("RemindersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Notes.Models.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}