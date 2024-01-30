
using GalaSoft.MvvmLight.Command;
using GameCheckerWpf.Commands;
using GameCheckerWpf.Helper;
using GameCheckerWpf.Models;
using GameCheckerWpf.PdfGenerator;
using GameCheckerWpf.Services;
using GameCheckerWpf.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Management;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameCheckerWpf.ViewModels
{
    public class PerformanceViewModel : BaseViewModel
    {
        private string operatingSystem;
        private string motherBoard;
        private string graphicCard;
        private string centralProcessingUnit;
        private string randomAccessMemory;

        public string OperatingSystem
        {
            get { return operatingSystem; }
            set
            {
                operatingSystem = value;
                OnPropertyChanged(nameof(OperatingSystem));
            }
        }

        public string MotherBoard
        {
            get { return motherBoard; }
            set
            {
                motherBoard = value;
                OnPropertyChanged(nameof(MotherBoard));
            }
        }

        public string GraphicCard
        {
            get { return graphicCard; }
            set
            {
                graphicCard = value;
                OnPropertyChanged(nameof(GraphicCard));
            }
        }

        public string CentralProcessingUnit
        {
            get { return centralProcessingUnit; }
            set
            {
                centralProcessingUnit = value;
                OnPropertyChanged(nameof(CentralProcessingUnit));
            }
        }

        public string RandomAccessMemory
        {
            get { return randomAccessMemory; }
            set
            {
                randomAccessMemory = value;
                OnPropertyChanged(nameof(RandomAccessMemory));
            }
        }

        private readonly HttpClient client;
        private GameService gameService;
        private ComputerHardware computerHardware;
        private PdfDocumentGenerator pdfGenerator;

        private readonly MainWindowViewModel viewModel;

        //private ObservableCollection<GameModel> games;
        //public ObservableCollection<GameModel> Games
        //{
        //    get { return games; }
        //    set
        //    {
        //        games = value;
        //        OnPropertyChanged(nameof(Games));
        //    }
        //}

        public ICommand ExportPdfCommand { get; set; }
        public ICommand SelectGameCommand { get; set; }

        public PerformanceViewModel()
        {
            client = new HttpClient();
            gameService = new GameService(client);
            pdfGenerator = new PdfDocumentGenerator();

            GameCheckerAPI.Models.ComputerHardware computerHardwareMock = HardwareHelper.getCurrentHardware();
            this.OperatingSystem = computerHardwareMock.OS;
            this.CentralProcessingUnit = computerHardwareMock.CPU;
            this.GraphicCard = computerHardwareMock.GraphicsCard;
            this.MotherBoard = getMotherBoardInfo();
            this.RandomAccessMemory = computerHardwareMock.RAM;

            ExportPdfCommand = new ExportPdfCommand();
        }

        private string getMotherBoardInfo()
        {
            SelectQuery Sq = new SelectQuery("Win32_MotherboardDevice");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            StringBuilder sb = new StringBuilder();

            string motherboardInfo = "";

            foreach (ManagementObject mo in osDetailsCollection)
            {
                motherboardInfo = (string)mo["Name"] + " GA-H61M";
            }
            return motherboardInfo;
        }

    }
}
