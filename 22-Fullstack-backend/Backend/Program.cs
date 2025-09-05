using Backend.Services; // Importa il namespace Backend.Services per accedere ai servizi definiti in esso
using Microsoft.AspNetCore.Builder; // Importa il namespace Microsoft.AspNetCore.Builder per configurare l'applicazione ASP.NET Core
using Microsoft.Extensions.DependencyInjection; // Importa il namespace Microsoft.Extensions.DependencyInjection per configurare i servizi dell'applicazione
using Microsoft.Extensions.Hosting; // Importa il namespace Microsoft.Extensions.Hosting per configurare l'hosting dell'applicazione
using Microsoft.OpenApi.Models; // Importa il namespace Microsoft.OpenApi.Models per configurare Swagger e la documentazione delle API

// CREAZIONE DELL'APPLICAZIONE

var builder = WebApplication.CreateBuilder(args); // Crea un nuovo builder per l'applicazione ASP.NET Core

// 1. Aggiungi i controller
// i controller sono responsabili della gestione delle richieste HTTP e della restituzione delle risposte
builder.Services.AddControllers();

// 2. Registra il servizio in-memory per i prodotti
// in pratica vado a simulare un archivio di dati dato che non posso farlo nel program principale lo faccio in una folders servizi
builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<PurchaseService>();
builder.Services.AddSingleton<CategoryService>();

// 3. Configura CORS per permettere tutte le origini (sviluppo locale)
// CORS (Cross-Origin Resource Sharing) è una politica di sicurezza che permette o blocca le richieste tra domini diversi
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin() // Permette richieste da qualsiasi origine (utile in fase di sviluppo)
            .AllowAnyHeader() // Permette qualsiasi header (intestazione) nelle richieste cioè le informazioni inviate con la richiesta
            .AllowAnyMethod(); // Permette qualsiasi metodo HTTP (GET, POST, PUT, DELETE, ecc.)
    });
});

// 6. Configura Swagger per la documentazione dell'API
// Swagger è uno strumento che genera documentazione interattiva per le API, utile per testare e comprendere le API
// Aggiunge il supporto per Swagger, che permette di documentare e testare le API in modo interattivo
// Swagger è utile per gli sviluppatori per comprendere come utilizzare le API e per testare le richieste direttamente dal browser
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo {
    Title = "MiniApp API",
    Version = "v1"
  });
});

var app = builder.Build(); // Costruisce l'applicazione ASP.NET Core

// CONFIGURAZIONE DELL'APPLICAZIONE

// il middleware è un componente che gestisce una funzionalita' specifica dell'applicazione

// 4. Middleware HTTPS e CORS
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Mostra errori dettagliati in sviluppo
}

app.UseHttpsRedirection(); // Reindirizza le richieste HTTP a HTTPS verso HTTPS

app.UseCors(); // Applica le politiche CORS definite in precedenza

// 5. Middleware per la documentazione delle API con Swagger
// Swagger è un middleware che genera la documentazione delle API e rende disponibile un'interfaccia
// interattiva per testare le API direttamente dal browser
// Questo middleware deve essere posizionato dopo l'applicazione delle politiche CORS e prima della mappatura dei controller
// in modo che le richieste alle API siano documentate
app.UseSwagger();              // rende disponibile /swagger/v1/swagger.json
app.UseSwaggerUI(c => {
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiniApp API V1");
});

// 5. Mappa i controller API
// in pratica mappa le rotte dei controller API per gestire le richieste HTTP
// mappare le rotte significa associare le richieste HTTP a specifici metodi nei controller
app.MapControllers();

app.Run(); // Avvia l'applicazione e inizia ad ascoltare le richieste HTTP