using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;

namespace NotePad
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Bold_Click(object sender, RoutedEventArgs e)
        {
            //rtb_content.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            if (rtb_content.Selection.GetPropertyValue(Run.FontWeightProperty) is FontWeight && ((FontWeight)rtb_content.Selection.GetPropertyValue(Run.FontWeightProperty)) == FontWeights.Bold)
                rtb_content.Selection.ApplyPropertyValue(Run.FontWeightProperty, FontWeights.Normal);
            else
                rtb_content.Selection.ApplyPropertyValue(Run.FontWeightProperty, FontWeights.Bold);
        }

        private void btn_italic_Click(object sender, RoutedEventArgs e)
        {
            if (rtb_content.Selection.GetPropertyValue(Run.FontStyleProperty) is FontStyle && ((FontStyle)rtb_content.Selection.GetPropertyValue(Run.FontStyleProperty)) == FontStyles.Normal)
                rtb_content.Selection.ApplyPropertyValue(Run.FontStyleProperty, FontStyles.Italic);
            else
                rtb_content.Selection.ApplyPropertyValue(Run.FontStyleProperty, FontStyles.Normal);
        }

        private void btn_underline_Click(object sender, RoutedEventArgs e)
        {
            rtb_content.Selection.ApplyPropertyValue(Run.TextDecorationsProperty, TextDecorations.Underline);
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            rtb_content.Selection.ApplyPropertyValue(Run.TextDecorationsProperty, TextDecorations.Strikethrough);
        }

        private void btn_left_Click(object sender, RoutedEventArgs e)
        {
            rtb_content.Selection.ApplyPropertyValue(TextBlock.TextAlignmentProperty, TextAlignment.Left);
        }

        private void btn_center_Click(object sender, RoutedEventArgs e)
        {
            rtb_content.Selection.ApplyPropertyValue(TextBlock.TextAlignmentProperty, TextAlignment.Center);
        }

        private void btn_right_Click(object sender, RoutedEventArgs e)
        {
            rtb_content.Selection.ApplyPropertyValue(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        }

        private void btn_justify_Click(object sender, RoutedEventArgs e)
        {
            rtb_content.Selection.ApplyPropertyValue(TextBlock.TextAlignmentProperty, TextAlignment.Justify);
        }

        private void cb_fontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rtb_content.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, cb_fontFamily.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
        }

        private void cb_fontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rtb_content.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, cb_fontSize.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ","").Replace("px", ""));
        }

        private void btn_img_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bi = new BitmapImage(new Uri(@"C:\SimpleImage.jpg"));
            Image image = new Image();
            image.Source = bi;
            InlineUIContainer container = new InlineUIContainer(image);
            Paragraph paragraph = new Paragraph(container);
            rtb_content.Document.Blocks.Add(paragraph);
        }

        private void btn_multi_img_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_video_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_music_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_showText_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(rtb_content.Document.ContentStart, rtb_content.Document.ContentEnd);
            MessageBox.Show(textRange.Text);
        }

        private void btn_showHtml_Click(object sender, RoutedEventArgs e)
        {
            string strDoc = System.Windows.Markup.XamlWriter.Save(rtb_content.Document);
            //StringReader stringReader = new StringReader(strDoc);               
            //XmlReader xmlReader = XmlReader.Create(stringReader);               
            //FlowDocument flowDocument = XamlReader.Load(xmlReader) as FlowDocument;

            TextRange textRange = new TextRange(rtb_content.Document.ContentStart, rtb_content.Document.ContentEnd);
            MessageBox.Show(HtmlFromXamlConverter.ConvertXamlToHtml(strDoc));
        }

        private void btn_count_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(rtb_content.Document.ContentStart, rtb_content.Document.ContentEnd);
            MessageBox.Show(textRange.Text.Length.ToString());
        }

        private void btn_foreground_Click(object sender, RoutedEventArgs e)
        {
            rtb_content.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
        }

        private void btn_background_Click(object sender, RoutedEventArgs e)
        {
            rtb_content.Selection.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Red));
        }
    }
}
