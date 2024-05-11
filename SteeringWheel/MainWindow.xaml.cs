using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SteeringWheel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IKeyboardMouseEvents _globalHook;
        private int _rotation;
        public MainWindow()
        {
            _globalHook = Hook.GlobalEvents();

            _globalHook.KeyUp += KeyUp;
            _globalHook.KeyDown += KeyDown;

            _rotation = 0;

            InitializeComponent();
        }

        private void KeyUp(object? sender, System.Windows.Forms.KeyEventArgs e)
        {
            _rotation = 0;
            steeringWheel.RenderTransform = new RotateTransform(0);
        }

        private void KeyDown(object? sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                if (_rotation > -90)
                    _rotation -= 15;
            }

            else if (e.KeyCode == Keys.D)
            {
                if (_rotation < 90)
                    _rotation += 15;
            }
            
            steeringWheel.RenderTransform = new RotateTransform(_rotation);
        }

    }
}
