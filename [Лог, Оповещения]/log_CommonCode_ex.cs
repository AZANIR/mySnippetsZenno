public static class ProjectExtensions
{
    public static IZennoPosterProjectModel Debug(this IZennoPosterProjectModel project, string message, bool showInPoster = false)
    {
        project.SendInfoToLog(message, showInPoster);
        return project;
    }
    public static IZennoPosterProjectModel Info(this IZennoPosterProjectModel project, string message, bool showInPoster = true)
    {
        project.SendInfoToLog(message, showInPoster);
        return project;
    }
    public static IZennoPosterProjectModel Warning(this IZennoPosterProjectModel project, string message, bool showInPoster = true)
    {
        project.SendWarningToLog(message, showInPoster);
        return project;
    }
    public static IZennoPosterProjectModel Error(this IZennoPosterProjectModel project, string message, bool showInPoster = true)
    {
        project.SendErrorToLog(message, showInPoster);
        return project;
    }
}