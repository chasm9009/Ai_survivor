using System.Collections.Generic;
using UnityEngine;

public class HintArray : MonoBehaviour
{
    static public Dictionary<string, string[]> hintDictionary = new Dictionary<string, string[]>()
    {
        // Duty to inform
        {"What does duty to inform require?", new string[] {
            "A. That companies delete all data immediately",
            "B. That individuals are informed about how their data is used",
            "C. That data is always anonymous",
            "D. That data cannot be stored",
            "Think transparency, what must the user know?"}},

        {"Who is the data controller?", new string[] {
            "A. The government",
            "B. The person whose data is collected",
            "C. Any third party receiving data",
            "D. The company responsible for processing the data",
            "Who decides what happens to the data?"}},

        // Data Documentation
        {"What must be included when documenting AI use in an assignment?", new string[] {
            "A. A summary written in your own words",
            "B. Only the name of the AI tool",
            "C. The number of times you used the AI",
            "D. The prompt, answer, platform, version, history and date of training data",
            "Think about what someone would need to fully trace your AI use. What did you ask, what did it reply, and where?"}},

        {"Why is it important to document which version of an AI model you used?", new string[] {
            "A. Because different versions can give different answers to the same prompt",
            "B. Because the version determines how long your assignment can be",
            "C. Because newer versions are always better",
            "D. Because older versions are not allowed in assignments",
            "Think about what changes between versions. Would the same question always get the same answer?"}},

        // Data shared with AI
        {"What must you do before sharing someones personal data with an AI platform?", new string[] {
            "A. Only share it if the file is under 10MB",
            "B. Make sure the data is older than 1 year",
            "C. Ask the person for permission first",
            "D. Convert it to anonymous data automatically",
            "Think about whose data it is, do they know it is being sent somewhere?"}},

        {"What type of data are you allowed to share with an AI platform without special permission?", new string[] {
            "A. Personal emails from colleagues",
            "B. Any data as long as it is anonymized first",
            "C. Internal company reports",
            "D. Information that is already publicly available",
            "Think about whether the information was already out there for anyone to find, does sharing it change anything?"}},

        // AI Platform Evaluation
        {"Why is a content cut-off date important when using an AI platform?", new string[] {
            "A. It limits how long your prompts can be",
            "B. It determines how fast the platform responds",
            "C. It tells you how many questions you can ask the platform",
            "D. It shows you how up-to-date the platforms knowledge is",
            "Think about what happens if an AI was only trained on data from 2 years ago, could it know about recent events?"}},

        {"Why should you always verify the output from a generative AI platform?", new string[] {
            "A. Because verified results are automatically saved to your account",
            "B. Because the output may be biased or incorrect due to its training data",
            "C. Because AI platforms are not allowed to give final answers",
            "D. Because AI platforms charge more for unverified results",
            "Think about where the AI gets its answers from, can that source ever be wrong or one-sided?"}},

        // Consent
        {"What does it mean that consent must be unequivocal?", new string[] {
            "A. Consent can be assumed if the person does not object",
            "B. The person must repeat their consent every month",
            "C. Consent must be clearly and actively given, not just implied",
            "D. The person must sign a physical document",
            "Think about the difference between someone saying yes out loud versus just not saying no, are they the same?"}},

        {"How long are you allowed to keep someones consent?", new string[] {
            "A. Until the person asks you to stop",
            "B. Only for as long as you actually need it, then delete it",
            "C. For a maximum of 5 years by law",
            "D. For as long as your company exists",
            "Think about the purpose of collecting the consent in the first place, what happens when that purpose is gone?"}},
    };

    static public Dictionary<string, string> quizDictionary = new Dictionary<string, string>()
    {
        // Duty to inform
        {"B. That individuals are informed about how their data is used", "What does duty to inform require?"},
        {"D. The company responsible for processing the data", "Who is the data controller?"},

        // Data Documentation
        {"D. The prompt, answer, platform, version, history and date of training data", "What must be included when documenting AI use in an assignment?"},
        {"A. Because different versions can give different answers to the same prompt", "Why is it important to document which version of an AI model you used?"},

        // Data shared with AI
        {"C. Ask the person for permission first", "What must you do before sharing someones personal data with an AI platform?"},
        {"D. Information that is already publicly available", "What type of data are you allowed to share with an AI platform without special permission?"},

        // AI Platform Evaluation
        {"D. It shows you how up-to-date the platforms knowledge is", "Why is a content cut-off date important when using an AI platform?"},
        {"B. Because the output may be biased or incorrect due to its training data", "Why should you always verify the output from a generative AI platform?"},

        // Consent
        {"C. Consent must be clearly and actively given, not just implied", "What does it mean that consent must be unequivocal?"},
        {"B. Only for as long as you actually need it, then delete it", "How long are you allowed to keep someones consent?"},
    };
}