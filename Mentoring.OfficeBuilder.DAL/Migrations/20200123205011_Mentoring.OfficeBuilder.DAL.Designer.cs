﻿// <auto-generated />
using System;
using Mentoring.OfficeBuilder.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mentoring.OfficeBuilder.DAL.Migrations
{
    [DbContext(typeof(OfficeDbContext))]
    [Migration("20200123205011_Mentoring.OfficeBuilder.DAL")]
    partial class MentoringOfficeBuilderDAL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mentoring.OfficeBuilder.DAL.DbModels.DbSvg", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Html");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DbAreas");
                });

            modelBuilder.Entity("Mentoring.OfficeBuilder.DAL.DbModels.DbTransition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ElementId");

                    b.Property<Guid?>("SvgId");

                    b.HasKey("Id");

                    b.HasIndex("SvgId");

                    b.ToTable("DbTransition");
                });

            modelBuilder.Entity("Mentoring.OfficeBuilder.DAL.DbModels.DbTransition", b =>
                {
                    b.HasOne("Mentoring.OfficeBuilder.DAL.DbModels.DbSvg", "Svg")
                        .WithMany("Transitions")
                        .HasForeignKey("SvgId");
                });
#pragma warning restore 612, 618
        }
    }
}
