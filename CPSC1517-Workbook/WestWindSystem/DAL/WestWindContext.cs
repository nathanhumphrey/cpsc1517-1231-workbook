using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WestWindSystem.Entities;

namespace WestWindSystem.DAL;

public partial class WestWindContext : DbContext
{
    // Not necessary for the Blazor server application, but useful 
    //   for quick testing the context (e.g. in a console application)

    /// <summary>
    /// Default constructor.
    /// </summary>
    //public WestWindContext()
    //{
    //}

	/// <summary>
	/// Provides a constructor that can be used by ASP.NET Core applications to 
    /// inject options for the context (e.g. connection string). This is how a
    /// context configuration from AddDbContext is passed to the DbContext.
    /// 
    /// The constructor accpets the options and passes them to the base class'
    /// constructor.
	/// </summary>
	/// <param name="options"></param>
	public WestWindContext(DbContextOptions<WestWindContext> options)
        : base(options)
    {
    }

	// DbSet<T> represents the collection of entities of a given type in the
	// context (typically that have been queried from a database). They are 
	// created from a DbContext
	// https://learn.microsoft.com/en-us/dotnet/api/system.data.entity.dbset?view=entity-framework-6.2.0

	public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<BuildVersion> BuildVersions { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<ExtendedOrderDetail> ExtendedOrderDetails { get; set; }

    public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

    public virtual DbSet<ManifestItem> ManifestItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderSubtotal> OrderSubtotals { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Territory> Territories { get; set; }

    // The following is unnecessary for configuration in the Blazor server
    //   application. Uncomment if you'd like to test in a Console app.

    /// <summary>
    /// This overridden method will aways be called a when a new context object
    /// is created. The default from the scaffolding process will be used to pass
    /// the required connection string to the context so a connection can be
    /// established. If the connection string is passed into the  constructor,
    /// this method does not need to be overidden in this way.
    /// </summary>
    /// <param name="optionsBuilder"></param>
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //   => optionsBuilder.UseSqlServer("Server=.;Database=WestWind;TrustServerCertificate=True;Trusted_Connection=true;MultipleActiveResultSets=true");

    /// <summary>
    /// This overidden method is used to further configure the model for the context.
    /// This method is typically only called once, when the context is first created.
    /// </summary>
    /// <param name="modelBuilder">The builder that defines the model for the context being created</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.Address1)
                .HasMaxLength(60)
                .HasColumnName("Address");
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
        });

        modelBuilder.Entity<BuildVersion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BuildVer__3214EC0720BD5B2B");

            entity.ToTable("BuildVersion");

