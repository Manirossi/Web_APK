var builder = WebApplication.CreateBuilder(args);

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAll");  // Apply CORS globally

app.MapPost("/save-barcode", async (HttpContext context, BarcodeContext db) =>
{
    var form = await context.Request.ReadFromJsonAsync<BarcodeData>();
    
    if (form is not null && !string.IsNullOrWhiteSpace(form.BarcodeValue))
    {
        db.Barcodes.Add(new BarcodeData { BarcodeValue = form.BarcodeValue });
        await db.SaveChangesAsync();
        return Results.Ok(new { message = "Barcode Saved Successfully!" });
    }
    return Results.BadRequest(new { message = "Invalid Barcode Data!" });
});
var builder = WebApplication.CreateBuilder(args);

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAll");  // Apply CORS globally

app.MapPost("/save-barcode", async (HttpContext context) =>
{
    var form = await context.Request.ReadFromJsonAsync<BarcodeData>();

    if (form is not null && !string.IsNullOrWhiteSpace(form.BarcodeValue))
    {
        // Save barcode logic here
        return Results.Ok(new { message = "Barcode Saved Successfully!" });
    }
    return Results.BadRequest(new { message = "Invalid Barcode Data!" });
});

app.Run();

app.Run();
