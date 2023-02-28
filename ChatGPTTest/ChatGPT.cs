using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTTest
{
    internal class ChatGPT
    {
        public OpenAIService Service { get; private set; }

        public ChatGPT()
        {
            Service = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = ENV.KEY
            });
        }

        public async Task<string> GenerateText(string prompt)
        {
            var completionResult = await Service.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = prompt,
                Model = Models.TextDavinciV3
            });

            if (completionResult.Successful)
            {
                var choice = completionResult.Choices.FirstOrDefault();
                if (choice != null) { return choice.Text; }
                return "Nenhuma resposta encontrada";
            }

            return $"{completionResult.Error.Code}: {completionResult.Error.Message}";
        }

        public async Task<string> GenerateImage(string prompt)
        {
            var completionResult = await Service.Image.CreateImage(new ImageCreateRequest()
            {
                Prompt = prompt,
                N = 1,
                Size = StaticValues.ImageStatics.Size.Size256,
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url
            });

            if (completionResult.Successful)
            {
                var choice = completionResult.Results.FirstOrDefault();
                if (choice != null) { return choice.Url; }
                return "Nenhuma resposta encontrada";
            }

            return $"{completionResult.Error.Code}: {completionResult.Error.Message}";
        }

    }
}