            entity.Property(e => e.ReleaseDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.CategoryName, "CategoryName");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.PictureMimeType).HasMaxLength(40);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => e.CompanyName, "CompanyName");

            entity.HasIndex(e => e.AddressId, "UX_Customers_AddressID").IsUnique();

            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactEmail).HasMaxLength(50);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.Phone).HasMaxLength(24);

            entity.HasOne(d => d.Address).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customers_Addresses");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.LastName, "LastName");

            entity.HasIndex(e => e.AddressId, "UX_Employees_AddressID").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Active).HasDefaultValueSql("((1))");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Extension).HasMaxLength(4);
            entity.Property(e => e.FirstName).HasMaxLength(10);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.HomePhone).HasMaxLength(24);
            entity.Property(e => e.JobTitle).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.LeaveReason).HasMaxLength(80);
            entity.Property(e => e.Notes).HasColumnType("ntext");
            entity.Property(e => e.OfficePhone).HasMaxLength(24);
            entity.Property(e => e.PhotoMimeType).HasMaxLength(40);
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");
            entity.Property(e => e.TerminationDate).HasColumnType("datetime");
            entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

            entity.HasOne(d => d.Address).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Addresses");

            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("FK_Employees_Employees");

            entity.HasMany(d => d.Territories).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeTerritory",
                    r => r.HasOne<Territory>().WithMany()
                        .HasForeignKey("TerritoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeTerritories_Territories"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeTerritories_Employees"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "TerritoryId").IsClustered(false);
                        j.ToTable("EmployeeTerritories");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("EmployeeID");
                        j.IndexerProperty<string>("TerritoryId")
                            .HasMaxLength(20)
                            .HasColumnName("TerritoryID");
                    });
        });

        modelBuilder.Entity<ExtendedOrderDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ExtendedOrderDetails");

            entity.Property(e => e.ExtendedPrice).HasColumnType("money");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("InvoiceItems");

            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.ExtendedPrice).HasColumnType("money");
            entity.Property(e => e.Freight).HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.SalesRep).HasMaxLength(31);
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<ManifestItem>(entity =>
        {
            entity.HasKey(e => e.ManifestItemId).HasName("PK__Manifest__9000192C1C0F2E74");

            entity.Property(e => e.ManifestItemId).HasColumnName("ManifestItemID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ShipmentId).HasColumnName("ShipmentID");

            entity.HasOne(d => d.Product).WithMany(p => p.ManifestItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ManifestItems_ToProducts");

            entity.HasOne(d => d.Shipment).WithMany(p => p.ManifestItems)
                .HasForeignKey(d => d.ShipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ManifestItems_ToShipments");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "CustomerID");

            entity.HasIndex(e => e.CustomerId, "CustomersOrders");

            entity.HasIndex(e => e.SalesRepId, "EmployeeID");

            entity.HasIndex(e => e.SalesRepId, "EmployeesOrders");

            entity.HasIndex(e => e.OrderDate, "OrderDate");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Comments).HasMaxLength(250);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Freight)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentDueDate).HasColumnType("datetime");
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.SalesRepId).HasColumnName("SalesRepID");
            entity.Property(e => e.ShipAddressId).HasColumnName("ShipAddressID");
            entity.Property(e => e.ShipName).HasMaxLength(40);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.SalesRep).WithMany(p => p.Orders)
                .HasForeignKey(d => d.SalesRepId)
                .HasConstraintName("FK_Orders_Employees");

            entity.HasOne(d => d.ShipAddress).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipAddressId)
                .HasConstraintName("FK_Orders_Addresses");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "OrderID");

            entity.HasIndex(e => e.OrderId, "OrdersOrder_Details");

            entity.HasIndex(e => e.ProductId, "ProductID");

            entity.HasIndex(e => e.ProductId, "ProductsOrder_Details");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");
            entity.Property(e => e.UnitPrice).HasColumnType("money");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Products");
        });

        modelBuilder.Entity<OrderSubtotal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OrderSubtotals");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Subtotal).HasColumnType("money");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK_PAY_PayID");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("smallmoney");
            entity.Property(e => e.ClearedDate).HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_ToTable");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PAY_PTYP_PayTypeID");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasKey(e => e.PaymentTypeId).HasName("PK_PTYP_PayTypeID");

            entity.Property(e => e.PaymentTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PaymentTypeID");
            entity.Property(e => e.PaymentTypeDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "CategoriesProducts");

            entity.HasIndex(e => e.CategoryId, "CategoryID");

            entity.HasIndex(e => e.ProductName, "ProductName");

            entity.HasIndex(e => e.SupplierId, "SupplierID");

            entity.HasIndex(e => e.SupplierId, "SuppliersProducts");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice).HasColumnType("money");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Suppliers");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId)
                .HasName("PK_Region")
                .IsClustered(false);

            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.RegionDescription)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.ShipmentId).HasName("PK__Shipment__5CAD378D6F045399");

            entity.Property(e => e.ShipmentId).HasColumnName("ShipmentID");
            entity.Property(e => e.FreightCharge).HasColumnType("money");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.TrackingCode)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.HasOne(d => d.Order).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipments_ToOrders");

            entity.HasOne(d => d.ShipViaNavigation).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.ShipVia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipments_ToTShippers");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Phone).HasMaxLength(24);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasIndex(e => e.CompanyName, "CompanyName");

            entity.HasIndex(e => e.AddressId, "UX_Suppliers_AddressID").IsUnique();

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.Phone).HasMaxLength(24);

            entity.HasOne(d => d.Address).WithOne(p => p.Supplier)
                .HasForeignKey<Supplier>(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Suppliers_Addresses");
        });

        modelBuilder.Entity<Territory>(entity =>
        {
            entity.HasKey(e => e.TerritoryId).IsClustered(false);

            entity.Property(e => e.TerritoryId)
                .HasMaxLength(20)
                .HasColumnName("TerritoryID");
            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.TerritoryDescription)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.Region).WithMany(p => p.Territories)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Territories_Region");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    /// <summary>
    /// This method can be used to define any custom model updating that is required,
    /// but not implemented by the dbcontext-scaffold command (so, any additional work
    /// that would be overridden by the command should it be run again in the future).
    /// </summary>
    /// <param name="modelBuilder"></param>
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
