using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace SafeRootProjectWizard
{
    public class ChildWizard : IWizard
    {
        public void RunStarted(object automationObject,
                               Dictionary<string, string> replacementsDictionary,
                               WizardRunKind runKind,
                               object[] customParams)
        {
            string value;
            if (RootWizard.GlobalDictionary.TryGetValue("$saferootprojectname$", out value))
            {
                replacementsDictionary.Add("$saferootprojectname$", value);
            }
            else
            {
                if (replacementsDictionary.TryGetValue("$safeprojectname$", out value))
                {
                    replacementsDictionary.Add("$saferootprojectname$", value);
                }
            }
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