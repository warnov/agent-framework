using OpenAI;
using Utilities;

string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")!;
const string model = "gpt-5-nano";


var client = new OpenAIClient(apiKey);
var agent = client.GetChatClient(model).CreateAIAgent();

//var response = await agent.RunAsync("Quién descubrió a América?");
//Console.WriteLine(response);

//await foreach (var update in agent.RunStreamingAsync("Quién descubrió a América?"))
//{
//    Console.Write(update);
//}
//Sample usage from Utilities

await Utils.AgentUsageSample(
    agent,
    "Explícame la teoría de la relatividad de manera sencilla.",
    "¿Cuál es el impacto del cambio climático en los ecosistemas marinos?",
    "OpenAI"
    );