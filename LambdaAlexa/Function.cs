using System;
using System.Collections.Generic;
using System.Net.Http;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace LambdaAlexa
{
    public class Function
    {

        public List<string> FunFacts = new List<string>()
        {
            "raj thapa is genius.",
            "avash thapa is raj thapa's nephew.",
            "bishal thapa is his brother",
            "His wife is the prettiest girl in the world",
            "He loves playing fifa",
            "He loves eating momos",
            "raj thapa is good at photography",
            "raj thapa has one sister and one brother.",
            "His nephew has a PS4 and he loves it"
        };

        public const string INVOCATION_NAME = "Country Info";

        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            var requestType = input.GetRequestType();

            var rnd = new Random();
            int r = rnd.Next(FunFacts.Count);

            return MakeSkillResponse(FunFacts[r], true);
        }


        private SkillResponse MakeSkillResponse(string outputSpeech,
            bool shouldEndSession,
            string repromptText = "Just say, tell me about Canada to learn more. To exit, say, exit.")
        {
            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
                OutputSpeech = new PlainTextOutputSpeech { Text = outputSpeech }
            };

            if (repromptText != null)
            {
                response.Reprompt = new Reprompt() { OutputSpeech = new PlainTextOutputSpeech() { Text = repromptText } };
            }

            var skillResponse = new SkillResponse
            {
                Response = response,
                Version = "1.0"
            };
            return skillResponse;
        }
    }
}