using AgentMicrosoftIntro.Components;
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);

var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ?? throw new InvalidOperationException("AZURE_OPENAI_ENDPOINT is not set.");
var deploymentName =  Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT_NAME") ?? "gpt-4.1-mini";
var key = Environment.GetEnvironmentVariable("AZURE_API_KEY");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

const string promptSystemMessage = @"Você é um assistente virtual de um hotel. Você ajuda hóspedes da seguinte forma:
                                     Fazer reservas de quartos, ao reservar um quarto responder com: 'Reserva feita com sucesso'. 
                                     Você ajuda a procurar por quartos de acordo com a descrição.
                                     Verificar quais quartos estão disponíveis, exibir uma lista no formato: 'Numero do quarto - descrição' apenas dos quartos disponíveis. 
                                     Cancelar reserva de um quarto.
                                     Se houver tentativa de reservar um quarto que não está disponível, responder com uma mensagem de erro dizendo que o quarto não está disponível.";

AIAgent azureOpenAIClient = new AzureOpenAIClient(
        new Uri(endpoint),
        new AzureKeyCredential(key))
    .GetChatClient(deploymentName)
    .CreateAIAgent(
        instructions: promptSystemMessage,
        description: "Você ajuda hóspedes de um hotel a reservar quartos e mostrar descrições dos quartos.",
        name: "Hotel Assistant",
        tools: [
            AIFunctionFactory.Create(RoomTools.Rerservar), 
            AIFunctionFactory.Create(RoomTools.MostrarTodosQuartosDisponiveis), 
            AIFunctionFactory.Create(RoomTools.MostrarTodosQuartos),
            AIFunctionFactory.Create(RoomTools.Cancelar)
        ]);


builder.Services.AddSingleton(azureOpenAIClient);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
