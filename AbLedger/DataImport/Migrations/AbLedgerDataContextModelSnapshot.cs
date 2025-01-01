﻿// <auto-generated />
using System;
using DataImport.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataImport.Migrations
{
    [DbContext(typeof(AbLedgerDataContext))]
    partial class AbLedgerDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AbLedger.Entities.Accounts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Account")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("AbLedger.Entities.AppErrors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ErrorDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ErrorMsg")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppErrors");
                });

            modelBuilder.Entity("AbLedger.Entities.Payees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("PayeeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Payees");
                });

            modelBuilder.Entity("AbLedger.Entities.Transactions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("BeginBalance")
                        .HasColumnType("TEXT");

                    b.Property<string>("CheckNum")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deposit")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("EndBalance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Memo")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<int>("PayeeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Payment")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("TransAmount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("TransDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("PayeeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("AbLedger.Entities.Transactions", b =>
                {
                    b.HasOne("AbLedger.Entities.Accounts", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AbLedger.Entities.Payees", "Payees")
                        .WithMany("Transactions")
                        .HasForeignKey("PayeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Payees");
                });

            modelBuilder.Entity("AbLedger.Entities.Accounts", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("AbLedger.Entities.Payees", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
