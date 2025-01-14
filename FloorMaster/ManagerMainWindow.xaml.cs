using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
namespace FloorMaster
{
    /// <summary>
    /// Логика взаимодействия для ManagerMainWindow.xaml
    /// </summary>
    public partial class ManagerMainWindow : Window
    {
        private MasterFloorEntities _context = new MasterFloorEntities().GetContext();

        private List<Partneer> _partneers = new List<Partneer>();
        public ManagerMainWindow()
        {
            InitializeComponent();

            _partneers = _context.Partneer.ToList();

            GetData();
        }

        public UIElement GeneratePartneerCard(Partneer partneer)
        {
            var stackPanel = new StackPanel { Margin = new Thickness(10) };

            var grid = new Grid();
            grid.Children.Add(new Label { Content = $"{partneer.ParteerType.name} | {partneer.name}", HorizontalAlignment = HorizontalAlignment.Left, FontSize = 17 });
            grid.Children.Add(new Label { Content = $"{GetPersent(partneer)}%", HorizontalAlignment = HorizontalAlignment.Right, FontSize = 17, Margin = new Thickness(0, 0, 30, 0) });

            stackPanel.Children.Add(grid);
            stackPanel.Children.Add(new Label { Content = $"Директор: {partneer.Director.surname} {partneer.Director.name} {partneer.Director.patronymic}" });
            stackPanel.Children.Add(new Label { Content = $"Телефон: {partneer.Director.phone}" });

            Border border = new Border();
            border.CornerRadius = new CornerRadius(20);
            border.Margin = new Thickness(40, 10, 40, 10);
            border.Child = stackPanel;

            border.Name = $"border{partneer.id}";

            return border;
        }

        public void GetData()
        {
            foreach (var partneer in _partneers)
            {
                var card = GeneratePartneerCard(partneer);
                card.MouseDown += OpenEditWindow;
                ScrollBarr.Children.Add(card);
            }

            var pT = _context.ParteerType.ToList();
            TypeOfOrganizationCB.ItemsSource = pT;
            TypeOfOrganizationCB.DisplayMemberPath = "name";
            TypeOfOrganizationCB.SelectedIndex = 0;

            var a = GetOrderViews();
            q.ItemsSource = a;
        }

        public List<OrderView> GetOrderViews()
        {
            var orderViews = (from order in _context.Order
                              join partner in _context.Partneer on order.partneerId equals partner.id
                              join productInOrder in _context.ProductInOrder on order.id equals productInOrder.orderId
                              join product in _context.Product on productInOrder.productId equals product.id
                              select new OrderView
                              {
                                  partneer = partner.name,
                                  date = order.createDate,
                                  product = product.name,
                                  amount = productInOrder.amount,
                                  caost = product.partneerMinCost,
                                  sum = (productInOrder.amount * product.partneerMinCost)
                              }).ToList();

            return orderViews;
        }

        public decimal GetPersent(Partneer partneer)
        {
            decimal discountPercentage = 0;
            try
            {
                // Получаем общую сумму покупок партнера
                decimal totalPurchases = _context.ProductInOrder
                    .Where(pio => pio.Order.partneerId == partneer.id)  // Фильтруем по Id партнера
                    .Join(_context.Product,  // Объединяем таблицу ProductInOrder с таблицей Product по ProductId
                        pio => pio.productId, // Связываем по ProductId
                        product => product.id, // и по Id продукта
                        (pio, product) => new { pio.amount, product.partneerMinCost })  // Выбираем нужные поля
                    .Sum(x => x.amount * x.partneerMinCost);  // Суммируем количество * цену

                //MessageBox.Show(totalPurchases.ToString());

                // Расчет скидки в зависимости от суммы покупок
                if (totalPurchases >= 300000)
                {
                    discountPercentage = 15;  // 15% скидка
                }
                else if (totalPurchases >= 50000)
                {
                    discountPercentage = 10;  // 10% скидка
                }
                else if (totalPurchases >= 10000)
                {
                    discountPercentage = 5;   // 5% скидка
                }
                else
                {
                    discountPercentage = 0;   // 0% скидка
                }

                return discountPercentage;
            }
            catch (Exception ex)
            {
                return 0;
            }

            
        }

        private void AddLogoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Director director = new Director
            {
                name = DirectorNameTB.Text,
                surname = DirectorSurnameTB.Text,
                patronymic = DirectorPatronymicTB.Text,
                phone = DirectorPhoneNumberTB.Text,
                email = DirectorEmailTB.Text
            };
            _context.Director.Add(director);

            try
            {


                Partneer partneer = new Partneer
                {
                    name = ParteerNameTB.Text,
                    lawAddress = LawAddressTB.Text,
                    INN = INNTB.Text,
                    Director = director,
                    rating = int.Parse(RateTB.Text),
                    parteerTypeId = _context.ParteerType.Where(i => i.id == TypeOfOrganizationCB.SelectedIndex + 1).FirstOrDefault().id
                };

                _context.Partneer.Add(partneer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Не успех!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            try
            {
                _context.SaveChanges();
                MessageBox.Show("Успех!!!!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Не успех!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void OpenEditWindow(object sender, RoutedEventArgs e)
        {
            new EditPartneer((sender as Border).Name).Show();
            Close();
        }


    }
}
