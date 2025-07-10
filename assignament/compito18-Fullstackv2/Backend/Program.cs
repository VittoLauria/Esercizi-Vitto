using Backend.Services; // Importa il namespace Backend.Services per accedere ai servizi definiti in esso
using Microsoft.AspNetCore.Builder; // Importa il namespace Microsoft.AspNetCore.Builder per configurare l'applicazione ASP.NET Core
using Microsoft.Extensions.DependencyInjection; // Importa il namespace Microsoft.Extensions.DependencyInjection per configurare i servizi dell'applicazione
using Microsoft.Extensions.Hosting; // Importa il namespace Microsoft.Extensions.Hosting per configurare l'hosting dell'applicazione

// CREAZIONE DELL'APPLICAZIONE

var builder = WebApplication.CreateBuilder(args); // Crea un nuovo builder per l'applicazione ASP.NET Core

// 1. Aggiungi i controller
// i controller sono responsabili della gestione delle richieste HTTP e della restituzione delle risposte
builder.Services.AddControllers();

// 2. Registra il servizio in-memory per i prodotti
// in pratica vado a simulare un archivio di dati dato che non posso farlo nel program principale lo faccio in una folders servizi
builder.Services.AddSingleton<AlbumService>();

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

// 5. Mappa i controller API
// in pratica mappa le rotte dei controller API per gestire le richieste HTTP
// mappare le rotte significa associare le richieste HTTP a specifici metodi nei controller
app.MapControllers();

app.Run(); // Avvia l'applicazione e inizia ad ascoltare le richieste HTTP