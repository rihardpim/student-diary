using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace StudentDiary.Data
{
    public class DatabaseCreation // datu bāzes savienojums un tabulu izveide
    {
        private const string ConnectionString =
                    "Data Source=studentdiary.db";


        public static SqliteConnection GetConnection()  // Atgriež atvērtu savienojumu ar datu bāzi
        {
            var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public static void Initialize()
        {
            CreateTables();
        }

        private static void CreateTables() // Izveido visas nepieciešamās tabulas datu bāzē
        {
            using var connection = GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Teachers (
                    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    FullName    TEXT NOT NULL,
                    Email       TEXT,
                    Phone       TEXT,
                    Classroom   TEXT
                );

                CREATE TABLE IF NOT EXISTS Subjects (
                    Id           INTEGER PRIMARY KEY AUTOINCREMENT,
                    Code         TEXT,
                    Name         TEXT NOT NULL,
                    Part         TEXT,
                    CreditPoints INT DEFAULT 0,
                    Ects         INT DEFAULT 0,
                    Semester     INT DEFAULT 1,
                    TeacherId    INT,
                    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
                        ON DELETE SET NULL
                );

                CREATE TABLE IF NOT EXISTS Grades (
                    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    Value       INT NOT NULL,
                    Type        INT NOT NULL,
                    Date        TEXT NOT NULL,
                    Comment     TEXT,
                    SubjectId   INT NOT NULL,
                    FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
                        ON DELETE CASCADE
                );

                -- IsCompleted:  0 - nav izpildīts, 1 = izpildīts
                -- Priority: 0 - Low, 1 - Medium, 2 - High
                CREATE TABLE IF NOT EXISTS Homeworks (
                    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title       TEXT NOT NULL,
                    Description TEXT,
                    DueDate     TEXT NOT NULL,
                    IsCompleted INT DEFAULT 0,
                    Priority    INT DEFAULT 1,
                    SubjectId   INT NOT NULL,
                    FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
                        ON DELETE CASCADE
                );

                -- Type — 0=Exam, 1=Coursework, 2=Lab, 3=Test, 4=Other
                CREATE TABLE IF NOT EXISTS Deadlines (
                    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title       TEXT NOT NULL,
                    Description TEXT,
                    Date        TEXT NOT NULL,
                    Type        INT NOT NULL,
                    SubjectId   INT,
                    FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
                        ON DELETE SET NULL
                );

                CREATE TABLE IF NOT EXISTS Notes (
                    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title       TEXT NOT NULL,
                    Content     TEXT,
                    CreatedAt   TEXT NOT NULL,
                    UpdatedAt   TEXT NOT NULL,
                    Tags        TEXT
                );

                CREATE TABLE IF NOT EXISTS Schedules (
                    Id           INTEGER PRIMARY KEY AUTOINCREMENT,
                    ScheduleType INT  NOT NULL DEFAULT 0,
                    DayWeek      INT,
                    WeekType     INT  DEFAULT 2,
                    SpecificDate DATE,
                    StartTime    TEXT NOT NULL,
                    EndTime      TEXT NOT NULL,
                    Room         TEXT,
                    Type         INT  NOT NULL DEFAULT 0,
                    Groups       TEXT DEFAULT 'Visām grupām',
                    SubjectId    INT  NOT NULL,
                    OriginalId   INT,
                    FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)
                        ON DELETE CASCADE
                );
            ";
            cmd.ExecuteNonQuery();
        }


    }
}