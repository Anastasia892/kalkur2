using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kalkur2
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string ItogChanged
        {
            get
            {
                return model.itog.ToString();
            }
        }

        public List<string> cbox
        {
            get
            {
                return model.datalist;
            }
        }

        public static float oneSV
        {
            set
            {
                model.one = value;
            }
        }

        public static float twoSV
        {
            set
            {
                model.two = value;
            }
        }

        public static int idSV
        {
            set
            {
                model.id = value;
            }
        }

        public RoutedCommand Command { get; set; } = new RoutedCommand();
        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            switch (model.id)
            {
                case 0:
                    model.itog = model.one + model.two;
                    break;
                case 1:
                    model.itog = model.one * model.two;
                    break;
                case 2:
                    model.itog = model.one - model.two;
                    break;
                case 3:
                    model.itog = model.one / model.two;
                    break;
            }



            PropertyChanged(this, new PropertyChangedEventArgs("ItogChanged"));
        }

        public CommandBinding bind;
        public ViewModel()
        {
            bind = new CommandBinding(Command);
            bind.Executed += Command_Executed;
        }
    }
}
