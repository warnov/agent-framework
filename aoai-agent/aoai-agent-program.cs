using Azure.AI.OpenAI;
using OpenAI;
using Utilities;

string endpoint = Environment.GetEnvironmentVariable("ENDPOINT")!;
string apiKey = Environment.GetEnvironmentVariable("API_KEY")!;
string model = Environment.GetEnvironmentVariable("MODEL")!;

AzureOpenAIClient client = new(
 new Uri(endpoint),
 new Azure.AzureKeyCredential(apiKey)
 );

var agent = client.GetChatClient(model).CreateAIAgent();
//var response = await agent.RunAsync("Según twitter Quien es WarNov?");
//Console.WriteLine(response);

//await foreach (var update in agent.RunStreamingAsync("Cómo se hace una bandeja paisa??"))
//{
//    Console.Write(update);
//}

await Utils.AgentUsageSample(
    agent,
    "Explícame la teoría de la relatividad de manera sencilla.",
    "¿Cuál es el impacto del cambio climático en los ecosistemas marinos?",
    "Azure OpenAI"
    );