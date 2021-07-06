using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ganss.XSS;
using Markdig;

namespace TestMarkdown.Services
{
    public interface IMarkdownProcessor
    {
        string ToHtml(string source);
    }

    public class MarkdigMarkdownProcessor : IMarkdownProcessor
    {
        public MarkdigMarkdownProcessor()
        {
            this.pipeline = new MarkdownPipelineBuilder()
                .UseSoftlineBreakAsHardlineBreak()
                .UseBootstrap()
                .UseAdvancedExtensions()
                .Build();

            this.sanitizer = new HtmlSanitizer();
            this.sanitizer.AllowedAttributes.Add("class");
            this.sanitizer.AllowedAttributes.Add("style");
        }

        public string ToHtml(string source)
        {
            var html = Markdown.ToHtml(source ?? string.Empty, this.pipeline);
            var sanitized = this.sanitizer.Sanitize(html);

            return sanitized;
        }

        private MarkdownPipeline pipeline;
        private HtmlSanitizer sanitizer;
    }
}
