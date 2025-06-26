using System.Buffers.Text;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
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
using Model;

namespace WpfApp
{
    public class CityInfo
    {
        public string City { get; set; }
        public int Count { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string baseUrl = "https://localhost:7194";
        private HttpClient client = new();
        

        public MainWindow()
        {
            InitializeComponent();

            client.BaseAddress = new Uri(baseUrl);
        }

        private List<string> LoadFiles()
        {
            string dir = @"d:\Development\Training\net2025\";

            List<string> files = Directory.EnumerateFiles(dir, "*.txt")
                                         .ToList();

            return files;
        }

        private async void btnTest_Click(object sender, RoutedEventArgs e)
        {
            var top20 = await client.GetFromJsonAsync<List<CityInfo>>("/city/top20");

            txbInfo.Text = "";

            foreach (var cityInfo in top20) 
            {
                txbInfo.Text += $"{cityInfo.City}: {cityInfo.Count} {Environment.NewLine}";
            }
        }

        private async void btnPersonDetail_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            bool result = int.TryParse(txtPersonID.Text, out id);

            if (!result)
            {
                txbInfo.Text = "Nepodařilo se převést ID na int";
                return;
            }

            var person =
                await client.GetFromJsonAsync<Person>($"/person/{id}");

            txbInfo.Text = "";

            txbInfo.Text =
                $"{person.FirstName} {person.LastName} {person.Email}";
        }

        private void btnFiles_Click(object sender, RoutedEventArgs e)
        {
            string openDir = $"d:\\Development\\Training\\net2025\\";
            List<String> Files = Directory.EnumerateFiles(openDir, "*.txt")
                                            .ToList();

            Stopwatch stopwatch = new();
            stopwatch.Start();

            txbInfo.Text = "";

            foreach (var file in Files) 
            {
                var lines = File.ReadLines(file).ToArray();
                var count = lines.Count();

                txbInfo.Text += $"{file} : {count} {Environment.NewLine} ";
            }

            stopwatch.Stop();
            txbInfo.Text += $"Elapsed time: {stopwatch.Elapsed} {Environment.NewLine} ";

        }

        private void btnProcessFilesAll_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            txbInfo.Text = "";

            Dictionary<string, int> stats = new();

            var files = LoadFiles();

            foreach (var file in files)
            {
                var words = File.ReadLines(file);

                foreach (var word in words)
                {
                    if (stats.ContainsKey(word))
                        stats[word]++;
                    else
                        stats.TryAdd(word, 1);
                }
            }

            var top10 = stats.OrderByDescending(x => x.Value).Take(10);

            foreach (var word_kv in top10)
            {
                txbInfo.Text += $" {word_kv.Key} : {word_kv.Value} {Environment.NewLine}.";
            }

            stopwatch.Stop();
            txbInfo.Text += $"Elapsed time: {stopwatch.Elapsed} {Environment.NewLine} ";
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            txbInfo.Text = "";

            var files = LoadFiles();

            foreach (var file in files)
            {
                Dictionary<string, int> stats = new();
                var words = File.ReadLines(file);

                foreach (var word in words)
                {
                    if (stats.ContainsKey(word))
                        stats[word]++;
                    else
                        stats[word] = 1;
                }

                var top10 = stats.OrderByDescending(x => x.Value).Take(10);

                string line = System.IO.Path.GetFileName(file) + ": ";
                line += string.Join(", ", top10.Select(kv => $"{kv.Key}({kv.Value})"));

                txbInfo.Text += line + Environment.NewLine;
            }

            stopwatch.Stop();
        }
    }
}