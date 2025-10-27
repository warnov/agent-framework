using OpenAI;
using Utilities;

string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")!;
const string model = "gpt-5-nano";


var client = new OpenAIClient(apiKey);
var agent = client.GetChatClient(model).CreateAIAgent();

//var response = await agent.RunAsync("Qui�n descubri� a Am�rica?");
//Console.WriteLine(response);

//await foreach (var update in agent.RunStreamingAsync("Qui�n descubri� a Am�rica?"))
//{
//    Console.Write(update);
//}
//Sample usage from Utilities

await Utils.AgentUsageSample(
    agent,
    "Expl�came la teor�a de la relatividad de manera sencilla.",
    "�Cu�l es el impacto del cambio clim�tico en los ecosistemas marinos?",
    "OpenAI"
    );