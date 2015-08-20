using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace RedmineTimeTask
{
    /// <summary>
    /// Interaction logic for about.xaml
    /// </summary>
    public partial class about : Window
    {
        public about()
        {
            
            InitializeComponent();
            aboutBox.AddHandler(Hyperlink.RequestNavigateEvent, new RequestNavigateEventHandler(RequestNavigateHandler));
            // Create a FlowDocument to contain content for the RichTextBox.
            FlowDocument myFlowDoc = new FlowDocument();

            // Add paragraphs to the FlowDocument.

            Hyperlink icons4androidLink = new Hyperlink();
            icons4androidLink.Inlines.Add("icons4android");
            icons4androidLink.NavigateUri = new Uri("http://www.icons4android.com/iconset/15");

            Hyperlink oskarGithub = new Hyperlink();
            oskarGithub.Inlines.Add("github");
            oskarGithub.NavigateUri = new Uri("https://github.com/oskarp/redminetimetask");

            Hyperlink redmineLib = new Hyperlink();
            redmineLib.Inlines.Add("Redmine-net-api");
            redmineLib.NavigateUri = new Uri("https://github.com/zapadi/redmine-net-api");

            // Create a paragraph and add the Run and hyperlink to it.
            Paragraph mePa = new Paragraph();
            mePa.Inlines.Add("This project is open source and hosted at ");
            mePa.Inlines.Add(oskarGithub);
            myFlowDoc.Blocks.Add(mePa);

            Paragraph redminePa = new Paragraph();
            redminePa.Inlines.Add("We use ");
            redminePa.Inlines.Add(redmineLib);
            redminePa.Inlines.Add(" for the redmine communication.");
            myFlowDoc.Blocks.Add(redminePa);

            Paragraph icoPa = new Paragraph();
            icoPa.Inlines.Add("Icons from");
            icoPa.Inlines.Add(icons4androidLink);
            myFlowDoc.Blocks.Add(icoPa);
            // Add initial content to the RichTextBox.
            aboutBox.Document = myFlowDoc;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void RequestNavigateHandler(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.ToString());
        }
    }
}
