namespace ChatClub.Bot.Interface
{
    public interface ICsvService
    {
       Task ParseCsv(string message);
    }
}
