using PersonalWebsite.DatabaseModel;

namespace PersonalWebsite.CreateProject;

public static class ProductCreation
{
    private static int GetProjectIdFromDatabase(DatabaseContext context)
    {
        if (!context.ProjectDetails.Any())
            return 1;

        return context.ProjectDetails
            .Select(pd => pd.ProjectId)
            .Last() + 1;
    }

    public static List<ProjectDetails> DefineProject(DatabaseContext context,
        string projectName, string url)
    {
        List<ProjectDetails> project = new()
        {
            new ProjectDetails
            {
                ProjectId = GetProjectIdFromDatabase(context),
                Name = projectName,
                Url = url,
                Date = DateTime.Now
            }
        };

        return project;
    }
}