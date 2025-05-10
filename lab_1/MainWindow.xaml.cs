using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Reflection.Emit;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;



namespace lab_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentFilePath = string.Empty;
        private string originalContent = string.Empty;
        private bool isClosingInitiatedByButton = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        //кнопка відкриття файлу
        private void Button_Open(object sender, RoutedEventArgs e)
        {

            save_cancel();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog(); //відкриття вікна для вибору файлу
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; //лише для txt файли
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true) //чи обрано опцію "відкрити"
            {
                currentFilePath = dlg.FileName; //шлях до файлу
                tittle.Title = "Текстовий редактор: " + System.IO.Path.GetFileName(currentFilePath); //заголовок
                originalContent = System.IO.File.ReadAllText(currentFilePath); //зберігаємо поточний вміст файлу
                text_box1.Text = originalContent; //зчитування вмісту файлу в текстове поле
            }
        }

        //кнопка збереження
        private void Button_Save(object sender, RoutedEventArgs e)
        {
            if (currentFilePath != string.Empty) //якщо файл уже був попередньо створений
            {
                File.WriteAllText(currentFilePath, text_box1.Text); //збереження змін
                tittle.Title = "Текстовий редактор: " + System.IO.Path.GetFileName(currentFilePath); //оновлення заголоку
                originalContent = text_box1.Text; //оновлення оригінального вмісту файлу
            }
            else //якщо файл вперше створюється
            {
                SaveAs(); //відкриття діалогового вікна для збереження файлу
            }

        }

        //кнопка збереження файлів, що не були попередньо створені
        private void Button_SaveAs(object sender, RoutedEventArgs e)
        {
            SaveAs(); //відкриття діалогового вікна для збереження файлу
        }

        //функція збереження файлів, що не були попередньо створені
        private void SaveAs() 
        {
            SaveFileDialog dlg = new SaveFileDialog() //діалогове вікно
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*" 
            };

            if (dlg.ShowDialog() == true)
            {
                string FilePath = dlg.FileName; //назва нового файлу
                File.WriteAllText(dlg.FileName, text_box1.Text); //запис вмісту текстового поля в файл
                tittle.Title = "Текстовий редактор: " + System.IO.Path.GetFileName(FilePath); //оновлення заголовку
                originalContent = text_box1.Text;
                currentFilePath = FilePath;
            }
        }

        //функція оновлення заголовку з назвою файлу
        private void UpdateFileName(object sender, TextChangedEventArgs e)
        {
            if (originalContent != text_box1.Text) //якщо файл редагувався => додати * до його назви
            {
                tittle.Title = "Текстовий редактор: *" + System.IO.Path.GetFileName(currentFilePath); 
            }
            else
            {
                tittle.Title = "Текстовий редактор: " + System.IO.Path.GetFileName(currentFilePath);
            }
        }

        //функція для збереження змін перед натисканням не того що треба
        private void save_cancel()
        {
            if (originalContent != text_box1.Text)
            {
                MessageBoxResult closingMessegeBoxResult = MessageBox.Show("Зберегти внесені зміни?", "Повідомлення",
                                                                            MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (closingMessegeBoxResult == MessageBoxResult.Yes)
                {
                    if (currentFilePath != string.Empty)
                    {
                        File.WriteAllText(currentFilePath, text_box1.Text);
                        
                    }
                    else
                    {
                        SaveAs();
                        
                    }
                }
                else if (closingMessegeBoxResult == MessageBoxResult.No)
                {
                    clear_Textare();
                }
            }
        }

        //функція очищення текстового поля + шляху + заголовка + збереженого вмісту
        private void clear_Textare()
        {
            text_box1.Text = string.Empty; //стирання вмісту текстового поля без збереження
            currentFilePath = string.Empty;
            tittle.Title = "Текстовий редактор";
            originalContent = string.Empty;
        }

        //кнопка створення нового файлу
        private void Button_Create(object sender, RoutedEventArgs e)
        {
            save_cancel();
            clear_Textare();
        }


        //кнопка закриття додатку "Закрити"
        private void Button_Close(object sender, RoutedEventArgs e)
        {
            if (originalContent != text_box1.Text)
            {
                MessageBoxResult closingMessegeBoxResult = MessageBox.Show("Зберегти внесені зміни?", "Повідомлення",
                                                                            MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (closingMessegeBoxResult == MessageBoxResult.Yes)
                {
                    if (currentFilePath != string.Empty)
                    {
                        File.WriteAllText(currentFilePath, text_box1.Text);
                        isClosingInitiatedByButton = true;
                        this.Close(); //закрити додаток
                    }
                    else
                    {
                        SaveAs();
                        isClosingInitiatedByButton = true;
                        this.Close();
                    }
                }
                else if (closingMessegeBoxResult == MessageBoxResult.No)
                    isClosingInitiatedByButton = true;
                { this.Close(); }
            }
            else
            {
                clear_Textare();
                isClosingInitiatedByButton = true;
                this.Close();
            }
        }

        //кнопка закриття додатку, функція самого вікна
        private void Window_Close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isClosingInitiatedByButton && originalContent != text_box1.Text)
            {
                MessageBoxResult result = MessageBox.Show(
                    "Зберегти внесені зміни?",
                    "Повідомлення",
                    MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    if (!string.IsNullOrEmpty(currentFilePath))
                    {
                        File.WriteAllText(currentFilePath, text_box1.Text);
                    }
                    else
                    {
                        SaveAs();
                    }
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            isClosingInitiatedByButton = false;
        }

    }
}