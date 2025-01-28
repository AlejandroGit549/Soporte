using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Soporte.Domain;

namespace Soporte.Infrastructure.Persistence;

public partial class AplicacionesContext : DbContext
{
    public AplicacionesContext()
    {
    }

    public AplicacionesContext(DbContextOptions<AplicacionesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<HistorialEstado> HistorialEstados { get; set; }

    public virtual DbSet<Prioridad> Prioridads { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<SeguimientoTiempo> SeguimientoTiempos { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC079F630137");

            entity.ToTable("Cliente", "Soporte");

            entity.HasIndex(e => e.Email, "UQ__Cliente__A9D105348A6F6358").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comentar__3214EC0751EA7B6D");

            entity.ToTable("Comentario", "Soporte");

            entity.Property(e => e.Comentario1).HasColumnName("Comentario");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Ticket");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Usuario");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estado__3214EC07360CA79F");

            entity.ToTable("Estado", "Soporte");

            entity.HasIndex(e => e.Nombre, "UQ__Estado__75E3EFCFC95BAE0D").IsUnique();

            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HistorialEstado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historia__3214EC0798165F97");

            entity.ToTable("HistorialEstados", "Soporte");

            entity.Property(e => e.FechaCambio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.EstadoAnterior).WithMany(p => p.HistorialEstadoEstadoAnteriors)
                .HasForeignKey(d => d.EstadoAnteriorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_EstadoAnterior");

            entity.HasOne(d => d.EstadoNuevo).WithMany(p => p.HistorialEstadoEstadoNuevos)
                .HasForeignKey(d => d.EstadoNuevoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_EstadoNuevo");

            entity.HasOne(d => d.Ticket).WithMany(p => p.HistorialEstados)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Ticket");

            entity.HasOne(d => d.Usuario).WithMany(p => p.HistorialEstados)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Usuario");
        });

        modelBuilder.Entity<Prioridad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Priorida__3214EC073748226E");

            entity.ToTable("Prioridad", "Soporte");

            entity.HasIndex(e => e.Nombre, "UQ__Priorida__75E3EFCFEFD0521F").IsUnique();

            entity.Property(e => e.Nombre)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proyecto__3214EC0747DD99E7");

            entity.ToTable("Proyecto", "Soporte");

            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3214EC07928E7435");

            entity.ToTable("Rol", "Soporte");

            entity.HasIndex(e => e.Nombre, "UQ__Rol__75E3EFCFF522EA52").IsUnique();

            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SeguimientoTiempo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Seguimie__3214EC07588282D4");

            entity.ToTable("SeguimientoTiempo", "Soporte");

            entity.HasOne(d => d.Estado).WithMany(p => p.SeguimientoTiempos)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguimiento_Estado");

            entity.HasOne(d => d.Ticket).WithMany(p => p.SeguimientoTiempos)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguimiento_Ticket");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ticket__3214EC07D42700A5");

            entity.ToTable("Ticket", "Soporte");

            entity.Property(e => e.FechaCierre).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Qaid).HasColumnName("QAId");
            entity.Property(e => e.Titulo).HasMaxLength(255);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Cliente");

            entity.HasOne(d => d.Desarrollador).WithMany(p => p.TicketDesarrolladors)
                .HasForeignKey(d => d.DesarrolladorId)
                .HasConstraintName("FK_Ticket_Desarrollador");

            entity.HasOne(d => d.Estado).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Estado");

            entity.HasOne(d => d.Prioridad).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PrioridadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Prioridad");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ProyectoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Proyecto");

            entity.HasOne(d => d.Qa).WithMany(p => p.TicketQas)
                .HasForeignKey(d => d.Qaid)
                .HasConstraintName("FK_Ticket_QA");

            entity.HasOne(d => d.TicketDerivadoDeNavigation).WithMany(p => p.InverseTicketDerivadoDeNavigation)
                .HasForeignKey(d => d.TicketDerivadoDe)
                .HasConstraintName("FK_Ticket_Derivado");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC0781A664B8");

            entity.ToTable("Usuario", "Soporte");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534E94F81AD").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
