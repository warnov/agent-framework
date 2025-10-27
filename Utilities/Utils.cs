using Microsoft.Agents.AI;

namespace Utilities
{
    public static class Utils
    {
        public static async Task AgentUsageSample(ChatClientAgent agent, string fullResponsePrompt, string streamingResponseSample, string agentType, AgentThread? thread = null)
        {
            Console.WriteLine($"--- {agentType} Agent Sample ---\n\n");

            //Full response sample
            var response = await agent.RunAsync(fullResponsePrompt, thread);
            Console.WriteLine(response);
            Console.WriteLine("-----");
            //Streaming response sample
            await foreach (var update in agent.RunStreamingAsync(streamingResponseSample, thread))
            {
                Console.Write(update);
            }
        }        
    }
}
