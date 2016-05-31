namespace PolyusGeo.bl_server_context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Infrastructure.UoW;
    using System.ComponentModel.Composition;


    [Export(typeof(IDbContext))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class bl_server_context : DbContext, IDbContext
    {
        public bl_server_context()
            : base("name=bl_server_context")
        {
        }

        public virtual DbSet<ASSAYS> ASSAYS { get; set; }
        public virtual DbSet<ASSAYS_DMP> ASSAYS_DMP { get; set; }
        public virtual DbSet<ASSAYS_OR> ASSAYS_OR { get; set; }
        public virtual DbSet<ASSAYS_STRG> ASSAYS_STRG { get; set; }
        public virtual DbSet<ASSAYS2> ASSAYS2 { get; set; }
        public virtual DbSet<ASSAYS2_CS> ASSAYS2_CS { get; set; }
        public virtual DbSet<BLOCK_ZAPASOV> BLOCK_ZAPASOV { get; set; }
        public virtual DbSet<COLLAR> COLLAR { get; set; }
        public virtual DbSet<COLLAR_DMP> COLLAR_DMP { get; set; }
        public virtual DbSet<COLLAR_OR> COLLAR_OR { get; set; }
        public virtual DbSet<COLLAR_STRG> COLLAR_STRG { get; set; }
        public virtual DbSet<COLLAR2> COLLAR2 { get; set; }
        public virtual DbSet<DOMEN> DOMEN { get; set; }
        public virtual DbSet<DRILLING_TYPE> DRILLING_TYPE { get; set; }
        public virtual DbSet<DUMP_BALANS> DUMP_BALANS { get; set; }
        public virtual DbSet<Flows> Flows { get; set; }
        public virtual IDbSet<GEOLOGIST> GEOLOGIST { get; set; }
        public virtual IDbSet<GORIZONT> GORIZONT { get; set; }
        public virtual DbSet<HOLE> HOLE { get; set; }
        public virtual DbSet<JOURNAL> JOURNAL { get; set; }
        public virtual DbSet<LITOLOGY> LITOLOGY { get; set; }
        public virtual DbSet<MOVER> MOVER { get; set; }
        public virtual DbSet<Q_Mes> Q_Mes { get; set; }
        public virtual DbSet<Q_pit> Q_pit { get; set; }
        public virtual DbSet<Q_sm> Q_sm { get; set; }
        public virtual DbSet<Q_YEAR> Q_YEAR { get; set; }
        public virtual DbSet<Q_zone> Q_zone { get; set; }
        public virtual DbSet<QBLOK> QBLOK { get; set; }
        public virtual DbSet<QCONTROL> QCONTROL { get; set; }
        public virtual IDbSet<RANG> RANG { get; set; }
        public virtual DbSet<REESTR_VEDOMOSTEI> REESTR_VEDOMOSTEI { get; set; }
        public virtual DbSet<REESTR_VEDOMOSTEI_STRG> REESTR_VEDOMOSTEI_STRG { get; set; }
        public virtual DbSet<RL_EXPLO> RL_EXPLO { get; set; }
        public virtual IDbSet<RL_EXPLO2> RL_EXPLO2 { get; set; }
        public virtual DbSet<RV_GEO> RV_GEO { get; set; }
        public virtual DbSet<RV_GEO_STRG> RV_GEO_STRG { get; set; }
        public virtual DbSet<RV_GRP> RV_GRP { get; set; }
        public virtual DbSet<RV_GRP_STRG> RV_GRP_STRG { get; set; }
        public virtual DbSet<RV_PAL_STRG> RV_PAL_STRG { get; set; }
        public virtual IDbSet<S_BLOK> S_BLOK { get; set; }
        public virtual DbSet<S_DAY> S_DAY { get; set; }
        public virtual DbSet<S_ORE_PIT> S_ORE_PIT { get; set; }
        public virtual DbSet<S_SALDO> S_SALDO { get; set; }
        public virtual DbSet<S_ZIF> S_ZIF { get; set; }
        public virtual DbSet<SECTOR> SECTOR { get; set; }
        public virtual DbSet<SFACE> SFACE { get; set; }
        public virtual DbSet<sprAreas> sprAreas { get; set; }
        public virtual DbSet<sprDirections> sprDirections { get; set; }
        public virtual DbSet<sprOreRepGroups> sprOreRepGroups { get; set; }
        public virtual DbSet<SURVEYS_DMP> SURVEYS_DMP { get; set; }
        public virtual DbSet<SURVEYS_OR> SURVEYS_OR { get; set; }
        public virtual DbSet<SURVEYS_STRG> SURVEYS_STRG { get; set; }
        public virtual DbSet<QFACE> QFACE { get; set; }
        public virtual DbSet<RV_PAL> RV_PAL { get; set; }
        public virtual DbSet<v_GetCombinedOreFlowPit> v_GetCombinedOreFlowPit { get; set; }
        public virtual DbSet<v_GetCombinedOreFlowPitSum> v_GetCombinedOreFlowPitSum { get; set; }
        public virtual DbSet<v_GetCombinedOreFlowStrg> v_GetCombinedOreFlowStrg { get; set; }
        public virtual DbSet<v_GetCombinedOreFlowStrgSum> v_GetCombinedOreFlowStrgSum { get; set; }
        public virtual DbSet<v_GetCombinedOreFlowSum> v_GetCombinedOreFlowSum { get; set; }
        public virtual DbSet<v_GetDataForImportBlankGeo> v_GetDataForImportBlankGeo { get; set; }
        public virtual DbSet<v_GetDataForImportBlankStrg> v_GetDataForImportBlankStrg { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ASSAYS>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<ASSAYS_DMP>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<ASSAYS_OR>()
                .Property(e => e.host)
                .IsFixedLength();

            modelBuilder.Entity<ASSAYS_OR>()
                .HasOptional(e => e.ASSAYS_OR1)
                .WithRequired(e => e.ASSAYS_OR2);

            modelBuilder.Entity<ASSAYS_STRG>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<ASSAYS2>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<ASSAYS2_CS>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<BLOCK_ZAPASOV>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<COLLAR>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<COLLAR>()
                .HasMany(e => e.ASSAYS)
                .WithRequired(e => e.COLLAR)
                .HasForeignKey(e => e.BHID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COLLAR_DMP>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<COLLAR_DMP>()
                .HasMany(e => e.ASSAYS_DMP)
                .WithRequired(e => e.COLLAR_DMP)
                .HasForeignKey(e => e.BHID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COLLAR_DMP>()
                .HasMany(e => e.SURVEYS_DMP)
                .WithRequired(e => e.COLLAR_DMP)
                .HasForeignKey(e => e.BHID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COLLAR_OR>()
                .Property(e => e.host)
                .IsFixedLength();

            modelBuilder.Entity<COLLAR_OR>()
                .HasMany(e => e.ASSAYS_OR)
                .WithRequired(e => e.COLLAR_OR)
                .HasForeignKey(e => e.BHID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COLLAR_OR>()
                .HasMany(e => e.SURVEYS_OR)
                .WithRequired(e => e.COLLAR_OR)
                .HasForeignKey(e => e.BHID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COLLAR_STRG>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<COLLAR_STRG>()
                .HasMany(e => e.ASSAYS_STRG)
                .WithRequired(e => e.COLLAR_STRG)
                .HasForeignKey(e => e.BHID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COLLAR_STRG>()
                .HasMany(e => e.SURVEYS_STRG)
                .WithRequired(e => e.COLLAR_STRG)
                .HasForeignKey(e => e.BHID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COLLAR2>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<COLLAR2>()
                .HasMany(e => e.ASSAYS2)
                .WithRequired(e => e.COLLAR2)
                .HasForeignKey(e => e.BHID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOMEN>()
                .Property(e => e.DOMEN1)
                .IsFixedLength();

            modelBuilder.Entity<DOMEN>()
                .HasMany(e => e.COLLAR_OR)
                .WithRequired(e => e.DOMEN1)
                .HasForeignKey(e => e.DOMEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOMEN>()
                .HasMany(e => e.COLLAR2)
                .WithRequired(e => e.DOMEN1)
                .HasForeignKey(e => e.DOMEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DRILLING_TYPE>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<DRILLING_TYPE>()
                .HasMany(e => e.COLLAR)
                .WithOptional(e => e.DRILLING_TYPE)
                .HasForeignKey(e => e.DRILL_TYPE);

            modelBuilder.Entity<DRILLING_TYPE>()
                .HasMany(e => e.COLLAR2)
                .WithRequired(e => e.DRILLING_TYPE)
                .HasForeignKey(e => e.DRILL_TYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DUMP_BALANS>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<GEOLOGIST>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<GEOLOGIST>()
                .HasMany(e => e.ASSAYS)
                .WithOptional(e => e.GEOLOGIST1)
                .HasForeignKey(e => e.GEOLOGIST);

            modelBuilder.Entity<GEOLOGIST>()
                .HasMany(e => e.ASSAYS_DMP)
                .WithOptional(e => e.GEOLOGIST1)
                .HasForeignKey(e => e.GEOLOGIST);

            modelBuilder.Entity<GEOLOGIST>()
                .HasMany(e => e.ASSAYS_OR)
                .WithRequired(e => e.GEOLOGIST1)
                .HasForeignKey(e => e.GEOLOGIST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GEOLOGIST>()
                .HasMany(e => e.ASSAYS2)
                .WithRequired(e => e.GEOLOGIST1)
                .HasForeignKey(e => e.GEOLOGIST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GEOLOGIST>()
                .HasMany(e => e.QFACE)
                .WithOptional(e => e.GEOLOGIST1)
                .HasForeignKey(e => e.GEOLOGIST);

            modelBuilder.Entity<GEOLOGIST>()
                .HasMany(e => e.REESTR_VEDOMOSTEI_STRG)
                .WithOptional(e => e.GEOLOGIST1)
                .HasForeignKey(e => e.GEOLOGIST);

            modelBuilder.Entity<GEOLOGIST>()
                .HasMany(e => e.SFACE)
                .WithOptional(e => e.GEOLOGIST1)
                .HasForeignKey(e => e.GEOLOGIST);

            modelBuilder.Entity<GORIZONT>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<GORIZONT>()
                .HasMany(e => e.COLLAR)
                .WithRequired(e => e.GORIZONT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GORIZONT>()
                .HasMany(e => e.COLLAR2)
                .WithRequired(e => e.GORIZONT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GORIZONT>()
                .HasMany(e => e.S_BLOK)
                .WithRequired(e => e.GORIZONT)
                .HasForeignKey(e => e.Bench)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GORIZONT>()
                .HasMany(e => e.QBLOK)
                .WithOptional(e => e.GORIZONT)
                .HasForeignKey(e => e.BENCH);

            modelBuilder.Entity<GORIZONT>()
                .HasMany(e => e.QFACE)
                .WithRequired(e => e.GORIZONT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GORIZONT>()
                .HasMany(e => e.S_DAY)
                .WithRequired(e => e.GORIZONT)
                .HasForeignKey(e => e.Bench)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOLE>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<HOLE>()
                .HasMany(e => e.COLLAR)
                .WithRequired(e => e.HOLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JOURNAL>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<JOURNAL>()
                .HasMany(e => e.ASSAYS)
                .WithRequired(e => e.JOURNAL1)
                .HasForeignKey(e => e.JOURNAL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JOURNAL>()
                .HasMany(e => e.ASSAYS2)
                .WithRequired(e => e.JOURNAL1)
                .HasForeignKey(e => e.JOURNAL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LITOLOGY>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<LITOLOGY>()
                .HasMany(e => e.ASSAYS)
                .WithRequired(e => e.LITOLOGY)
                .HasForeignKey(e => e.ROCK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LITOLOGY>()
                .HasMany(e => e.ASSAYS_OR)
                .WithRequired(e => e.LITOLOGY)
                .HasForeignKey(e => e.ROCK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LITOLOGY>()
                .HasMany(e => e.ASSAYS2)
                .WithRequired(e => e.LITOLOGY)
                .HasForeignKey(e => e.ROCK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MOVER>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<MOVER>()
                .HasMany(e => e.QFACE)
                .WithRequired(e => e.MOVER1)
                .HasForeignKey(e => e.MOVER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MOVER>()
                .HasMany(e => e.REESTR_VEDOMOSTEI_STRG)
                .WithOptional(e => e.MOVER1)
                .HasForeignKey(e => e.MOVER);

            modelBuilder.Entity<MOVER>()
                .HasMany(e => e.S_DAY)
                .WithRequired(e => e.MOVER1)
                .HasForeignKey(e => e.Mover)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Q_Mes>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<Q_Mes>()
                .HasMany(e => e.DUMP_BALANS)
                .WithOptional(e => e.Q_Mes)
                .HasForeignKey(e => e.Dat);

            modelBuilder.Entity<Q_pit>()
                .Property(e => e.Abbr)
                .IsFixedLength();

            modelBuilder.Entity<Q_pit>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<Q_pit>()
                .HasMany(e => e.S_DAY)
                .WithRequired(e => e.Q_pit)
                .HasForeignKey(e => e.Pit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Q_sm>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<Q_sm>()
                .HasMany(e => e.Flows)
                .WithRequired(e => e.Q_sm)
                .HasForeignKey(e => e.SmenaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Q_sm>()
                .HasMany(e => e.S_DAY)
                .WithRequired(e => e.Q_sm)
                .HasForeignKey(e => e.Smena)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Q_sm>()
                .HasMany(e => e.S_ORE_PIT)
                .WithOptional(e => e.Q_sm)
                .HasForeignKey(e => e.SMENA);

            modelBuilder.Entity<Q_sm>()
                .HasMany(e => e.S_ZIF)
                .WithOptional(e => e.Q_sm)
                .HasForeignKey(e => e.Smena);

            modelBuilder.Entity<Q_YEAR>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<Q_YEAR>()
                .HasMany(e => e.DUMP_BALANS)
                .WithOptional(e => e.Q_YEAR)
                .HasForeignKey(e => e.Year);

            modelBuilder.Entity<Q_zone>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<Q_zone>()
                .HasMany(e => e.S_ORE_PIT)
                .WithOptional(e => e.Q_zone)
                .HasForeignKey(e => e.R_zone);

            modelBuilder.Entity<QBLOK>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<QCONTROL>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<RANG>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<RANG>()
                .HasMany(e => e.ASSAYS)
                .WithOptional(e => e.RANG1)
                .HasForeignKey(e => e.RANG);

            modelBuilder.Entity<RANG>()
                .HasMany(e => e.ASSAYS2)
                .WithOptional(e => e.RANG1)
                .HasForeignKey(e => e.RANG);

            modelBuilder.Entity<REESTR_VEDOMOSTEI>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<REESTR_VEDOMOSTEI>()
                .HasMany(e => e.ASSAYS)
                .WithRequired(e => e.REESTR_VEDOMOSTEI)
                .HasForeignKey(e => e.BLANK_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REESTR_VEDOMOSTEI>()
                .HasMany(e => e.ASSAYS_DMP)
                .WithRequired(e => e.REESTR_VEDOMOSTEI)
                .HasForeignKey(e => e.BLANK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REESTR_VEDOMOSTEI>()
                .HasMany(e => e.ASSAYS_OR)
                .WithRequired(e => e.REESTR_VEDOMOSTEI)
                .HasForeignKey(e => e.BLANK_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REESTR_VEDOMOSTEI>()
                .HasMany(e => e.ASSAYS2)
                .WithRequired(e => e.REESTR_VEDOMOSTEI)
                .HasForeignKey(e => e.BLANK_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REESTR_VEDOMOSTEI>()
                .HasMany(e => e.ASSAYS2_CS)
                .WithRequired(e => e.REESTR_VEDOMOSTEI)
                .HasForeignKey(e => e.BLANK_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REESTR_VEDOMOSTEI>()
                .HasMany(e => e.QCONTROL)
                .WithRequired(e => e.REESTR_VEDOMOSTEI)
                .HasForeignKey(e => e.BLANK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REESTR_VEDOMOSTEI>()
                .HasMany(e => e.QFACE)
                .WithRequired(e => e.REESTR_VEDOMOSTEI)
                .HasForeignKey(e => e.BLANK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REESTR_VEDOMOSTEI>()
                .HasMany(e => e.RV_GEO)
                .WithRequired(e => e.REESTR_VEDOMOSTEI)
                .HasForeignKey(e => e.BLANK_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REESTR_VEDOMOSTEI_STRG>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<REESTR_VEDOMOSTEI_STRG>()
                .HasMany(e => e.ASSAYS_STRG)
                .WithRequired(e => e.REESTR_VEDOMOSTEI_STRG)
                .HasForeignKey(e => e.BLANK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REESTR_VEDOMOSTEI_STRG>()
                .HasMany(e => e.RV_GEO_STRG)
                .WithRequired(e => e.REESTR_VEDOMOSTEI_STRG)
                .HasForeignKey(e => e.BLANK_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REESTR_VEDOMOSTEI_STRG>()
                .HasMany(e => e.SFACE)
                .WithRequired(e => e.REESTR_VEDOMOSTEI_STRG)
                .HasForeignKey(e => e.BLANK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RL_EXPLO>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<RL_EXPLO>()
                .HasMany(e => e.COLLAR)
                .WithRequired(e => e.RL_EXPLO)
                .HasForeignKey(e => e.LINE_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RL_EXPLO2>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<RL_EXPLO2>()
                .HasMany(e => e.COLLAR2)
                .WithRequired(e => e.RL_EXPLO2)
                .HasForeignKey(e => e.LINE_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RL_EXPLO2>()
                .HasMany(e => e.S_BLOK)
                .WithRequired(e => e.RL_EXPLO2)
                .HasForeignKey(e => e.Blok)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RL_EXPLO2>()
                .HasMany(e => e.S_DAY)
                .WithRequired(e => e.RL_EXPLO2)
                .HasForeignKey(e => e.Blok)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RV_GEO>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<RV_GEO>()
                .HasMany(e => e.RV_GRP)
                .WithRequired(e => e.RV_GEO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RV_GEO>()
                .HasMany(e => e.RV_PAL)
                .WithRequired(e => e.RV_GEO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RV_GEO_STRG>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<RV_GEO_STRG>()
                .HasMany(e => e.RV_GRP_STRG)
                .WithRequired(e => e.RV_GEO_STRG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RV_GEO_STRG>()
                .HasMany(e => e.RV_PAL_STRG)
                .WithRequired(e => e.RV_GEO_STRG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RV_GRP>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<RV_GRP_STRG>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<RV_PAL_STRG>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<S_BLOK>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<S_DAY>()
                .Property(e => e.Host)
                .IsFixedLength();

            modelBuilder.Entity<S_DAY>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<S_ORE_PIT>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<S_ZIF>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<SECTOR>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<SECTOR>()
                .HasMany(e => e.ASSAYS_DMP)
                .WithOptional(e => e.SECTOR1)
                .HasForeignKey(e => e.SECTOR);

            modelBuilder.Entity<SECTOR>()
                .HasMany(e => e.REESTR_VEDOMOSTEI_STRG)
                .WithOptional(e => e.SECTOR1)
                .HasForeignKey(e => e.SECTOR);

            modelBuilder.Entity<SECTOR>()
                .HasMany(e => e.S_ORE_PIT)
                .WithOptional(e => e.SECTOR)
                .HasForeignKey(e => e.Sektor);

            modelBuilder.Entity<SFACE>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<sprAreas>()
                .Property(e => e.Descr)
                .IsFixedLength();

            modelBuilder.Entity<sprAreas>()
                .HasMany(e => e.Flows)
                .WithRequired(e => e.sprAreas)
                .HasForeignKey(e => e.Deb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sprAreas>()
                .HasMany(e => e.Flows1)
                .WithRequired(e => e.sprAreas1)
                .HasForeignKey(e => e.Kre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sprAreas>()
                .HasMany(e => e.S_SALDO)
                .WithRequired(e => e.sprAreas)
                .HasForeignKey(e => e.AreaID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sprAreas>()
                .HasMany(e => e.sprDirections)
                .WithRequired(e => e.sprAreas)
                .HasForeignKey(e => e.AreaID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sprDirections>()
                .Property(e => e.Direction)
                .IsFixedLength();

            modelBuilder.Entity<sprOreRepGroups>()
                .HasMany(e => e.sprDirections)
                .WithOptional(e => e.sprOreRepGroups)
                .HasForeignKey(e => e.GroupID);

            modelBuilder.Entity<SURVEYS_DMP>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<SURVEYS_OR>()
                .Property(e => e.host)
                .IsFixedLength();

            modelBuilder.Entity<SURVEYS_STRG>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<QFACE>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<RV_PAL>()
                .Property(e => e.upsize_ts)
                .IsFixedLength();

            modelBuilder.Entity<v_GetCombinedOreFlowPit>()
                .Property(e => e.bind)
                .IsUnicode(false);

            modelBuilder.Entity<v_GetCombinedOreFlowPitSum>()
                .Property(e => e.bind)
                .IsUnicode(false);

            modelBuilder.Entity<v_GetCombinedOreFlowPitSum>()
                .Property(e => e.vol)
                .HasPrecision(38, 2);

            modelBuilder.Entity<v_GetCombinedOreFlowPitSum>()
                .Property(e => e.m)
                .HasPrecision(38, 2);

            modelBuilder.Entity<v_GetCombinedOreFlowStrg>()
                .Property(e => e.bind)
                .IsUnicode(false);

            modelBuilder.Entity<v_GetCombinedOreFlowStrgSum>()
                .Property(e => e.bind)
                .IsUnicode(false);

            modelBuilder.Entity<v_GetCombinedOreFlowStrgSum>()
                .Property(e => e.vol)
                .HasPrecision(38, 2);

            modelBuilder.Entity<v_GetCombinedOreFlowStrgSum>()
                .Property(e => e.m)
                .HasPrecision(38, 2);

            modelBuilder.Entity<v_GetCombinedOreFlowSum>()
                .Property(e => e.bind)
                .IsUnicode(false);

            modelBuilder.Entity<v_GetDataForImportBlankGeo>()
                .Property(e => e.wsname)
                .IsUnicode(false);

            modelBuilder.Entity<v_GetDataForImportBlankStrg>()
                .Property(e => e.wsname)
                .IsUnicode(false);
        }
    }
}
