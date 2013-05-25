using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SolutionTemplateGenerator.Core;
using SolutionTemplateGenerator.Core.ManifestCreator;
using SolutionTemplateGenerator.Models;
using SolutionTemplateGenerator.MVVM;

namespace SolutionTemplateGenerator.ViewModels
{
    public class MainWindowViewModel
    {
        #region Constructors (1)

        public MainWindowViewModel()
        {
            OptionsGuiData = ProjectSettings.LoadSettings();
            OptionsGuiData.PropertyChanged += optionsGuiDataPropertyChanged;
            DoCreateTemplate = new DelegateCommand<string>(doCreateTemplate, canDoCreateTemplate);
        }

        #endregion Constructors

        #region Properties (2)

        public DelegateCommand<string> DoCreateTemplate { set; get; }

        public OptionsGui OptionsGuiData { set; get; }

        #endregion Properties

        #region Methods (4)

        // Private Methods (4) 

        bool canDoCreateTemplate(string data)
        {
            return !string.IsNullOrWhiteSpace(OptionsGuiData.SolutionPath) &&
                   !string.IsNullOrWhiteSpace(OptionsGuiData.OutputFolder);
        }

        void doCreateTemplate(string data)
        {
            Task.Factory.StartNew(() =>
                {
                    try
                    {
                        ProjectSettings.SaveSettings(OptionsGuiData);
                        OptionsGuiData.IsBusy = true;
                        TemplateGeneratorFactory.Start(OptionsGuiData);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        OptionsGuiData.IsBusy = false;
                    }
                });
        }

        void optionsGuiDataPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SolutionPath":
                    solutionPathPropertyChanged();
                    break;
            }
        }

        private void solutionPathPropertyChanged()
        {
            var projects = SolutionFileParser.GetSolutionProjects(OptionsGuiData.SolutionPath);
            if (!projects.Any())
                return;

            var firstProject = projects.First();
            OptionsGuiData.ProductName = firstProject.ProjectName;
            OptionsGuiData.DefaultNamespace = firstProject.ProjectName;
            OptionsGuiData.ProductDescription = OptionsGuiData.ProductName;
            OptionsGuiData.ProjectType = firstProject.ProjectTypeName;
        }

        #endregion Methods
    }
}