using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notes.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    header = table.Column<string>(type: "text", nullable: false, comment: "Заголовок"),
                    сontent = table.Column<string>(type: "text", nullable: false, comment: "Текст")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.id);
                },
                comment: "Заметки");

            migrationBuilder.CreateTable(
                name: "reminders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    header = table.Column<string>(type: "text", nullable: false, comment: "Заголовок"),
                    сontent = table.Column<string>(type: "text", nullable: false, comment: "Текст"),
                    notify_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата и время напоминания")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reminders", x => x.id);
                },
                comment: "Напоминания");

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Идентификатор"),
                    header = table.Column<string>(type: "text", nullable: false, comment: "Наименование")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.id);
                },
                comment: "Тэги");

            migrationBuilder.CreateTable(
                name: "NoteTag",
                columns: table => new
                {
                    NotesId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteTag", x => new { x.NotesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_NoteTag_notes_NotesId",
                        column: x => x.NotesId,
                        principalTable: "notes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteTag_tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReminderTag",
                columns: table => new
                {
                    RemindersId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderTag", x => new { x.RemindersId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ReminderTag_reminders_RemindersId",
                        column: x => x.RemindersId,
                        principalTable: "reminders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReminderTag_tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteTag_TagsId",
                table: "NoteTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_ReminderTag_TagsId",
                table: "ReminderTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteTag");

            migrationBuilder.DropTable(
                name: "ReminderTag");

            migrationBuilder.DropTable(
                name: "notes");

            migrationBuilder.DropTable(
                name: "reminders");

            migrationBuilder.DropTable(
                name: "tags");
        }
    }
}
