﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Karmen
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KarmenDbContext : DbContext
    {
        public KarmenDbContext()
            : base("name=KarmenDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Block> Block { get; set; }
        public virtual DbSet<Colour> Colour { get; set; }
        public virtual DbSet<Component> Component { get; set; }
        public virtual DbSet<Designe> Designe { get; set; }
        public virtual DbSet<Footbed> Footbed { get; set; }
        public virtual DbSet<Furniture> Furniture { get; set; }
        public virtual DbSet<KindOfBlock> KindOfBlock { get; set; }
        public virtual DbSet<KindOfSole> KindOfSole { get; set; }
        public virtual DbSet<Lining> Lining { get; set; }
        public virtual DbSet<MaterialOfSole> MaterialOfSole { get; set; }
        public virtual DbSet<Pad> Pad { get; set; }
        public virtual DbSet<Pattern> Pattern { get; set; }
        public virtual DbSet<PhotoOfSole> PhotoOfSole { get; set; }
        public virtual DbSet<ProducedShoe> ProducedShoe { get; set; }
        public virtual DbSet<ShoeModel> ShoeModel { get; set; }
        public virtual DbSet<Sole> Sole { get; set; }
        public virtual DbSet<TopMaterial> TopMaterial { get; set; }
    }
}