using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using TestMarkdown.Services;

namespace TestMarkdown.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly IMarkdownProcessor processor;

        public IndexModel(ILogger<IndexModel> logger, IMarkdownProcessor processor)
        {
            this.logger = logger;
            this.processor = processor;
        }

        public string Source { get; set; }
        public string MarkdownHtml { get; set; }

        public void OnGet()
        {
            this.Source = "# caption\n- aaa\n- bbb";
            this.MarkdownHtml = this.processor.ToHtml(this.Source);
        }

        public PartialViewResult OnPostMarkdown(string source)
        {
            return new PartialViewResult
            {
                ViewName = "_Markdown",
                ViewData = new ViewDataDictionary<string>(ViewData, this.processor.ToHtml(source)),
            };
        }
    }
}
