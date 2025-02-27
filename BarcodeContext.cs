using Microsoft.EntityFrameworkCore;

public class BarcodeContext : DbContext
{
    public DbSet<BarcodeData> Barcodes { get; set; }

    public BarcodeContext(DbContextOptions<BarcodeContext> options) : base(options) { }
}

public class BarcodeData
{
    public int Id { get; set; }
    public string BarcodeValue { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
