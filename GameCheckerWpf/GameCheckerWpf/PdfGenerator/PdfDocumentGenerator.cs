using GameCheckerWpf.Models;
using IronPdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.PdfGenerator
{
    public class PdfDocumentGenerator
    {
        private ComputerHardware computerHardware;

        public PdfDocumentGenerator()
        {
            computerHardware = new ComputerHardware();
        }

        public void savePDF()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF document (*.pdf)|*.pdf";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (saveFileDialog.ShowDialog() == true)
            {
                var lines = new ChromePdfRenderer();
                PdfDocument document = lines.RenderHtmlAsPdf(generatePDF());
                if (saveFileDialog.FileName != null)
                {
                    document.SaveAs(saveFileDialog.FileName);
                }
            }
        }

        public string generatePDF()
        {
            StringBuilder sb = new StringBuilder();

            string motherBoard = computerHardware.MotherBoard;
            var motherBoardImage = @"C:/Users/timzu/Source/Repos/GameCheckerAPP/GameCheckerWpf/GameCheckerWpf/Images/motherboardLogo.png";
            var imgMobo = $"<img src='{motherBoardImage}' width=50 height=50 style=margin-right:30px>";

            string cpu = computerHardware.CentralProcessingUnit;
            var cpuImage = @"C:/Users/timzu/Source/Repos/GameCheckerAPP/GameCheckerWpf/GameCheckerWpf/Images/CPUlogo.png";
            var imgCpu = $"<img src='{cpuImage}' width=50 height=50 style=margin-rigt:30px>";

            string gpu = computerHardware.GraphicCard;
            var gpuImage = @"C:/Users/timzu/Source/Repos/GameCheckerAPP/GameCheckerWpf/GameCheckerWpf/Images/GPUlogo.png";
            var imgGpu = $"<img src='{gpuImage}' width=50 height=50 style=margin-right:30px>";

            string os = computerHardware.OperatingSystem;
            var osImage = @"C:/Users/timzu/Source/Repos/GameCheckerAPP/GameCheckerWpf/GameCheckerWpf/Images/windowsLogo.png";
            var imgOs = $"<img src='{osImage}' width=50 height=50 style=margin-right:30px>";

            var logoImage = @"C:/Users/timzu/Source/Repos/GameCheckerAPP/GameCheckerWpf/GameCheckerWpf/Images/Logo-gamechecker.png";
            var imgLogo = $"<img src='{logoImage}' width=160 height=125>";
            sb.Append(imgLogo); //<div style=width:100%;background-color:#0B0B3F;margin-right:-200px>

            sb.Append("<div style=margin-top:100px>" +
                    "<div style=width:600px;display:flex;align-items:center;margin-top:15px>" + "<div>" + imgOs + "</div>" + "<h2>" + os + "</h2>" + "</div>" +
                    "<div style=width:600px;display:flex;align-items:center;margin-top:15px>" + "<div>" + imgMobo + "</div>" + "<h2>" + motherBoard + "</h2>" + "</div>" +
                    "<div style=width:600px;display:flex;align-items:center;margin-top:15px>" + "<div>" + imgCpu + "</div>" + "<h2>" + cpu + "</h2>" + "</div>" +
                    "<div style=width:600px;display:flex;align-items:center;margin-top:15px>" + "<div>" + imgGpu + "</div>" + "<h2>" + gpu + "</h2>" + "</div>" +
                    "</div>");
            //"<center><h5 style=position:absolute;bottom:10px;border:3px solid #8AC007;>" "</h5></center>")
            return sb.ToString();
        }
    }
}
