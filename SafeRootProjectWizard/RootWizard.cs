using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace SafeRootProjectWizard
{
    public class RootWizard : IWizard
    {
        public static Dictionary<string, string> GlobalDictionary = new Dictionary<string, string>();

        public void RunStarted(object automationObject,
                               Dictionary<string, string> replacementsDictionary,
                               WizardRunKind runKind,
                               object[] customParams)
        {
            GlobalDictionary["$saferootprojectname$"] = replacementsDictionary["$safeprojectname$"];
            replacementsDictionary.Add("$saferootprojectname$", GlobalDictionary["$saferootprojectname$"]);
        }

        public void RunFinished()
        {
        }

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }
    }
}