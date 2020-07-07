namespace DATOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        DNI = c.Int(nullable: false),
                        CUIL = c.Int(nullable: false),
                        CUIT = c.Int(nullable: false),
                        Edad = c.Int(nullable: false),
                        Email = c.String(),
                        Celular = c.Int(nullable: false),
                        Direccion = c.String(),
                        IdLocalidad_IdLocalidad = c.Int(),
                    })
                .PrimaryKey(t => t.IdCliente)
                .ForeignKey("dbo.Localidad", t => t.IdLocalidad_IdLocalidad)
                .Index(t => t.IdLocalidad_IdLocalidad);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        IdLocalidad = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        CodPostal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdLocalidad);
            
            CreateTable(
                "dbo.Poliza",
                c => new
                    {
                        IdPoliza = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        VigenciaDesde = c.DateTime(nullable: false),
                        VigenciaHasta = c.DateTime(nullable: false),
                        Patente = c.String(),
                        IdCobertura_IdCobertura = c.Int(),
                        IdProductor_IdProductor = c.Int(),
                        IdVehiculo_IdVehiculo = c.Int(),
                        IdCliente_IdCliente = c.Int(),
                    })
                .PrimaryKey(t => t.IdPoliza)
                .ForeignKey("dbo.Cobertura", t => t.IdCobertura_IdCobertura)
                .ForeignKey("dbo.Productor", t => t.IdProductor_IdProductor)
                .ForeignKey("dbo.Vehiculo", t => t.IdVehiculo_IdVehiculo)
                .ForeignKey("dbo.Cliente", t => t.IdCliente_IdCliente)
                .Index(t => t.IdCobertura_IdCobertura)
                .Index(t => t.IdProductor_IdProductor)
                .Index(t => t.IdVehiculo_IdVehiculo)
                .Index(t => t.IdCliente_IdCliente);
            
            CreateTable(
                "dbo.Cuota",
                c => new
                    {
                        IdCuota = c.Int(nullable: false, identity: true),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NroCuota = c.Int(nullable: false),
                        Estado = c.String(),
                        Poliza_IdPoliza = c.Int(),
                    })
                .PrimaryKey(t => t.IdCuota)
                .ForeignKey("dbo.Poliza", t => t.Poliza_IdPoliza)
                .Index(t => t.Poliza_IdPoliza);
            
            CreateTable(
                "dbo.Cobertura",
                c => new
                    {
                        IdCobertura = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        NroCuotas = c.Int(nullable: false),
                        ImporteCuota = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdCobertura);
            
            CreateTable(
                "dbo.Productor",
                c => new
                    {
                        IdProductor = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Matricula = c.String(),
                        Organizador_IdOrganizador = c.Int(),
                    })
                .PrimaryKey(t => t.IdProductor)
                .ForeignKey("dbo.Organizador", t => t.Organizador_IdOrganizador)
                .Index(t => t.Organizador_IdOrganizador);
            
            CreateTable(
                "dbo.Organizador",
                c => new
                    {
                        IdOrganizador = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IdOrganizador);
            
            CreateTable(
                "dbo.Vehiculo",
                c => new
                    {
                        IdVehiculo = c.Int(nullable: false, identity: true),
                        Año = c.DateTime(nullable: false),
                        IdModelo_IdModelo = c.Int(),
                        IdVersion_IdVersion = c.Int(),
                        IdMarca_IdMarca = c.Int(),
                    })
                .PrimaryKey(t => t.IdVehiculo)
                .ForeignKey("dbo.Modelo", t => t.IdModelo_IdModelo)
                .ForeignKey("dbo.Version", t => t.IdVersion_IdVersion)
                .ForeignKey("dbo.Marca", t => t.IdMarca_IdMarca)
                .Index(t => t.IdModelo_IdModelo)
                .Index(t => t.IdVersion_IdVersion)
                .Index(t => t.IdMarca_IdMarca);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        IdMarca = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IdMarca);
            
            CreateTable(
                "dbo.Modelo",
                c => new
                    {
                        IdModelo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        IdMarca = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdModelo)
                .ForeignKey("dbo.Marca", t => t.IdMarca)
                .Index(t => t.IdMarca);
            
            CreateTable(
                "dbo.Version",
                c => new
                    {
                        IdVersion = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IdVersion);
            
            CreateTable(
                "dbo.VersionModelo",
                c => new
                    {
                        Version_IdVersion = c.Int(nullable: false),
                        Modelo_IdModelo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Version_IdVersion, t.Modelo_IdModelo })
                .ForeignKey("dbo.Version", t => t.Version_IdVersion, cascadeDelete: true)
                .ForeignKey("dbo.Modelo", t => t.Modelo_IdModelo, cascadeDelete: true)
                .Index(t => t.Version_IdVersion)
                .Index(t => t.Modelo_IdModelo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Poliza", "IdCliente_IdCliente", "dbo.Cliente");
            DropForeignKey("dbo.Poliza", "IdVehiculo_IdVehiculo", "dbo.Vehiculo");
            DropForeignKey("dbo.Vehiculo", "IdMarca_IdMarca", "dbo.Marca");
            DropForeignKey("dbo.Modelo", "IdMarca", "dbo.Marca");
            DropForeignKey("dbo.Vehiculo", "IdVersion_IdVersion", "dbo.Version");
            DropForeignKey("dbo.VersionModelo", "Modelo_IdModelo", "dbo.Modelo");
            DropForeignKey("dbo.VersionModelo", "Version_IdVersion", "dbo.Version");
            DropForeignKey("dbo.Vehiculo", "IdModelo_IdModelo", "dbo.Modelo");
            DropForeignKey("dbo.Poliza", "IdProductor_IdProductor", "dbo.Productor");
            DropForeignKey("dbo.Productor", "Organizador_IdOrganizador", "dbo.Organizador");
            DropForeignKey("dbo.Poliza", "IdCobertura_IdCobertura", "dbo.Cobertura");
            DropForeignKey("dbo.Cuota", "Poliza_IdPoliza", "dbo.Poliza");
            DropForeignKey("dbo.Cliente", "IdLocalidad_IdLocalidad", "dbo.Localidad");
            DropIndex("dbo.VersionModelo", new[] { "Modelo_IdModelo" });
            DropIndex("dbo.VersionModelo", new[] { "Version_IdVersion" });
            DropIndex("dbo.Modelo", new[] { "IdMarca" });
            DropIndex("dbo.Vehiculo", new[] { "IdMarca_IdMarca" });
            DropIndex("dbo.Vehiculo", new[] { "IdVersion_IdVersion" });
            DropIndex("dbo.Vehiculo", new[] { "IdModelo_IdModelo" });
            DropIndex("dbo.Productor", new[] { "Organizador_IdOrganizador" });
            DropIndex("dbo.Cuota", new[] { "Poliza_IdPoliza" });
            DropIndex("dbo.Poliza", new[] { "IdCliente_IdCliente" });
            DropIndex("dbo.Poliza", new[] { "IdVehiculo_IdVehiculo" });
            DropIndex("dbo.Poliza", new[] { "IdProductor_IdProductor" });
            DropIndex("dbo.Poliza", new[] { "IdCobertura_IdCobertura" });
            DropIndex("dbo.Cliente", new[] { "IdLocalidad_IdLocalidad" });
            DropTable("dbo.VersionModelo");
            DropTable("dbo.Version");
            DropTable("dbo.Modelo");
            DropTable("dbo.Marca");
            DropTable("dbo.Vehiculo");
            DropTable("dbo.Organizador");
            DropTable("dbo.Productor");
            DropTable("dbo.Cobertura");
            DropTable("dbo.Cuota");
            DropTable("dbo.Poliza");
            DropTable("dbo.Localidad");
            DropTable("dbo.Cliente");
        }
    }
}
