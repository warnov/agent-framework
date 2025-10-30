
using Azure.AI.Agents.Persistent;
using Azure.Identity;
using Utilities;

string endpoint = Environment.GetEnvironmentVariable("FOUNDRY_ENDPOINT")!;
string model = Environment.GetEnvironmentVariable("MODEL")!;

PersistentAgentsClient client = new(
    endpoint, new DefaultAzureCredential());

var aiFoundryAgent = await client.Administration.CreateAgentAsync(model, "WarAgent", "Sample Agent", "You are a helpful Assistant");

var agent = await client.GetAIAgentAsync(aiFoundryAgent.Value.Id);

var thread = agent.GetNewThread();

////Full response sample
//var response = await agent.RunAsync("Quién descubrió a América", thread);
//Console.WriteLine(response);
//Console.WriteLine("-----");

////Streaming response sample
await foreach (var update in agent.RunStreamingAsync("Como se prepara la cazuela de mariscos?", thread))
{
    Console.Write(update);
}

//await Utils.AgentUsageSample(agent, "Explícame la teoría de la relatividad de manera sencilla.", "¿Cuál es el impacto del cambio climático en los ecosistemas marinos?", "AI Foundry", thread);

await Utils.AgentUsageSampleTokensCount(agent, "Explícame la teoría de la relatividad de manera sencilla.", "¿Cuál es el impacto del cambio climático en los ecosistemas marinos?", "AI Foundry", thread);