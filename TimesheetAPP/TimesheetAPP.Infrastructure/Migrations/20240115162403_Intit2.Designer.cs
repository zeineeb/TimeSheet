﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimesheetAPP.Infrastructure.Data;

#nullable disable

namespace TimesheetAPP.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240115162403_Intit2")]
    partial class Intit2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TimesheetAPP.Core.Entities.Consomation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NbHeure")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Consomations");
                });

            modelBuilder.Entity("TimesheetAPP.Core.Entities.Intervenant", b =>
                {
                    b.Property<int>("IntervenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IntervenantId"));

                    b.Property<bool>("ClientExistance")
                        .HasColumnType("bit");

                    b.Property<int>("ConsomationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDeNaissnace")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IntervenantId");

                    b.HasIndex("ConsomationId");

                    b.ToTable("Intervenants");
                });

            modelBuilder.Entity("TimesheetAPP.Core.Entities.Projet", b =>
                {
                    b.Property<int>("ProjetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjetId"));

                    b.Property<string>("DescriptionProjet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomProjet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SolutionId")
                        .HasColumnType("int");

                    b.HasKey("ProjetId");

                    b.HasIndex("SolutionId");

                    b.ToTable("Projets");
                });

            modelBuilder.Entity("TimesheetAPP.Core.Entities.Projet_Intervenant", b =>
                {
                    b.Property<int>("ProjetId")
                        .HasColumnType("int");

                    b.Property<int>("IntervenantId")
                        .HasColumnType("int");

                    b.Property<int>("Projet_IntervenantId")
                        .HasColumnType("int");

                    b.HasKey("ProjetId", "IntervenantId", "Projet_IntervenantId");

                    b.HasIndex("IntervenantId");

                    b.ToTable("Projet_Intervenants");
                });

            modelBuilder.Entity("TimesheetAPP.Core.Entities.Solution", b =>
                {
                    b.Property<int>("SolutionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SolutionId"));

                    b.Property<string>("NomSolution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SolutionId");

                    b.ToTable("Solutions");
                });

            modelBuilder.Entity("TimesheetAPP.Core.Entities.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<int>("ConsomationId")
                        .HasColumnType("int");

                    b.Property<string>("DecriptionTicket")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomTicket")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int?>("ProjetId")
                        .HasColumnType("int");

                    b.Property<int>("Severity")
                        .HasColumnType("int");

                    b.Property<int>("SolutionId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("ConsomationId");

                    b.HasIndex("ProjetId");

                    b.HasIndex("SolutionId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TimesheetAPP.Core.Entities.Intervenant", b =>
                {
                    b.HasOne("TimesheetAPP.Core.Entities.Consomation", "Consomation")
                        .WithMany("Intervenants")
                        .HasForeignKey("ConsomationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consomation");
                });

            modelBuilder.Entity("TimesheetAPP.Core.Entities.Projet", b =>
                {
                    b.HasOne("TimesheetAPP.Core.Entities.Solution", "Solution")
                        .WithMany("Projets")
                        .HasForeignKey("SolutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("TimesheetAPP.Core.Entities.Projet_Intervenant", b =>
                {
                    b.HasOne("TimesheetAPP.Core.Entities.Intervenant", "Intervenant")
                        .WithMany("Projet_Intervenants")
                        .HasForeignKey("IntervenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimesheetAPP.Core.Entities.Projet", "Projet")
                        .WithMany("Projet_Intervenants")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Intervenant");

                    b.Navigation("Projet");
                });

            modelBuilder.Entity("TimesheetAPP.Core.Entities.Ticket", b =>
                {
                    b.HasOne("TimesheetAPP.Core.Entities.Consomation", "Consomation")
                        .WithMany("Tickets")
                        .HasForeignKey("ConsomationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimesheetAPP.Core.Entities.Projet", null)
                        .WithMany("Tickets")
                        .HasForeignKey("ProjetId");

                    b.HasOne("TimesheetAPP.Core.Entities.Solution", "Solution")
                        .WithMany("Tickets")
                        .HasForeignKey("SolutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consomation");

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("TimesheetAPP.Core.Entities.Consomation", b =>
                {
                    b.Navigation("Intervenants");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TimesheetAPP.Core.Entities.Intervenant", b =>
                {
                    b.Navigation("Projet_Intervenants");
                });

            modelBuilder.Entity("TimesheetAPP.Core.Entities.Projet", b =>
                {
                    b.Navigation("Projet_Intervenants");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TimesheetAPP.Core.Entities.Solution", b =>
                {
                    b.Navigation("Projets");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
