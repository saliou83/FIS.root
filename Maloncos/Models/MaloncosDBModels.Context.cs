﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Maloncos.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MaloncosDBEntities : DbContext
    {
        public MaloncosDBEntities()
            : base("name=MaloncosDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Commands> Commands { get; set; }
        public virtual DbSet<Compte> Compte { get; set; }
        public virtual DbSet<Couleur> Couleur { get; set; }
        public virtual DbSet<Ligne_Command> Ligne_Command { get; set; }
        public virtual DbSet<Produits> Produits { get; set; }
        public virtual DbSet<Soins> Soins { get; set; }
        public virtual DbSet<Vetements> Vetements { get; set; }
    }
}
