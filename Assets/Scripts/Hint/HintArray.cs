using System.Collections.Generic;
using UnityEngine;

public static class HintArray
{
    public static readonly Dictionary<string, string[]> hintDictionary = new()
    {
        // Duty to inform
        {"What does duty to inform require?", new string[] {
            "That companies delete all data immediately",
            "That individuals are informed about how their data is used",
            "That data is always anonymous",
            "That data cannot be stored",
            "Duty to inform means a company must tell individuals exactly how their personal data is used"}},

        {"Who is the data controller?", new string[] {
            "The government",
            "The person whose data is collected",
            "Any third party receiving data",
            "The company responsible for processing the data",
            "The data controller is the company that decides how and why personal data is processed"}},

        // Data Documentation
        {"What must be included when documenting AI use in an assignment?", new string[] {
            "A summary written in your own words",
            "Only the name of the AI tool",
            "The number of times you used the AI",
            "The prompt, answer, platform, version, history and date of training data",
            "Documenting AI use means including the prompt, answer, platform, version, history, and training data date"}},

        {"Why is it important to document which version of an AI model you used?", new string[] {
            "Because different versions can give different answers to the same prompt",
            "Because the version determines how long your assignment can be",
            "Because newer versions are always better",
            "Because older versions are not allowed in assignments",
            "It is important to document the AI version because different versions can give different answers to the same prompt"}},

        // Data shared with AI
        {"What must you do before sharing someones personal data with an AI platform?", new string[] {
            "Only share it if the file is under 10MB",
            "Make sure the data is older than 1 year",
            "Ask the person for permission first",
            "Convert it to anonymous data automatically",
            "Before sharing personal data with AI, you must get permission from the person the data belongs to"}},

        {"What type of data are you allowed to share with an AI platform without special permission?", new string[] {
            "Personal emails from colleagues",
            "Any data as long as it is anonymized first",
            "Internal company reports",
            "Information that is already publicly available",
            "You can only share data with AI without permission if it is already publicly available to everyone"}},

        // AI Platform Evaluation
        {"Why is a content cut-off date important when using an AI platform?", new string[] {
            "It limits how long your prompts can be",
            "It determines how fast the platform responds",
            "It tells you how many questions you can ask the platform",
            "It shows you how up-to-date the platforms knowledge is",
            "A content cut-off date shows how up-to-date the AI platforms knowledge is"}},

        {"Why should you always verify the output from a generative AI platform?", new string[] {
            "Because verified results are automatically saved to your account",
            "Because the output may be biased or incorrect due to its training data",
            "Because AI platforms are not allowed to give final answers",
            "Because AI platforms charge more for unverified results",
            "You must verify AI output because it can be biased or incorrect based on its training data"}},

        // Consent
        {"What does it mean that consent must be unequivocal?", new string[] {
            "Consent can be assumed if the person does not object",
            "The person must repeat their consent every month",
            "Consent must be clearly and actively given, not just implied",
            "The person must sign a physical document",
            "Unequivocal consent means the person must clearly and actively say yes, not just stay silent"}},

        {"How long are you allowed to keep someones consent?", new string[] {
            "Until the person asks you to stop",
            "Only for as long as you actually need it, then delete it",
            "For a maximum of 5 years by law",
            "For as long as your company exists",
            "You can only keep someones consent for as long as you need it for its purpose, then it must be deleted"}},
    };

    public static readonly Dictionary<string, string> quizDictionary = new()
    {
        // Duty to inform
        {"What does duty to inform require?", "That individuals are informed about how their data is used"},
        {"Who is the data controller?", "The company responsible for processing the data"},

        // Data Documentation
        {"What must be included when documenting AI use in an assignment?", "The prompt, answer, platform, version, history and date of training data"},
        {"Why is it important to document which version of an AI model you used?", "Because different versions can give different answers to the same prompt"},

        // Data shared with AI
        {"What must you do before sharing someones personal data with an AI platform?", "Ask the person for permission first"},
        {"What type of data are you allowed to share with an AI platform without special permission?", "Information that is already publicly available"},

        // AI Platform Evaluation
        {"Why is a content cut-off date important when using an AI platform?", "It shows you how up-to-date the platforms knowledge is"},
        {"Why should you always verify the output from a generative AI platform?", "Because the output may be biased or incorrect due to its training data"},

        // Consent
        {"What does it mean that consent must be unequivocal?", "Consent must be clearly and actively given, not just implied"},
        {"How long are you allowed to keep someones consent?", "Only for as long as you actually need it, then delete it"},
    };
}
