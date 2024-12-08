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

namespace Практическая_работа__10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод осуществлющий выход из программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitProgaButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Метод выводящий информацию о задании для разработке программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoProgaButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В одномерном массиве целых чисел найти \nмаксимальный среди элементов, являющ-" +
                "\nихся четными, и минимальный среди эле-\nментов, кратных А.", "О программе: ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Метод осуществляющий вывод инфорамции о разработчике программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoCreatorButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Студент группы ИСП-31\nЖаров Артём Андреевич", "О создателе:", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Метод осуществляющий создание массива из коллекции чисел, для дальнейшего поиска кратности элементов определенному числу A а так же поиска максимального четного элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputArrayTextBox.Text != "" && InputArrayTextBox.Text != " ")
            {
                var inputArray = InputArrayTextBox.Text;

                List<int> numbers = new List<int>(inputArray.Split(',').Select(int.Parse));

                int[] mas = (int[])numbers.ToArray();

                if (Int32.TryParse(InputATextBox.Text, out int A))
                {
                    int evenMax = int.MinValue;
                    int multipleMin = int.MaxValue;

                    for (int i = 0; i < mas.Length; i++)
                    {
                        if (mas[i] % 2 == 0)
                        {
                            evenMax = Math.Max(evenMax, mas[i]);
                        }

                        if (mas[i] % A == 0)
                        {
                            multipleMin = Math.Min(multipleMin, mas[i]);
                        }
                    }

                    if (evenMax != int.MinValue)
                        EvenMaxTextBlock.Text = Convert.ToString(evenMax);
                    else EvenMaxTextBlock.Text = "Нет четных чисел.";

                    if (multipleMin != int.MaxValue)
                        MultipleMinTextBlock.Text = Convert.ToString(multipleMin);
                    else MultipleMinTextBlock.Text = "Нет кратных A.";
                }
                else MessageBox.Show("Пожалуйста, введите корректное число A.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Пожалуйста, введите массив целых чисел.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}