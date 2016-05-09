using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MHLootTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db;

        List<CheckBox> lootBoxes = new List<CheckBox>();
        public MainWindow()
        {
            InitializeComponent();

            db = new Database();

            initGui();
        }

        private void initGui()
        {
            List<Hero> heroes = db.data.getHeroes();
            foreach (Hero h in heroes)
            {
                ComboBoxItem heroItem = new ComboBoxItem();
                heroItem.Content = h.toString();
                heroBox.Items.Add(heroItem);
            }
            heroBox.SelectedIndex = 0;

            List<Villain> villains = db.data.getVillains();
            foreach (Villain v in villains)
            {
                ComboBoxItem villainItem = new ComboBoxItem();
                villainItem.Content = v.toString();
                villainBox.Items.Add(villainItem);
            }
            villainBox.SelectedIndex = 0;

            updateLoot();
        }

        private void updateLoot()
        {
            lootPanel.Children.Clear();
            lootBoxes.Clear();

            LootList vLoot = db.data.getLoot(db.data.getVillain(villainBox.SelectedIndex));
            foreach (Loot l in vLoot.loot)
            {
                CheckBox lootBox = new CheckBox();
                lootBox.Content = l.itemName;
                Thickness margin = lootBox.Margin;
                margin.Left = margin.Right = margin.Top = margin.Bottom = 5;
                lootBox.Margin = margin;
                lootBoxes.Add(lootBox);
                lootPanel.Children.Add(lootBox);
            }
        }

        private void villainBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateLoot();
        }
    }
}
