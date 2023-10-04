using System;
using System.Threading.Tasks;
using OpenAI_API;

namespace GPTTerminal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /* Enter your OpenAI API Key or the terminal will not work */
            string OPENAIKEY = "<PUT YOUR OPENAI API KEY HERE";

            bool dalle = false;
            bool chatgpt = false;
            Console.Title = "OpenAI Terminal";
            OpenAIAPI api = new OpenAIAPI(OPENAIKEY);
            var chat = api.Chat.CreateConversation();
            Console.WriteLine("Hello! Welcome to the OpenAI Terminal Made by Purcify");
            Console.WriteLine("If you want to use commands while using any AI, you can use the Prefix '!'. For a list of commands use '!help'");
            Console.WriteLine("Before we get started, what AI would you like to use? DALLE or ChatGPT?");
            string a = Console.ReadLine();
            if (a == "DALLE")
            {
                dalle = true;
                Console.Clear();
                Console.WriteLine("Welcome to DALL-E!");
            }
            else if (a == "ChatGPT")
            {
                chatgpt = true;
                Console.Clear();
                Console.WriteLine("Welcome to ChatGPT!");
            }
            while (dalle == true)
            {
                Console.Write("DALL-E> ");
                string prompt = Console.ReadLine();
                string prefix = prompt.Substring(0, 1);
                if (prefix == "!")
                {
                    if (prompt == "!help")
                    {
                        Console.WriteLine("This is the help command.");
                    }
                }
                else
                {
                    var result = await api.ImageGenerations.CreateImageAsync(prompt);
                    Console.WriteLine(result.Data[0].Url);
                }
            }
            while (chatgpt == true)
            {
                Console.Write("GPT> ");
                string prompt = Console.ReadLine();
                string prefix = prompt.Substring(0, 1);
                if (prefix == "!")
                {
                    if (prompt == "!help")
                    {
                        Console.WriteLine("This is the help command.");
                    }
                }
                else
                {
                    chat.AppendUserInput(prompt);
                    string response = await chat.GetResponseFromChatbotAsync();
                    Console.WriteLine(response);
                }
            }
        }
    }
}
