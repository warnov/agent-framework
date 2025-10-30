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

        public static async Task AgentUsageSampleTokensCount(ChatClientAgent agent, string fullResponsePrompt, string streamingResponseSample, string agentType, AgentThread? thread = null)
        {
            Console.WriteLine($"--- {agentType} Agent Sample ---\n\n");

            //Full response sample
            var response = await agent.RunAsync(fullResponsePrompt, thread);
            Console.WriteLine(response);
            Console.WriteLine("-----");
            //Streaming response sample
            List<AgentRunResponseUpdate> updates = new();
            await foreach (var update in agent.RunStreamingAsync(streamingResponseSample, thread))
            {
                updates.Add(update);
                Console.Write(update);
            }
            var collectedResponseFromStreaming = updates.ToAgentRunResponse();
            Console.WriteLine($"\nFull response tokens used: {response.Usage?.TotalTokenCount}");
            Console.WriteLine($"Streaming Output tokens used: {collectedResponseFromStreaming.Usage?.OutputTokenCount}");

            var additionalCounts = collectedResponseFromStreaming.Usage?.AdditionalCounts;
            string reasoningTokenCount = "N/A";
            if (additionalCounts != null && additionalCounts.TryGetValue("OutputTokenDetails.ReasoningTokenCount", out var value))
            {
                reasoningTokenCount = value.ToString();
            }
            Console.WriteLine($"Streaming Reasoning Output tokens used: {reasoningTokenCount}");
        }
    }
}
