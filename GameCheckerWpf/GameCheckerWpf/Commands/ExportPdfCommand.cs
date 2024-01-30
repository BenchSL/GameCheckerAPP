using GameCheckerWpf.PdfGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.Commands
{
    public class ExportPdfCommand : MethodCommandBase
    {
        private PdfDocumentGenerator pdfGenerator;

        public ExportPdfCommand()
        {
            pdfGenerator = new PdfDocumentGenerator();
        }

        public override void Execute(object? parameter)
        {
            pdfGenerator.savePDF();
        }
    }
}
