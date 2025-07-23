using System;
using HastaneOtomasyonu.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace HastaneOtomasyonu.Models
{
    public class ProjeContext: DbContext
    {
        public DbSet<Hastalar> Hastalar { get; set; }
        public DbSet<Doktorlar> Doktorlar { get; set; }
        public DbSet<Branslar> Branslar { get; set; }
        public DbSet<Randevular> Randevular { get; set; }
        public DbSet<RandevuLog> RandevuLog { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}