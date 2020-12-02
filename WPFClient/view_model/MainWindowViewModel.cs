using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.view_model
{
    public class MainWindowViewModel
    {
        private static readonly MainWindowViewModel instance = new MainWindowViewModel();
        public Action CloseAction { get; set; }
        
        
        private MainWindowViewModel()
        {

        }
        public static MainWindowViewModel Instance
        {
            get
            {
                return instance;
            }
        }
    }

}

