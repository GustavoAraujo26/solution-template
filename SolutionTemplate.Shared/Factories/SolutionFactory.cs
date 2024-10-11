namespace SolutionTemplate.Shared.Factories
{
    /// <summary>
    /// Fábrica relacionada a solução
    /// </summary>
    public static class SolutionFactory
    {
        /// <summary>
        /// Constrói o nome da solução
        /// </summary>
        /// <returns>Nome da solução</returns>
        public static string BuildName()
        {
            string solutionFullPath = GetCurrentProjectPath();

            var solutionPathSplit = solutionFullPath.Split("\\");

            var pathCount = 1;
            if (IsUnitTest(solutionFullPath))
                pathCount = 4;

            return solutionPathSplit[solutionPathSplit.Length - pathCount];
        }

        public static string GetCurrentProjectPath()
        {
            string exampleName = "project-example";

            var currentDirectory = Directory.GetCurrentDirectory();
            if (string.IsNullOrEmpty(currentDirectory))
                return exampleName;

            var solutionDirectoryInfo = Directory.GetParent(currentDirectory);
            if (solutionDirectoryInfo is null)
                return exampleName;

            string solutionFullPath = solutionDirectoryInfo.FullName;
            if (string.IsNullOrEmpty(solutionFullPath))
                return exampleName;
            else
                return solutionFullPath;
        }

        private static bool IsUnitTest(string solutionPath) =>
            solutionPath.ToLowerInvariant().Contains(".tests");
    }
}
