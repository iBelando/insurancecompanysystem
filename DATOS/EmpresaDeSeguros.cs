namespace DATOS
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class EmpresaDeSeguros : DbContext
    {
        private static EmpresaDeSeguros instancia;

        public static EmpresaDeSeguros obtener_instancia()
        {
            if (instancia == null)
                instancia = new EmpresaDeSeguros();
            return instancia;
        }
        // El contexto se ha configurado para usar una cadena de conexión 'EmpresaDeSeguros' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'DATOS.EmpresaDeSeguros' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'EmpresaDeSeguros'  en el archivo de configuración de la aplicación.
        public EmpresaDeSeguros()
            : base("name=EmpresaDeSeguros")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MODELO.Organizador>()
                .HasKey(_ => _.IdOrganizador)
                .HasMany(_ => _.Productores);

            modelBuilder.Entity<MODELO.Cobertura>()
                .HasKey(_ => _.IdCobertura);

            modelBuilder.Entity<MODELO.Cuota>()
                .HasKey(_ => _.IdCuota);

            modelBuilder.Entity<MODELO.Productor>()
                .HasKey(_ => _.IdProductor)
                .HasMany(_ => _.Polizas);

            modelBuilder.Entity<MODELO.Poliza>()
                .HasKey(_ => _.IdPoliza)
                .HasMany(_ => _.Cuotas);

            modelBuilder.Entity<MODELO.Vehiculo>()
                .HasKey(_ => _.IdVehiculo);

            modelBuilder.Entity<MODELO.Localidad>()
                .HasKey(_ => _.IdLocalidad)
                .HasMany(_ => _.Clientes);

            modelBuilder.Entity<MODELO.Cliente>()
                .HasKey(_ => _.IdCliente)
                .HasMany(_ => _.Polizas);

            modelBuilder.Entity<MODELO.Modelo>()
                .HasKey(_ => _.IdModelo);

            modelBuilder.Entity<MODELO.Version>()
                .HasKey(_ => _.IdVersion);

            modelBuilder.Entity<MODELO.Marca>()
                .HasKey(_ => _.IdMarca)
                .HasMany(_ => _.Modelos);

        }
        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<MODELO.Organizador> Organizadores { get; set; }
        public virtual DbSet<MODELO.Productor> Productores { get; set; }
        public virtual DbSet<MODELO.Poliza> Polizas { get; set; }
        public virtual DbSet<MODELO.Cuota> Cuotas { get; set; }
        public virtual DbSet<MODELO.Cobertura> Coberturas { get; set; }
        public virtual DbSet<MODELO.Vehiculo> Vehiculos { get; set; }
        public virtual DbSet<MODELO.Localidad> Localidades { get; set; }
        public virtual DbSet<MODELO.Cliente> Clientes { get; set; }
        public virtual DbSet<MODELO.Modelo> Modelos { get; set; }
        public virtual DbSet<MODELO.Version> Versiones { get; set; }
        public virtual DbSet<MODELO.Marca> Marcas { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}