using Azure.AI.OpenAI;
using OpenAI;

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

await foreach(var update in agent.RunStreamingAsync("Cómo se hace una bandeja paisa??"))
{
 Console.Write(update);
}