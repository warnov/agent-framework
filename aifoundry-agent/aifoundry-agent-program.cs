
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
//var response = await agent.RunAsync("Qui�n descubri� a Am�rica", thread);
//Console.WriteLine(response);
//Console.WriteLine("-----");

////Streaming response sample
await foreach (var update in agent.RunStreamingAsync("Como se prepara la cazuela de mariscos?", thread))
{
    Console.Write(update);
}

//await Utils.AgentUsageSample(agent, "Expl�came la teor�a de la relatividad de manera sencilla.", "�Cu�l es el impacto del cambio clim�tico en los ecosistemas marinos?", "AI Foundry", thread);

await Utils.AgentUsageSampleTokensCount(agent, "Expl�came la teor�a de la relatividad de manera sencilla.", "�Cu�l es el impacto del cambio clim�tico en los ecosistemas marinos?", "AI Foundry", thread);