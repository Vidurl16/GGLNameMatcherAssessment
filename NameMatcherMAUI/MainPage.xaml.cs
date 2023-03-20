using GGLMatchesAssessment.Utilities;
using Microsoft.Maui.Controls;
using NameMatcherUtilities.Interfaces;
using NameMatcherUtilities.Utilities;

namespace MyApp
{
    public partial class MainPage : ContentPage
    {
        private IGrouper _grouper;
        public MainPage()
        {
            InitializeComponent();

        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            string contestant1Name = Contestant1Entry.Text;
            string contestant2Name = Contestant2Entry.Text;

            string result = "";

            if (string.IsNullOrEmpty(contestant1Name) || string.IsNullOrEmpty(contestant2Name))
            {
                result = "Please enter a name for contestant.";
            }
            else
            {
                result = GetResult(contestant1Name, contestant2Name);
            }

            ResultLabel.Text = result;
        }

        private string GetResult(string name1, string name2)
        {
            string input = name1 + "matches" + name2;

            NameMatcher _nameMatcher = new NameMatcher(new NameGrouper());

            string result = _nameMatcher.MatchNames(input);

            return result;
        }
    }
}
