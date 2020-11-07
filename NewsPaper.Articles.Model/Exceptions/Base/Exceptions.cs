namespace NewsPaper.Articles.Models.Exceptions.Base
{
    public static class Exceptions
    {
        public static string ThrownException => "An exception was thrown";

        public static string NoArticlesFoundForAuthorException => "This author has no articles";

        public static string FailedToCreateArticleException => "Failed to create article";

        public static string FailedTransferToArchiveException => "Failed transfer to archive";
    }
}
