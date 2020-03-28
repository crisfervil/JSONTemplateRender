using DotLiquid;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JSONTemplateRender
{
    class Program
    {
        static void Main(FileInfo jsonFile, FileInfo templateFile, FileInfo outputFile) 
        {
            //  --json-file ..\..\..\testfiles\quiz.json --template-file ..\..\..\testfiles\quiz.liq --output-file ..\..\..\testfiles\quiz.html

            if (jsonFile == null) throw new ArgumentException("jsfonFile parameter required");
            if (templateFile == null) throw new ArgumentException("templateFile parameter required");
            if (outputFile == null) throw new ArgumentException("outputFile parameter required");

            string jsonFileContent = System.IO.File.ReadAllText(jsonFile.FullName);
            string templateFileContent = System.IO.File.ReadAllText(templateFile.FullName);

            var jsonObj = JsonConvert.DeserializeObject<IDictionary<string, object>>(jsonFileContent, new DictionaryConverter());
            var jsonHash = Hash.FromDictionary(jsonObj);

            Template template = Template.Parse(templateFileContent);
            var renderedText = template.Render(jsonHash);

            System.IO.File.WriteAllText(outputFile.FullName, renderedText);
        }
    }
}
