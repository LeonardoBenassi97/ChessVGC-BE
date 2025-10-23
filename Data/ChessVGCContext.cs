using Microsoft.EntityFrameworkCore;
using ChessVGC.BE.Models;

namespace ChessVGC.BE.Data
{
    public class ChessVGCContext : DbContext
    {
        public ChessVGCContext(DbContextOptions<ChessVGCContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserStats> UserStats { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Piece> Pieces { get; set; }
        public DbSet<GameMove> GameMoves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User configurations
            modelBuilder.Entity<User>()
                .HasOne(u => u.Stats)
                .WithOne(s => s.User)
                .HasForeignKey<UserStats>(s => s.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Players)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            // Game configurations
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Players)
                .WithOne(p => p.Game)
                .HasForeignKey(p => p.GameId);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Pieces)
                .WithOne(p => p.Game)
                .HasForeignKey(p => p.GameId);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Moves)
                .WithOne(m => m.Game)
                .HasForeignKey(m => m.GameId);

            // Player configurations
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Moves)
                .WithOne(m => m.Player)
                .HasForeignKey(m => m.PlayerId);

            // GameMove configurations
            modelBuilder.Entity<GameMove>()
            .HasOne(m => m.MovedPiece)
            .WithMany()
            .HasForeignKey(m => m.MovedPieceId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GameMove>()
            .HasOne(m => m.CapturedPiece)
            .WithMany()
            .HasForeignKey(m => m.CapturedPieceId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
        }
    }
}