using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameLab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CPlayer player;
        private CController controller;
        private DispatcherTimer timer;
        private double gameTimeElapsed;
        private const double maxGameTime = 30.0;

        public MainWindow()
        {
            InitializeComponent();

            player = new CPlayer(1.5);

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            controller.update(0.1, GameCanvas);
            player.update(0.1);

            gameTimeElapsed += 0.1;
            TxtTime.Text = $"Time: {gameTimeElapsed:F1}s";

            TxtScore.Text = $"Score: {controller.Points:F0}";

            if (gameTimeElapsed >= maxGameTime)
            {
                timer.Stop();
                GameCanvas.Children.Clear();
                controller.Objects.Clear();
                MessageBox.Show($"Игра окончена! Вы набрали {controller.Points:F0} очков.", "Финиш");
                BtnStart.IsEnabled = true; 
            }
        }
    }
}