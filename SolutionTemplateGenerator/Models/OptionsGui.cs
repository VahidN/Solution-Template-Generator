using System;
using System.IO;
using System.Windows.Forms;
using SolutionTemplateGenerator.MVVM;

namespace SolutionTemplateGenerator.Models
{
    public class OptionsGui : ViewModelBase
    {
        #region Fields

        string _companyName;
        string _defaultNamespace;
        string _gettingStartedGuideUrl;
        string _iconImagePath;
        bool _isBusy;
        string _licenseFilePath;
        string _outputFolder;
        string _previewImagePath;
        string _productDescription;
        string _productName;
        string _projectSubType;
        string _projectType;
        bool _shouldSupportVS2010;
        bool _shouldSupportVS2012;
        bool _shouldSupportVS2013;
        bool _shouldSupportVS2015;
        string _solutionPath;
        string _version;

        #endregion Fields

        #region Constructors (1)

        public OptionsGui()
        {
            ProjectType = "CSharp";
            ProjectSubType = "Windows";
            Version = "1.0";
            CompanyName = Environment.UserName;
            ShouldSupportVS2010 = true;
            ShouldSupportVS2012 = true;
            ShouldSupportVS2013 = true;
            ShouldSupportVS2015 = true;
            OutputFolder = Path.Combine(Application.StartupPath, "Output");
            ProductDescription = "A project for creating an application using ...";
        }

        #endregion Constructors

        #region Properties (16)

        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                _companyName = value;
                RaisePropertyChanged(() => CompanyName);
            }
        }

        public string DefaultNamespace
        {
            get { return _defaultNamespace; }
            set
            {
                _defaultNamespace = value;
                RaisePropertyChanged(() => DefaultNamespace);
            }
        }

        public string GettingStartedGuideUrl
        {
            get { return _gettingStartedGuideUrl; }
            set
            {
                _gettingStartedGuideUrl = value;
                RaisePropertyChanged(() => GettingStartedGuideUrl);
            }
        }

        public string IconImagePath
        {
            get { return _iconImagePath; }
            set
            {
                _iconImagePath = value;
                RaisePropertyChanged(() => IconImagePath);
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public string LicenseFilePath
        {
            get { return _licenseFilePath; }
            set
            {
                _licenseFilePath = value;
                RaisePropertyChanged(() => LicenseFilePath);
            }
        }

        public string OutputFolder
        {
            get { return _outputFolder; }
            set
            {
                _outputFolder = value;
                RaisePropertyChanged(() => OutputFolder);
            }
        }

        public string PreviewImagePath
        {
            get { return _previewImagePath; }
            set
            {
                _previewImagePath = value;
                RaisePropertyChanged(() => PreviewImagePath);
            }
        }

        public string ProductDescription
        {
            get { return _productDescription; }
            set
            {
                _productDescription = value;
                RaisePropertyChanged(() => ProductDescription);
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                RaisePropertyChanged(() => ProductName);
            }
        }

        public string ProjectSubType
        {
            get { return _projectSubType; }
            set
            {
                _projectSubType = value;
                RaisePropertyChanged(() => ProjectSubType);
            }
        }

        public string ProjectType
        {
            get { return _projectType; }
            set
            {
                _projectType = value;
                RaisePropertyChanged(() => ProjectType);
            }
        }

        public bool ShouldSupportVS2010
        {
            get { return _shouldSupportVS2010; }
            set
            {
                _shouldSupportVS2010 = value;
                RaisePropertyChanged(() => ShouldSupportVS2010);
            }
        }

        public bool ShouldSupportVS2012
        {
            get { return _shouldSupportVS2012; }
            set
            {
                _shouldSupportVS2012 = value;
                RaisePropertyChanged(() => ShouldSupportVS2012);
            }
        }

        public bool ShouldSupportVS2013
        {
            get { return _shouldSupportVS2013; }
            set
            {
                _shouldSupportVS2013 = value;
                RaisePropertyChanged(() => ShouldSupportVS2013);
            }
        }

        public bool ShouldSupportVS2015
        {
            get { return _shouldSupportVS2015; }
            set
            {
                _shouldSupportVS2015 = value;
                RaisePropertyChanged(() => ShouldSupportVS2015);
            }
        }

        public string SolutionPath
        {
            get { return _solutionPath; }
            set
            {
                _solutionPath = value;
                RaisePropertyChanged(() => SolutionPath);
            }
        }

        public string Version
        {
            get { return _version; }
            set
            {
                _version = value;
                RaisePropertyChanged(() => Version);
            }
        }

        #endregion Properties
    }
}