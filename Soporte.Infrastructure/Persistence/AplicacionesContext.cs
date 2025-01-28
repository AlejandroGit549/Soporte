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
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC072DB15E78");

            entity.ToTable("Cliente", "Soporte");

            entity.HasIndex(e => e.Email, "UQ__Cliente__A9D10534F0DF6EC1").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comentar__3214EC07CEA225A2");

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
            entity.HasKey(e => e.Id).HasName("PK__Estado__3214EC07F32E28E6");

            entity.ToTable("Estado", "Soporte");

            entity.HasIndex(e => e.Nombre, "UQ__Estado__75E3EFCF5BE1A4D5").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HistorialEstado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historia__3214EC0752FD5FF7");

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
            entity.HasKey(e => e.Id).HasName("PK__Priorida__3214EC07F85D3A41");

            entity.ToTable("Prioridad", "Soporte");

            entity.HasIndex(e => e.Nombre, "UQ__Priorida__75E3EFCFFC92378F").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proyecto__3214EC07378B96C1");

            entity.ToTable("Proyecto", "Soporte");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3214EC074D6B3230");

            entity.ToTable("Rol", "Soporte");

            entity.HasIndex(e => e.Nombre, "UQ__Rol__75E3EFCF051C5921").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SeguimientoTiempo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Seguimie__3214EC07F4F49324");

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
            entity.HasKey(e => e.Id).HasName("PK__Ticket__3214EC07569AC705");

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
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07BFE83EC3");

            entity.ToTable("Usuario", "Soporte");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534793C8622").IsUnique();

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
