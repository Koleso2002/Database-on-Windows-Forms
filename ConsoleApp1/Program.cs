using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        private static string path = @"Data Source=KONSTANTIN\SQLEXPRESS;
                            Initial Catalog=Equipment;
                            Integrated Security=SSPI;";
        private static SqlConnection conn;

        static void Main(string[] args)
        {
            CreateDBAsync();
            CreateTable();
            FillTypeEquipment();

        }

        public static async Task CreateDBAsync()
        {
            using (conn = new SqlConnection(path))
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("CREATE DATABASE Equipment", conn);
                cmd.ExecuteNonQuery();
            }

        }

        public static void CreateTable()
        {
            using (SqlConnection conn = new SqlConnection(path))
            {
                conn.Open();
                SqlCommand cmdy = new SqlCommand("Use Equipment", conn);
                cmdy.ExecuteNonQuery();

                string command = @"Create table [TypeEquipment]
                                               ([Id]int not null identity(1,1) primary key,
                                               [Type] nvarchar(70));

                               CREATE TABLE [Equipment]
                               ([Id] int not null identity(1,1) primary key,
                               [Name] nvarchar(100),
                               [fk_TypeEquipment] int foreign key references TypeEquipment([Id]),
                               [SerialNumber] nvarchar(100) default '0000000000000',
                               [ProductionDate] date default Convert(date, getdate()),
                               [DateOfCommission] date default Convert(date, getdate()),
                               [PurchasePrice] money default 0,
                               [ResidualPrice] money default 0,
                               [PercentageOfWear] SMALLINT not null check(PercentageOfWear>0 AND PercentageOfWear<101),
                               [fk_Work_NotWork] nvarchar(12),
                               [RequiredRepairs] nvarchar(300),
                               [PreventiveMaintenance] date default Convert (date,'1900-01-01'),
                               [ExtraordinaryRepairs] date default Convert (date,'1900-01-01'));

                               Create table [PreventiveRepairs]
                               ([Id] int not null identity(1,1) primary key,
                                [fk_EquipmentId] int foreign key references Equipment([Id]),
                                [Data] date not null,
                                [Price] money not null);

                                Create table [ExtraordinaryRepairs]
                                ([Id] int not null identity(1,1) primary key,
                                 [fk_EquipmentId] int foreign key references Equipment([Id]),
                                 [Data] date not null,
                                 [Price] money not null);";

                string command1 = @"Create table [PreventiveRepairs]
                                    ([Id] int not null identity(1,1) primary key,
                                     [fk_EquipmentId] int foreign key references Equipment([Id]),
                                     [Data] date not null,
                                     [Price] money not null,
                                     [Operation] nvarchar(400) not null);

                                Create table [ExtraordinaryRepairs]
                                ([Id] int not null identity(1,1) primary key,
                                 [fk_EquipmentId] int foreign key references Equipment([Id]),
                                 [Data] date not null,
                                 [Price] money not null,
                                 [Operation] nvarchar(400) not null);";


                SqlCommand cmd1 = new SqlCommand(command1, conn);

                cmd1.ExecuteNonQuery();
                conn.Close();
            }

        }

        public static void FillTypeEquipment()
        {
            using (conn = new SqlConnection(path))
            {
                conn.Open();
                string command = @"insert into [TypeEquipment] values ('Обрабатывающий центр'),('Металлообрабатывающие станки'),
                                  ('Термопластавтоматы')";
                string command1 = @"insert into [TypeEquipment] values ('Прочее')";
                SqlCommand cmd = new SqlCommand(command1, conn);
                cmd.ExecuteNonQuery();

            }
        }

    }

}

